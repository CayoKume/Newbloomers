using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaClientesContatosRepository : IB2CConsultaClientesContatosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaClientesContatosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce.B2CConsultaClientesContatos>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}' AND TABLE_SCHEMA = 'untreated'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce.B2CConsultaClientesContatos>();
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTACLIENTESCONTATOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTACLIENTESCONTATOS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTACLIENTESCONTATOS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTACLIENTESCONTATOS] AS SOURCE

                                   ON (
			                           TARGET.ID_CLIENTES_CONTATOS = SOURCE.ID_CLIENTES_CONTATOS
		                           )
        
		                           WHEN MATCHED AND SOURCE.[TIMESTAMP] != TARGET.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_CLIENTES_CONTATOS] = SOURCE.[ID_CLIENTES_CONTATOS],
			                           TARGET.[ID_CONTATO_B2C] = SOURCE.[ID_CONTATO_B2C],
			                           TARGET.[NOME_CONTATO] = SOURCE.[NOME_CONTATO],
			                           TARGET.[DATA_NASC_CONTATO] = SOURCE.[DATA_NASC_CONTATO],
			                           TARGET.[SEXO_CONTATO] = SOURCE.[SEXO_CONTATO],
			                           TARGET.[ID_PARENTESCO] = SOURCE.[ID_PARENTESCO],
			                           TARGET.[FONE_CONTATO] = SOURCE.[FONE_CONTATO],
			                           TARGET.[CELULAR_CONTATO] = SOURCE.[CELULAR_CONTATO],
			                           TARGET.[EMAIL_CONTATO] = SOURCE.[EMAIL_CONTATO],
			                           TARGET.[COD_CLIENTE_ERP] = SOURCE.[COD_CLIENTE_ERP],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_CLIENTES_CONTATOS] NOT IN (SELECT [ID_CLIENTES_CONTATOS] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTACLIENTESCONTATOS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_CLIENTES_CONTATOS], [ID_CONTATO_B2C], [NOME_CONTATO], [DATA_NASC_CONTATO], [SEXO_CONTATO],
			                           [ID_PARENTESCO], [FONE_CONTATO], [CELULAR_CONTATO], [EMAIL_CONTATO], [COD_CLIENTE_ERP], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_CLIENTES_CONTATOS], SOURCE.[ID_CONTATO_B2C], SOURCE.[NOME_CONTATO], SOURCE.[DATA_NASC_CONTATO], SOURCE.[SEXO_CONTATO],
			                           SOURCE.[ID_PARENTESCO], SOURCE.[FONE_CONTATO], SOURCE.[CELULAR_CONTATO], SOURCE.[EMAIL_CONTATO], SOURCE.[COD_CLIENTE_ERP], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
