using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosTagsRepository : IB2CConsultaProdutosTagsRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosTagsRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaProdutosTags>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosTags>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSTAGS_SYNC')
                            BEGIN
                            EXECUTE (
	                            'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSTAGS_SYNC] AS
	                            BEGIN
		                            MERGE [B2CCONSULTAPRODUTOSTAGS_TRUSTED] AS TARGET
                                    USING [B2CCONSULTAPRODUTOSTAGS_RAW] AS SOURCE

                                    ON (
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS]
		                            )

                                    WHEN MATCHED AND TARGET.[parameters_timestamp] != SOURCE.[parameters_timestamp] THEN
			                            UPDATE SET
			                            TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                            TARGET.[ID_B2C_TAGS_PRODUTOS] = SOURCE.[ID_B2C_TAGS_PRODUTOS],
			                            TARGET.[ID_B2C_TAGS] = SOURCE.[ID_B2C_TAGS],
			                            TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                            TARGET.[DESCRICAO_B2C_TAGS] = SOURCE.[DESCRICAO_B2C_TAGS],
			                            TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp],
			                            TARGET.[PORTAL] = SOURCE.[PORTAL]

                                    WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_B2C_TAGS_PRODUTOS] NOT IN (SELECT [ID_B2C_TAGS_PRODUTOS] FROM [B2CCONSULTAPRODUTOSTAGS_TRUSTED]) THEN
			                            INSERT
			                            ([LASTUPDATEON], [ID_B2C_TAGS_PRODUTOS], [ID_B2C_TAGS], [CODIGOPRODUTO], [DESCRICAO_B2C_TAGS], [parameters_timestamp], [PORTAL])
			                            VALUES
			                            (SOURCE.[LASTUPDATEON], SOURCE.[ID_B2C_TAGS_PRODUTOS], SOURCE.[ID_B2C_TAGS], SOURCE.[CODIGOPRODUTO], SOURCE.[DESCRICAO_B2C_TAGS], SOURCE.[parameters_timestamp], SOURCE.[PORTAL]);
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
