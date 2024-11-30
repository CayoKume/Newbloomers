using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresRepository : IB2CConsultaLegendasCadastrosAuxiliaresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaLegendasCadastrosAuxiliaresRepository(ISQLServerConnection? conn) =>
            (_conn) = (conn);

        public Task<bool> CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME LIKE '%{jobParameter.jobName}%'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = await conn.QueryAsync(sql: sql);

                    if (result.Count() == 0)
                    {
                        conn.CreateTable<B2CConsultaVendedores>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaVendedores>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTALEGENDASCADASTROSAUXILIARES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTALEGENDASCADASTROSAUXILIARES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[LEGENDA_SETOR] = SOURCE.[LEGENDA_SETOR],
			                           TARGET.[LEGENDA_LINHA] = SOURCE.[LEGENDA_LINHA],
			                           TARGET.[LEGENDA_MARCA] = SOURCE.[LEGENDA_MARCA],
			                           TARGET.[LEGENDA_COLECAO] = SOURCE.[LEGENDA_COLECAO],
			                           TARGET.[LEGENDA_GRADE1] = SOURCE.[LEGENDA_GRADE1],
			                           TARGET.[LEGENDA_GRADE2] = SOURCE.[LEGENDA_GRADE2],
			                           TARGET.[LEGENDA_ESPESSURA] = SOURCE.[LEGENDA_ESPESSURA],
			                           TARGET.[LEGENDA_CLASSIFICACAO] = SOURCE.[LEGENDA_CLASSIFICACAO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[EMPRESA] NOT IN (SELECT [EMPRESA] FROM [B2CCONSULTALEGENDASCADASTROSAUXILIARES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [EMPRESA], [LEGENDA_SETOR], [LEGENDA_LINHA], [LEGENDA_MARCA], [LEGENDA_COLECAO], [LEGENDA_GRADE1], [LEGENDA_GRADE2],
			                           [LEGENDA_ESPESSURA], [LEGENDA_CLASSIFICACAO], [TIMESTAMP])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[EMPRESA], SOURCE.[LEGENDA_SETOR], SOURCE.[LEGENDA_LINHA], SOURCE.[LEGENDA_MARCA], SOURCE.[LEGENDA_COLECAO], 
			                           SOURCE.[LEGENDA_GRADE1], SOURCE.[LEGENDA_GRADE2], SOURCE.[LEGENDA_ESPESSURA], SOURCE.[LEGENDA_CLASSIFICACAO], SOURCE.[TIMESTAMP]);
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
