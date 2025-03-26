using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosRepository : IB2CConsultaProdutosAssociadosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosAssociadosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce.B2CConsultaProdutosAssociados>();
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
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce.B2CConsultaProdutosAssociados>();
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSASSOCIADOS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSASSOCIADOS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAPRODUTOSASSOCIADOS] AS SOURCE

                                   ON (
			                           TARGET.[ID] = SOURCE.[ID]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID] = SOURCE.[ID],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[CODIGOPRODUTO_ASSOCIADO] = SOURCE.[CODIGOPRODUTO_ASSOCIADO],
			                           TARGET.[COEFICIENTE_DESCONTO] = SOURCE.[COEFICIENTE_DESCONTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[QTDE_ITEM] = SOURCE.[QTDE_ITEM],
			                           TARGET.[ITEM_OBRIGATORIO] = SOURCE.[ITEM_OBRIGATORIO]
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID] NOT IN (SELECT [ID] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSASSOCIADOS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID], [CODIGOPRODUTO], [CODIGOPRODUTO_ASSOCIADO], [COEFICIENTE_DESCONTO], [TIMESTAMP], [PORTAL], [QTDE_ITEM], [ITEM_OBRIGATORIO])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID], SOURCE.[CODIGOPRODUTO], SOURCE.[CODIGOPRODUTO_ASSOCIADO], SOURCE.[COEFICIENTE_DESCONTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL], SOURCE.[QTDE_ITEM], SOURCE.[ITEM_OBRIGATORIO]);
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
                                                <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>"
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
