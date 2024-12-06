using Dapper;
using Domain.DatabaseInit.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesRepository : IB2CConsultaProdutosDetalhesRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosDetalhesRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaVendedores>(tableName: $"{jobParameter.jobName}");
                }

                using (var conn = _conn.GetIDbConnection(jobParameter.untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaVendedores>(tableName: $"{jobParameter.jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSDETALHES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSDETALHES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSDETALHES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSDETALHES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[ID_PROD_DET] = SOURCE.[ID_PROD_DET]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[ID_PROD_DET] = SOURCE.[ID_PROD_DET],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[SALDO] = SOURCE.[SALDO],
			                           TARGET.[CONTROLE_LOTE] = SOURCE.[CONTROLE_LOTE],
			                           TARGET.[NOMEPRODUTO_ALTERNATIVO] = SOURCE.[NOMEPRODUTO_ALTERNATIVO],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[LOCALIZACAO] = SOURCE.[LOCALIZACAO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[TEMPO_PREPARACAO_ESTOQUE] = SOURCE.[TEMPO_PREPARACAO_ESTOQUE]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[ID_PROD_DET] NOT IN (SELECT [ID_PROD_DET] FROM [B2CCONSULTAPRODUTOSDETALHES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [ID_PROD_DET], [CODIGOPRODUTO], [EMPRESA], [SALDO], [CONTROLE_LOTE], [NOMEPRODUTO_ALTERNATIVO], [TIMESTAMP], [REFERENCIA], [LOCALIZACAO], [PORTAL], [TEMPO_PREPARACAO_ESTOQUE])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[ID_PROD_DET], SOURCE.[CODIGOPRODUTO], SOURCE.[EMPRESA], SOURCE.[SALDO], SOURCE.[CONTROLE_LOTE], SOURCE.[NOMEPRODUTO_ALTERNATIVO], SOURCE.[TIMESTAMP], SOURCE.[REFERENCIA], SOURCE.[LOCALIZACAO], SOURCE.[PORTAL], SOURCE.[TEMPO_PREPARACAO_ESTOQUE]);
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
