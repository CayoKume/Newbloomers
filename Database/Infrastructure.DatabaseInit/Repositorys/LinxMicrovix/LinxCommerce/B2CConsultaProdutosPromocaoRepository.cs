using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoRepository : IB2CConsultaProdutosPromocaoRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosPromocaoRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Trusted.LinxCommerce.B2CConsultaProdutosPromocao>();
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
                        conn.CreateTable<Domain.DatabaseInit.Entities.LinxMicrovix.Untreated.LinxCommerce.B2CConsultaProdutosPromocao>();
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSPROMOCOES] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAPRODUTOSPROMOCOES] AS SOURCE

                                   ON (
			                           TARGET.[CODIGO_PROMOCAO] = SOURCE.[CODIGO_PROMOCAO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGO_PROMOCAO] = SOURCE.[CODIGO_PROMOCAO],
			                           TARGET.[EMPRESA] = SOURCE.[EMPRESA],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[PRECO] = SOURCE.[PRECO],
			                           TARGET.[DATA_INICIO] = SOURCE.[DATA_INICIO],
			                           TARGET.[DATA_TERMINO] = SOURCE.[DATA_TERMINO],
			                           TARGET.[DATA_CADASTRO] = SOURCE.[DATA_CADASTRO],
			                           TARGET.[ATIVA] = SOURCE.[ATIVA],
			                           TARGET.[CODIGO_CAMPANHA] = SOURCE.[CODIGO_CAMPANHA],
			                           TARGET.[PROMOCAO_OPCIONAL] = SOURCE.[PROMOCAO_OPCIONAL],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_PROMOCAO] NOT IN (SELECT [CODIGO_PROMOCAO] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOSPROMOCOES]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_PROMOCAO], [EMPRESA], [CODIGOPRODUTO], [PRECO], [DATA_INICIO], [DATA_TERMINO], [DATA_CADASTRO], [ATIVA], [CODIGO_CAMPANHA], [PROMOCAO_OPCIONAL], [TIMESTAMP], [REFERENCIA], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_PROMOCAO], SOURCE.[EMPRESA], SOURCE.[CODIGOPRODUTO], SOURCE.[PRECO], SOURCE.[DATA_INICIO], SOURCE.[DATA_TERMINO], SOURCE.[DATA_CADASTRO], SOURCE.[ATIVA], SOURCE.[CODIGO_CAMPANHA], SOURCE.[PROMOCAO_OPCIONAL], SOURCE.[TIMESTAMP],
			                           SOURCE.[REFERENCIA], SOURCE.[PORTAL]);
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
                                                <Parameter id=""data_inicio"">[data_inicio]</Parameter>
                                                <Parameter id=""data_termino"">[data_termino]</Parameter>",
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
