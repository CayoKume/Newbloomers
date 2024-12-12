using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
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
            string? sql = @$"SELECT DISTINCT * FROM [INFORMATION_SCHEMA].[TABLES] (NOLOCK) WHERE TABLE_NAME = '{jobName}'";

            try
            {
                using (var conn = _conn.GetIDbConnection(databaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosPromocao>(tableName: $"{jobName}");
                }

                using (var conn = _conn.GetIDbConnection(untreatedDatabaseName))
                {
                    var result = conn.Query(sql: sql);

                    if (result.Count() == 0)
                        conn.CreateTable<B2CConsultaProdutosPromocao>(tableName: $"{jobName}");
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOSPROMOCOES_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOSPROMOCOES_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOSPROMOCOES_RAW] AS SOURCE

                                   ON (
			                           TARGET.[CODIGO_PROMOCAO] = SOURCE.[CODIGO_PROMOCAO]
		                           )

                                   WHEN MATCHED AND TARGET.[parameters_timestamp] != SOURCE.[parameters_timestamp] THEN
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
			                           TARGET.[parameters_timestamp] = SOURCE.[parameters_timestamp],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGO_PROMOCAO] NOT IN (SELECT [CODIGO_PROMOCAO] FROM [B2CCONSULTAPRODUTOSPROMOCOES_TRUSTED]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGO_PROMOCAO], [EMPRESA], [CODIGOPRODUTO], [PRECO], [DATA_INICIO], [DATA_TERMINO], [DATA_CADASTRO], [ATIVA], [CODIGO_CAMPANHA], [PROMOCAO_OPCIONAL], [parameters_timestamp], [REFERENCIA], [PORTAL])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGO_PROMOCAO], SOURCE.[EMPRESA], SOURCE.[CODIGOPRODUTO], SOURCE.[PRECO], SOURCE.[DATA_INICIO], SOURCE.[DATA_TERMINO], SOURCE.[DATA_CADASTRO], SOURCE.[ATIVA], SOURCE.[CODIGO_CAMPANHA], SOURCE.[PROMOCAO_OPCIONAL], SOURCE.[parameters_timestamp],
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
