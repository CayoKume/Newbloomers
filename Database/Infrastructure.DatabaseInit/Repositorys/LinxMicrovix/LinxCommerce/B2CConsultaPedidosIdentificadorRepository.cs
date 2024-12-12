using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorRepository : IB2CConsultaPedidosIdentificadorRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaPedidosIdentificadorRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaPedidosIdentificador>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaPedidosIdentificador>(tableName: $"{jobName}");
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
		
		                           WHEN MATCHED AND TARGET.[parameters_timestamp] != SOURCE.[parameters_timestamp] THEN 
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
			                           TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp]
		
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_VENDA] NOT IN (SELECT [ID_VENDA] FROM [B2CCONSULTAPEDIDOSIDENTIFICADOR_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [PORTAL], [EMPRESA], [IDENTIFICADOR], [ID_VENDA], [ORDER_ID], [ID_CLIENTE], [VALOR_FRETE], [DATA_ORIGEM], [parameters_timestamp])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[PORTAL], SOURCE.[EMPRESA], SOURCE.[IDENTIFICADOR], SOURCE.[ID_VENDA], SOURCE.[ORDER_ID], SOURCE.[ID_CLIENTE], SOURCE.[VALOR_FRETE], SOURCE.[DATA_ORIGEM], SOURCE.[parameters_timestamp]);
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
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""data_origem_fim"">[data_origem_fim]</Parameter>
                                                <Parameter id=""data_origem_inicial"">[data_origem_inicial]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""order_id"">[order_id]</Parameter>"
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
