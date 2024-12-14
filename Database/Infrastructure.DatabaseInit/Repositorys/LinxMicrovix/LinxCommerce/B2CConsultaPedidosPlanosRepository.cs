using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaPedidosPlanosRepository : IB2CConsultaPedidosPlanosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaPedidosPlanosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaPedidosPlanos>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaPedidosPlanos>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSPLANOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSPLANOS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPEDIDOSPLANOS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAPEDIDOSPLANOS] AS SOURCE

                                   ON (
			                           TARGET.[ID_PEDIDO_PLANOS] = SOURCE.[ID_PEDIDO_PLANOS]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PEDIDO_PLANOS] = SOURCE.[ID_PEDIDO_PLANOS],
			                           TARGET.[ID_PEDIDO] = SOURCE.[ID_PEDIDO],
			                           TARGET.[PLANO_PAGAMENTO] = SOURCE.[PLANO_PAGAMENTO],
			                           TARGET.[VALOR_PLANO] = SOURCE.[VALOR_PLANO],
			                           TARGET.[NSU_SITEF] = SOURCE.[NSU_SITEF],
			                           TARGET.[COD_AUTORIZACAO] = SOURCE.[COD_AUTORIZACAO],
			                           TARGET.[TEXTO_COMPROVANTE] = SOURCE.[TEXTO_COMPROVANTE],
			                           TARGET.[COD_LOJA_SITEF] = SOURCE.[COD_LOJA_SITEF],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO_PLANOS] NOT IN (SELECT [ID_PEDIDO_PLANOS] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPEDIDOSPLANOS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO_PLANOS], [ID_PEDIDO], [PLANO_PAGAMENTO], [VALOR_PLANO], [NSU_SITEF], [COD_AUTORIZACAO], [TEXTO_COMPROVANTE], [COD_LOJA_SITEF], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO_PLANOS], SOURCE.[ID_PEDIDO], SOURCE.[PLANO_PAGAMENTO], SOURCE.[VALOR_PLANO], SOURCE.[NSU_SITEF], SOURCE.[COD_AUTORIZACAO], SOURCE.[TEXTO_COMPROVANTE], SOURCE.[COD_LOJA_SITEF], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                                                <Parameter id=""id_pedido"">[id_pedido]</Parameter>"
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
