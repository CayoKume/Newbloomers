using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxMicrovix
{
    public class LinxProdutosCodBarRepository : ILinxProdutosCodBarRepository
    {
        private readonly ISQLServerConnection? _conn;

        public LinxProdutosCodBarRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count()  == 0)
                        conn.CreateTable<LinxProdutosCodBar>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count()  == 0)
                        conn.CreateTable<LinxProdutosCodBar>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_LINXPRODUTOSCODBAR_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_LINXPRODUTOSCODBAR_SYNC] AS
	                           BEGIN
		                           MERGE [LINXPRODUTOSCODBAR_TRUSTED] AS TARGET
                                   USING [LINXPRODUTOSCODBAR_RAW] AS SOURCE

                                   ON (
			                           TARGET.[COD_PRODUTO] = SOURCE.[COD_PRODUTO]
		                           )

                                   WHEN MATCHED AND TARGET.[parameters_timestamp] != SOURCE.[parameters_timestamp] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[COD_PRODUTO] = SOURCE.[COD_PRODUTO],
			                           TARGET.[COD_BARRA] = SOURCE.[COD_BARRA],
			                           TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[COD_PRODUTO] NOT IN (SELECT [COD_PRODUTO] FROM [LINXPRODUTOSCODBAR_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [COD_PRODUTO], [COD_BARRA], [parameters_timestamp], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[COD_PRODUTO], SOURCE.[COD_BARRA], SOURCE.[parameters_timestamp], SOURCE.[PORTAL]);
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
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                   <Parameter id=""cod_produto"">[cod_produto]</Parameter>"

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
