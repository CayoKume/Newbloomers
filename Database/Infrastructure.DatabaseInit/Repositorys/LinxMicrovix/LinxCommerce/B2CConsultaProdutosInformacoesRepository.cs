using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesRepository : IB2CConsultaProdutosInformacoesRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosInformacoesRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaProdutosInformacoes>(tableName: $"{jobParameter.jobName}");
                }

                using (var conn = _conn.GetIDbConnection(jobParameter.untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosInformacoes>(tableName: $"{jobParameter.jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSINFORMACOES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSINFORMACOES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSINFORMACOES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSINFORMACOES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PRODUTOS_INFORMACOES] = SOURCE.[ID_PRODUTOS_INFORMACOES]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PRODUTOS_INFORMACOES] = SOURCE.[ID_PRODUTOS_INFORMACOES],
			                           TARGET.[CODIGO_PRODUTO] = SOURCE.[CODIGO_PRODUTO],
			                           TARGET.[INFORMACOES_PRODUTO] = SOURCE.[INFORMACOES_PRODUTO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PRODUTOS_INFORMACOES] NOT IN (SELECT [ID_PRODUTOS_INFORMACOES] FROM [B2CCONSULTAPRODUTOSINFORMACOES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PRODUTOS_INFORMACOES], [CODIGO_PRODUTO], [INFORMACOES_PRODUTO], [TIMESTAMP], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PRODUTOS_INFORMACOES], SOURCE.[CODIGO_PRODUTO], SOURCE.[INFORMACOES_PRODUTO], SOURCE.[TIMESTAMP], SOURCE.[PORTAL]);
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
