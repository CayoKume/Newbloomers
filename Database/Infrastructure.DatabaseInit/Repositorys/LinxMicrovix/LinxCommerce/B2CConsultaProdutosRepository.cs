using Dapper;
using Domain.DatabaseInit.Interfaces.LinxMicrovix.LinxCommerce;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Infrastructure.IntegrationsCore.Connections.SQLServer;
using Z.Dapper.Plus;

namespace Infrastructure.DatabaseInit.Repositorys.LinxMicrovix.LinxCommerce
{
    public class B2CConsultaProdutosRepository : IB2CConsultaProdutosRepository
    {
        private readonly ISQLServerConnection? _conn;

        public B2CConsultaProdutosRepository(ISQLServerConnection? conn) =>
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
                        conn.CreateTable<B2CConsultaProdutos>();
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
                        conn.CreateTable<Domain.DatabaseInit.Entites.LinxMicrovix.LinxCommerce.B2CConsultaProdutos>();
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
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOS_SYNC] AS
	                           BEGIN
		                           MERGE [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOS] AS TARGET
                                   USING [UNTREATED].[dbo].[B2CCONSULTAPRODUTOS] AS SOURCE

                                   ON (
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO]
		                           )

                                   WHEN MATCHED AND TARGET.[TIMESTAMP] != SOURCE.[TIMESTAMP] THEN 
			                           UPDATE SET
			                           TARGET.[LASTUPDATEON] = SOURCE.[LASTUPDATEON],
			                           TARGET.[CODIGOPRODUTO] = SOURCE.[CODIGOPRODUTO],
			                           TARGET.[REFERENCIA] = SOURCE.[REFERENCIA],
			                           TARGET.[CODAUXILIAR1] = SOURCE.[CODAUXILIAR1],
			                           TARGET.[DESCRICAO_BASICA] = SOURCE.[DESCRICAO_BASICA],
			                           TARGET.[NOME_PRODUTO] = SOURCE.[NOME_PRODUTO],
			                           TARGET.[PESO_LIQUIDO] = SOURCE.[PESO_LIQUIDO],
			                           TARGET.[CODIGO_SETOR] = SOURCE.[CODIGO_SETOR],
			                           TARGET.[CODIGO_LINHA] = SOURCE.[CODIGO_LINHA],
			                           TARGET.[CODIGO_MARCA] = SOURCE.[CODIGO_MARCA],
			                           TARGET.[CODIGO_COLECAO] = SOURCE.[CODIGO_COLECAO],
			                           TARGET.[CODIGO_ESPESSURA] = SOURCE.[CODIGO_ESPESSURA],
			                           TARGET.[CODIGO_GRADE1] = SOURCE.[CODIGO_GRADE1],
			                           TARGET.[CODIGO_GRADE2] = SOURCE.[CODIGO_GRADE2],
			                           TARGET.[UNIDADE] = SOURCE.[UNIDADE],
			                           TARGET.[ATIVO] = SOURCE.[ATIVO],
			                           TARGET.[CODIGO_CLASSIFICACAO] = SOURCE.[CODIGO_CLASSIFICACAO],
			                           TARGET.[DT_CADASTRO] = SOURCE.[DT_CADASTRO],
			                           TARGET.[OBSERVACAO] = SOURCE.[OBSERVACAO],
			                           TARGET.[COD_FORNECEDOR] = SOURCE.[COD_FORNECEDOR],
			                           TARGET.[DT_UPDATE] = SOURCE.[DT_UPDATE],
			                           TARGET.[ALTURA_PARA_FRETE] = SOURCE.[ALTURA_PARA_FRETE],
			                           TARGET.[LARGURA_PARA_FRETE] = SOURCE.[LARGURA_PARA_FRETE],
			                           TARGET.[COMPRIMENTO_PARA_FRETE] = SOURCE.[COMPRIMENTO_PARA_FRETE],
			                           TARGET.[TIMESTAMP] = SOURCE.[TIMESTAMP],
			                           TARGET.[PESO_BRUTO] = SOURCE.[PESO_BRUTO],
			                           TARGET.[PORTAL] = SOURCE.[PORTAL],
			                           TARGET.[DESCRICAO_COMPLETA_COMMERCE] = SOURCE.[DESCRICAO_COMPLETA_COMMERCE],
			                           TARGET.[CANAIS_ECOMMERCE_PUBLICADOS] = SOURCE.[CANAIS_ECOMMERCE_PUBLICADOS],
			                           TARGET.[INICIO_PUBLICACAO_PRODUTO] = SOURCE.[INICIO_PUBLICACAO_PRODUTO],
			                           TARGET.[FIM_PUBLICACAO_PRODUTO] = SOURCE.[FIM_PUBLICACAO_PRODUTO],
			                           TARGET.[CODIGO_INTEGRACAO_OMS] = SOURCE.[CODIGO_INTEGRACAO_OMS]

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGOPRODUTO] NOT IN (SELECT [CODIGOPRODUTO] FROM [LINX_MICROVIX_COMMERCE].[dbo].[B2CCONSULTAPRODUTOS]) THEN
			                           INSERT
			                           ([LASTUPDATEON], [CODIGOPRODUTO], [REFERENCIA], [CODAUXILIAR1], [DESCRICAO_BASICA], [NOME_PRODUTO], [PESO_LIQUIDO], [CODIGO_SETOR], [CODIGO_LINHA], [CODIGO_MARCA], [CODIGO_COLECAO], [CODIGO_ESPESSURA], [CODIGO_GRADE1], [CODIGO_GRADE2], [UNIDADE], [ATIVO], [CODIGO_CLASSIFICACAO], [DT_CADASTRO], 
			                           [OBSERVACAO], [COD_FORNECEDOR], [DT_UPDATE], [ALTURA_PARA_FRETE], [LARGURA_PARA_FRETE], [COMPRIMENTO_PARA_FRETE], [TIMESTAMP], [PESO_BRUTO], [PORTAL], [DESCRICAO_COMPLETA_COMMERCE], [CANAIS_ECOMMERCE_PUBLICADOS], [INICIO_PUBLICACAO_PRODUTO], [FIM_PUBLICACAO_PRODUTO], [CODIGO_INTEGRACAO_OMS])
			                           VALUES
			                           (SOURCE.[LASTUPDATEON], SOURCE.[CODIGOPRODUTO], SOURCE.[REFERENCIA], SOURCE.[CODAUXILIAR1], SOURCE.[DESCRICAO_BASICA], SOURCE.[NOME_PRODUTO], SOURCE.[PESO_LIQUIDO], SOURCE.[CODIGO_SETOR], SOURCE.[CODIGO_LINHA], SOURCE.[CODIGO_MARCA], SOURCE.[CODIGO_COLECAO],
			                           SOURCE.[CODIGO_ESPESSURA], SOURCE.[CODIGO_GRADE1], SOURCE.[CODIGO_GRADE2], SOURCE.[UNIDADE], SOURCE.[ATIVO], SOURCE.[CODIGO_CLASSIFICACAO], SOURCE.[DT_CADASTRO], SOURCE.[OBSERVACAO], SOURCE.[COD_FORNECEDOR], SOURCE.[DT_UPDATE], SOURCE.[ALTURA_PARA_FRETE], SOURCE.[LARGURA_PARA_FRETE], SOURCE.[COMPRIMENTO_PARA_FRETE], SOURCE.[TIMESTAMP], SOURCE.[PESO_BRUTO], SOURCE.[PORTAL], SOURCE.[DESCRICAO_COMPLETA_COMMERCE],
			                           SOURCE.[CANAIS_ECOMMERCE_PUBLICADOS], SOURCE.[INICIO_PUBLICACAO_PRODUTO], SOURCE.[FIM_PUBLICACAO_PRODUTO], SOURCE.[CODIGO_INTEGRACAO_OMS]);
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
                                                <Parameter id=""dt_cadastro_inicial"">[dt_cadastro_inicial]</Parameter>
                                                <Parameter id=""dt_cadastro_fim"">[dt_cadastro_fim]</Parameter>",
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
