using Dapper;
using DatabaseInit.Domain.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using System.Reflection.Metadata;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repository.LinxCommerce
{
    public class B2CConsultaPedidosPlanosRepository : IB2CConsultaPedidosPlanosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaPedidosPlanosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaPedidosPlanos>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaPedidosPlanos>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSPLANOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSPLANOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOSPLANOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPEDIDOSPLANOS_RAW] AS SOURCE

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

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PEDIDO_PLANOS] NOT IN (SELECT [ID_PEDIDO_PLANOS] FROM [B2CCONSULTAPEDIDOSPLANOS_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PEDIDO_PLANOS], [ID_PEDIDO], [PLANO_PAGAMENTO], [VALOR_PLANO], [NSU_SITEF], [COD_AUTORIZACAO], [TEXTO_COMPROVANTE], [COD_LOJA_SITEF], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PEDIDO_PLANOS], SOURCE.[ID_PEDIDO], SOURCE.[PLANO_PAGAMENTO], SOURCE.[VALOR_PLANO], SOURCE.[NSU_SITEF], SOURCE.[COD_AUTORIZACAO], SOURCE.[TEXTO_COMPROVANTE], SOURCE.[COD_LOJA_SITEF], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""id_pedido"">[id_pedido]</Parameter>",
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
