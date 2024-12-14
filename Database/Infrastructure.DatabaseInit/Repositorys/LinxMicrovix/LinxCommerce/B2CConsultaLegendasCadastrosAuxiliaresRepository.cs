using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresRepository : IB2CConsultaLegendasCadastrosAuxiliaresRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaLegendasCadastrosAuxiliaresRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaLegendasCadastrosAuxiliares>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaLegendasCadastrosAuxiliares>(tableName: $"{jobName}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(string databaseName, string tableName)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTALEGENDASCADASTROSAUXILIARES_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTALEGENDASCADASTROSAUXILIARES] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTALEGENDASCADASTROSAUXILIARES] AS SOURCE

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

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[EMPRESA] NOT IN (SELECT [EMPRESA] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTALEGENDASCADASTROSAUXILIARES]) THEN
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
                using (var conn = _conn.GetIDbConnection(databaseName))
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

        public async Task<bool> InsertParametersIfNotExists(string jobName, string parametersTableName, string databaseName)
        {
            try
            {
                var parameter = new
                {
                    method = jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>"
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{parametersTableName}] WHERE [method] = '{jobName}') " +
                              $"INSERT INTO [{parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual)";


                using (var conn = _conn.GetIDbConnection(databaseName))
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
