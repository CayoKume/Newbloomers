using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaImagensRepository : IB2CConsultaImagensRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaImagensRepository(ISQLServerConnection? conn) =>
            _conn = conn;

        public bool CreateDataTableIfNotExists(string databaseName, string jobName, string untreatedDatabaseName)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}' AND TABLE_SCHEMA = 'linx_microvix_commerce'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce.B2CConsultaImagens>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}' AND TABLE_SCHEMA = 'untreated'";

            try
            {
                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce.B2CConsultaImagens>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public async Task<bool> CreateTableMerge(string databaseName, string tableName)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAIMAGENS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAIMAGENS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAIMAGENS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAIMAGENS] AS SOURCE

                                   ON (
			                           TARGET.[ID_IMAGEM] = SOURCE.[ID_IMAGEM]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_IMAGEM] = SOURCE.[ID_IMAGEM],
			                           TARGET.[MD5] = SOURCE.[MD5],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[URL_IMAGEM_BLOB] = SOURCE.[URL_IMAGEM_BLOB]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_IMAGEM] NOT IN (SELECT [ID_IMAGEM] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAIMAGENS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_IMAGEM], [MD5], [TIMESTAMP], [PORTAL], [URL_IMAGEM_BLOB])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_IMAGEM], SOURCE.[MD5], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[URL_IMAGEM_BLOB]);
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
                                                <Parameter id=""id_imagem"">[id_imagem]</Parameter>"
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [linx_microvix].[{parametersTableName}] WHERE [method] = '{jobName}') " +
                              $"INSERT INTO [linx_microvix].[{parametersTableName}] ([method], [parameters_timestamp], [parameters_dateinterval], [parameters_individual]) " +
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
