using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxCommerce
{
    public class B2CConsultaClassificacaoRepository : IB2CConsultaClassificacaoRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaClassificacaoRepository(ISQLServerConnection? conn) =>
            (_conn) = (conn);

        public async Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{jobParameter.jobName}%'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<B2CConsultaClassificacao>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaClassificacao>(tableName: $"{jobParameter.jobName}_trusted");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
                //throw new ExecuteCommandException()
                //{
                //    project = $"{jobParameter.projectName} - IntegrationsCore",
                //    job = jobParameter.jobName,
                //    method = $"CreateDataTableIfNotExists",
                //    message = $"Error when trying to create table: {jobParameter.tableName}",
                //    schema = $"[{jobParameter.tableName}]",
                //    command = sql,
                //    exception = ex.Message
                //};
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLASSIFICACAO_SYNC')
                           BEGIN
                           EXECUTE (
                               'CREATE PROCEDURE [P_B2CCONSULTACLASSIFICACAO_SYNC] AS
                               BEGIN
	                               MERGE [B2CCONSULTACLASSIFICACAO_TRUSTED] AS TARGET 
	                               USING [B2CCONSULTACLASSIFICACAO_RAW] AS SOURCE 

	                               ON (
                                        TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO]
                                   ) 
	                           
                                   WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
                                       UPDATE SET 
	                                   TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON], 
	                                   TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO], 
	                                   TARGET.[NOME_CLASSIFICACAO] = SOURCE.[NOME_CLASSIFICACAO], 
	                                   TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP], 
	                                   TARGET.[PORTAL] = SOURCE.[PORTAL] 
	                           
                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_CLASSIFICACAO] NOT IN (SELECT [CODIGO_CLASSIFICACAO] FROM [B2CCONSULTACLASSIFICACAO_TRUSTED]) THEN 
	                                   INSERT ([LASTUPDATEON], [CODIGO_CLASSIFICACAO], [NOME_CLASSIFICACAO], [TIMESTAMP], [PORTAL])
	                                   VALUES (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_CLASSIFICACAO], SOURCE.[NOME_CLASSIFICACAO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
                               END'
                           )
                           END";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertParametersIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                var parameter = new {
                    method = jobParameter.jobName,
                    parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""codigo_classificacao"">[codigo_classificacao]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual], [ativo]) " +
                               "VALUES (@method, @parameters_timestamp, @parameters_dateinterval, @parameters_individual, @ativo)";


                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.ExecuteAsync(sql: sql, param: parameter, commandTimeout: 360);

                    if (result > 0)
                        return true;

                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
