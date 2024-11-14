using Domain.IntegrationsCore.Entities.Parameters;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce
{
    public class B2CConsultaProdutosRepository : IB2CConsultaProdutosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutos> _linxMicrovixRepositoryBase;

        public B2CConsultaProdutosRepository(ILinxMicrovixRepositoryBase<B2CConsultaProdutos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxMicrovixJobParameter jobParameter, List<B2CConsultaProdutos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new B2CConsultaProdutos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].codigoproduto, records[i].referencia, records[i].codauxiliar1, records[i].descricao_basica, records[i].nome_produto, records[i].peso_liquido, records[i].codigo_setor,
                        records[i].codigo_linha, records[i].codigo_marca, records[i].codigo_colecao, records[i].codigo_espessura, records[i].codigo_grade1, records[i].codigo_grade2, records[i].unidade, records[i].ativo, records[i].codigo_classificacao, 
                        records[i].dt_cadastro, records[i].observacao, records[i].cod_fornecedor, records[i].dt_update, records[i].altura_para_frete, records[i].largura_para_frete, records[i].comprimento_para_frete, records[i].timestamp, records[i].peso_bruto, 
                        records[i].portal, records[i].descricao_completa_commerce, records[i].canais_ecommerce_publicados, records[i].inicio_publicacao_produto, records[i].fim_publicacao_produto, records[i].codigo_integracao_oms);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                    jobParameter: jobParameter,
                    dataTable: table,
                    dataTableRowsNumber: table.Rows.Count
                );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateTableMerge(LinxMicrovixJobParameter jobParameter)
        {
            string? sql = @"IF NOT EXISTS (SELECT * FROM SYS.OBJECTS WHERE TYPE = 'P' AND NAME = 'P_B2CCONSULTAPRODUTOS_SYNC')
                           BEGIN
                           EXECUTE (
	                           'CREATE PROCEDURE [P_B2CCONSULTAPRODUTOS_SYNC] AS
	                           BEGIN
		                           MERGE [B2CCONSULTAPRODUTOS_TRUSTED] AS TARGET
                                   USING [B2CCONSULTAPRODUTOS_RAW] AS SOURCE

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

                                   WHEN NOT MATCHED BY TARGET AND SOURCE.[CODIGOPRODUTO] NOT IN (SELECT [CODIGOPRODUTO] FROM [B2CCONSULTAPRODUTOS_TRUSTED]) THEN
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
                return await _linxMicrovixRepositoryBase.ExecuteQueryCommand(jobParameter: jobParameter, sql: sql);
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
                return await _linxMicrovixRepositoryBase.InsertParametersIfNotExists(
                    jobParameter: jobParameter,
                    parameter: new
                    {
                        method = jobParameter.jobName,
                        parameters_timestamp = @"<Parameter id=""timestamp"">[0]</Parameter>",
                        parameters_dateinterval = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                    <Parameter id=""dt_cadastro_inicial"">[dt_cadastro_inicial]</Parameter>
                                                    <Parameter id=""dt_cadastro_fim"">[dt_cadastro_fim]</Parameter>",
                        parameters_individual = @"<Parameter id=""timestamp"">[0]</Parameter>
                                                  <Parameter id=""codigoproduto"">[codigoproduto]</Parameter>",
                        ativo = 1
                    }
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxMicrovixJobParameter jobParameter, B2CConsultaProdutos? record)
        {
            string? sql = $"INSERT INTO {jobParameter.tableName}_raw " +
                          "([lastupdateon], [codigoproduto], [referencia], [codauxiliar1], [descricao_basica], [nome_produto], [peso_liquido], [codigo_setor], [codigo_linha], [codigo_marca], [codigo_colecao], [codigo_espessura], [codigo_grade1], [codigo_grade2], [unidade], [ativo], [codigo_classificacao], [dt_cadastro], [observacao], [cod_fornecedor], [dt_update], [altura_para_frete], [largura_para_frete], [comprimento_para_frete], [timestamp], [peso_bruto], [portal], [descricao_completa_commerce], [canais_ecommerce_publicados], [inicio_publicacao_produto], [fim_publicacao_produto], [codigo_integracao_oms]) " +
                          "Values " +
                          "(@lastupdateon, @codigoproduto, @referencia, @codauxiliar1, @descricao_basica, @nome_produto, @peso_liquido, @codigo_setor, @codigo_linha, @codigo_marca, @codigo_colecao, @codigo_espessura, @codigo_grade1, @codigo_grade2, @unidade, @ativo, @codigo_classificacao, @dt_cadastro, @observacao, @cod_fornecedor, @dt_update, @altura_para_frete, @largura_para_frete, @comprimento_para_frete, @timestamp, @peso_bruto, @portal, @descricao_completa_commerce, @canais_ecommerce_publicados, @inicio_publicacao_produto, @fim_publicacao_produto, @codigo_integracao_oms)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
