using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
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

        public bool CreateDataTableIfNotExists(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobParameter.jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(jobParameter.databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosCustos>(tableName: $"{jobParameter.jobName}");
                }

                using (var conn = _conn.GetIDbConnection(jobParameter.untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosCustos>(tableName: $"{jobParameter.jobName}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSCUSTOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSCUSTOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSCUSTOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSCUSTOS_RAW] AS SOURCE

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
        
		                           WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PRODUTOS_CUSTOS] NOT IN (SELECT [ID_PRODUTOS_CUSTOS] FROM [B2CCONSULTAPRODUTOSCUSTOS_TRUSTED]) THEN
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
                var parameter = new
                {
                    method = jobParameter.jobName,
                    timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>",
                    individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
                    ativo = 1
                };

                string? sql = $"IF NOT EXISTS (SELECT * FROM [{jobParameter.parametersTableName}] WHERE [method] = '{jobParameter.jobName}') " +
                              $"INSERT INTO [{jobParameter.parametersTableName}] ([method], [timestamp], [dateinterval], [individual], [ativo]) " +
                               "VALUES (@method, @timestamp, @dateinterval, @individual, @ativo)";


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
