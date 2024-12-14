using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosCustosRepository : IB2CConsultaProdutosCustosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosCustosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaProdutosCustos>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosCustos>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCUSTOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCUSTOS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSCUSTOS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAPRODUTOSCUSTOS] AS SOURCE

                                   ON (
			                           TARGET.[ID_PRODUTOS_CUSTOS] = SOURCE.[ID_PRODUTOS_CUSTOS]
		                           )
        
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PRODUTOS_CUSTOS] = SOURCE.[ID_PRODUTOS_CUSTOS],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CUSTOICMS1] = SOURCE.[CUSTOICMS1],
			                           TARGET.[IPI1] = SOURCE.[IPI1],
			                           TARGET.[MARKUP] = SOURCE.[MARKUP],
			                           TARGET.[CUSTOMEDIO] = SOURCE.[CUSTOMEDIO],
			                           TARGET.[FRETE1] = SOURCE.[FRETE1],
			                           TARGET.[PRECISAO] = SOURCE.[PRECISAO],
			                           TARGET.[PRECOMINIMO] = SOURCE.[PRECOMINIMO],
			                           TARGET.[DT_UPDATE] = SOURCE.[DT_UPDATE],
			                           TARGET.[CUSTOLIQUIDO] = SOURCE.[CUSTOLIQUIDO],
			                           TARGET.[PRECOVENDA] = SOURCE.[PRECOVENDA],
			                           TARGET.[CUSTOTOTAL] = SOURCE.[CUSTOTOTAL],
			                           TARGET.[PRECOCOMPRA] = SOURCE.[PRECOCOMPRA],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PRODUTOS_CUSTOS] NOT IN (SELECT [ID_PRODUTOS_CUSTOS] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSCUSTOS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PRODUTOS_CUSTOS], [CODIGOPRODUTO], [EMPRESA], [CUSTOICMS1], [IPI1], [MARKUP], [CUSTOMEDIO], [FRETE1], [PRECISAO], [PRECOMINIMO], [DT_UPDATE], [CUSTOLIQUIDO], [PRECOVENDA], [CUSTOTOTAL], [PRECOCOMPRA], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PRODUTOS_CUSTOS], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[CUSTOICMS1], SOURCE.[IPI1], SOURCE.[MARKUP], SOURCE.[CUSTOMEDIO], SOURCE.[FRETE1], SOURCE.[PRECISAO], SOURCE.[PRECOMINIMO],
			                           SOURCE.[DT_UPDATE], SOURCE.[CUSTOLIQUIDO], SOURCE.[PRECOVENDA], SOURCE.[CUSTOTOTAL], SOURCE.[PRECOCOMPRA], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
