using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxCommerce
{
    public class B2CConsultaEmpresasRepository : IB2CConsultaEmpresasRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaEmpresasRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaEmpresas>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaEmpresas>(tableName: $"{jobParameter.jobName}_trusted");

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAEMPRESAS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAEMPRESAS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAEMPRESAS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAEMPRESAS_RAW] AS SOURCE

                                   ON (
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[NOME_EMP] = SOURCE.[NOME_EMP],
			                           TARGET.[CNPJ_EMP] = SOURCE.[CNPJ_EMP],
			                           TARGET.[END_UNIDADE] = SOURCE.[END_UNIDADE],
			                           TARGET.[COMPLEMENTO_END_UNIDADE] = SOURCE.[COMPLEMENTO_END_UNIDADE],
			                           TARGET.[NR_RUA_UNIDADE] = SOURCE.[NR_RUA_UNIDADE],
			                           TARGET.[BAIRRO_UNIDADE] = SOURCE.[BAIRRO_UNIDADE],
			                           TARGET.[CEP_UNIDADE] = SOURCE.[CEP_UNIDADE],
			                           TARGET.[CIDADE_UNIDADE] = SOURCE.[CIDADE_UNIDADE],
			                           TARGET.[UF_UNIDADE] = SOURCE.[UF_UNIDADE],
			                           TARGET.[EMAIL_UNIDADE] = SOURCE.[EMAIL_UNIDADE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[DATA_CRIACAO] = SOURCE.[DATA_CRIACAO],
			                           TARGET.[CENTRO_DISTRIBUICAO] = SOURCE.[CENTRO_DISTRIBUICAO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[EMPRESA] NOT IN (SELECT [EMPRESA] FROM [B2CCONSULTAEMPRESAS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [EMPRESA], [NOME_EMP], [CNPJ_EMP], [END_UNIDADE], [COMPLEMENTO_END_UNIDADE], [NR_RUA_UNIDADE], [BAIRRO_UNIDADE], [CEP_UNIDADE], [CIDADE_UNIDADE], [UF_UNIDADE], [EMAIL_UNIDADE], [TIMESTAMP],
			                           [DATA_CRIACAO], [CENTRO_DISTRIBUICAO], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[EMPRESA], SOURCE.[NOME_EMP], SOURCE.[CNPJ_EMP], SOURCE.[END_UNIDADE], SOURCE.[COMPLEMENTO_END_UNIDADE], SOURCE.[NR_RUA_UNIDADE], SOURCE.[BAIRRO_UNIDADE], SOURCE.[CEP_UNIDADE], SOURCE.[CIDADE_UNIDADE],
			                           SOURCE.[UF_UNIDADE], SOURCE.[EMAIL_UNIDADE], SOURCE.[TIMESTAMP], SOURCE.[DATA_CRIACAO], SOURCE.[CENTRO_DISTRIBUICAO], SOURCE.[PORTAL]);
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
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>",
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
