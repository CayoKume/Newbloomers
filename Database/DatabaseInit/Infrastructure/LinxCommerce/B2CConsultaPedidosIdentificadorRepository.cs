using Dapper;
using DatabaseInit.Domain.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repository.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorRepository : IB2CConsultaPedidosIdentificadorRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaPedidosIdentificadorRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaPedidosIdentificador>(tableName: $"{jobParameter.jobName}_raw");
                        conn.CreateTable<B2CConsultaPedidosIdentificador>(tableName: $"{jobParameter.jobName}_trusted");

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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPEDIDOSIDENTIFICADOR_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPEDIDOSIDENTIFICADOR_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPEDIDOSIDENTIFICADOR_TRUSTED] AS TARGET
		                           USING [B2CCONSULTAPEDIDOSIDENTIFICADOR_RAW] AS SOURCE
		
		                           ON (
			                           TARGET.[ID_VENDA] = SOURCE.[ID_VENDA]
		                           )
		
		                           WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[IDENTIFICADOR] = SOURCE.[IDENTIFICADOR],
			                           TARGET.[ID_VENDA] = SOURCE.[ID_VENDA],
			                           TARGET.[ORDER_ID] = SOURCE.[ORDER_ID],
			                           TARGET.[ID_CLIENTE] = SOURCE.[ID_CLIENTE],
			                           TARGET.[VALOR_FRETE] = SOURCE.[VALOR_FRETE],
			                           TARGET.[DATA_ORIGEM] = SOURCE.[DATA_ORIGEM],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP]
		
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_VENDA] NOT IN (SELECT [ID_VENDA] FROM [B2CCONSULTAPEDIDOSIDENTIFICADOR_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [PORTAL], [EMPRESA], [IDENTIFICADOR], [ID_VENDA], [ORDER_ID], [ID_CLIENTE], [VALOR_FRETE], [DATA_ORIGEM], [TIMESTAMP])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[EMPRESA], SOURCE.[IDENTIFICADOR], SOURCE.[ID_VENDA], SOURCE.[ORDER_ID], SOURCE.[ID_CLIENTE], SOURCE.[VALOR_FRETE], SOURCE.[DATA_ORIGEM], SOURCE.[TIMESTAMP]);
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
                    parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""data_origem_fim"">[data_origem_fim]</Parameter>
                                                <Parameter id=""data_origem_inicial"">[data_origem_inicial]</Parameter>",
                    parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""order_id"">[order_id]</Parameter>",
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
