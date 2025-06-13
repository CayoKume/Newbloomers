using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxProdutosRepository : ILinxProdutosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutos> _linxMicrovixRepositoryBase;

        public LinxProdutosRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxProdutos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxProdutos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxProdutos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cod_produto, records[i].cod_barra, records[i].nome, records[i].ncm,
                        records[i].cest, records[i].referencia, records[i].cod_auxiliar, records[i].unidade, records[i].desc_cor, records[i].desc_tamanho,
                        records[i].desc_setor, records[i].desc_linha, records[i].desc_marca, records[i].desc_colecao, records[i].dt_update, records[i].cod_fornecedor,
                        records[i].desativado, records[i].desc_espessura, records[i].id_espessura, records[i].desc_classificacao, records[i].id_classificacao,
                        records[i].origem_mercadoria, records[i].peso_liquido, records[i].peso_bruto, records[i].id_cor, records[i].id_tamanho, records[i].id_setor,
                        records[i].id_linha, records[i].id_marca, records[i].id_colecao, records[i].dt_inclusao, records[i].timestamp, records[i].fator_conversao,
                        records[i].codigo_integracao_ws, records[i].codigo_integracao_reshop, records[i].id_produtos_opticos_tipo, records[i].id_sped_tipo_item,
                        records[i].componente, records[i].altura_para_frete, records[i].largura_para_frete, records[i].comprimento_para_frete, records[i].loja_virtual,
                        records[i].cod_comprador, records[i].obrigatorio_identificacao_cliente, records[i].descricao_basica, records[i].curva);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
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

        public async Task<IEnumerable<string?>> GetProductsSetorIds(LinxAPIParam jobParameter)
        {
            try
            {
                string sql = $"SELECT distinct id_setor FROM [linx_microvix_erp].[LinxSetores]";

                return await _linxMicrovixRepositoryBase.GetParameters(sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int64?> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i]}'";
                    else
                        identificadores += $"'{registros[i]}', ";
                }

                string sql = $"SELECT CONCAT('[', COD_PRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxProdutos] WHERE cod_produto IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
            }
            catch (Exception ex) when (ex is not InternalException && ex is not SQLCommandException)
            {
                throw new InternalException(
                    stage: EnumStages.GetRegistersExists,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: "Error when filling identifiers to sql command",
                    exceptionMessage: ex.Message
                );
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxProdutos? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}] 
                            ([lastupdateon],[portal],[cod_produto],[cod_barra],[nome],[ncm],[cest],[referencia],[cod_auxiliar],[unidade],
                             [desc_cor],[desc_tamanho],[desc_setor],[desc_linha],[desc_marca],[desc_colecao],[dt_update],[cod_fornecedor],[desativado],[desc_espessura],[id_espessura],
                             [desc_classificacao],[id_classificacao],[origem_mercadoria],[peso_liquido],[peso_bruto],[id_cor],[id_tamanho],[id_setor],[id_linha],[id_marca],[id_colecao],
                             [dt_inclusao],[timestamp],[fator_conversao],[codigo_integracao_ws],[codigo_integracao_reshop],[id_produtos_opticos_tipo],[id_sped_tipo_item],[componente],
                             [altura_para_frete],[largura_para_frete],[comprimento_para_frete],[loja_virtual],[cod_comprador],[obrigatorio_identificacao_cliente],[descricao_basica],[curva])
                            Values
                            (@lastupdateon,@portal,@cod_produto,@cod_barra,@nome,@ncm,@cest,@referencia,@cod_auxiliar,@unidade,@desc_cor,@desc_tamanho,@desc_setor,@desc_linha,@desc_marca,
                             @desc_colecao,@dt_update,@cod_fornecedor,@desativado,@desc_espessura,@id_espessura,@desc_classificacao,@id_classificacao,@origem_mercadoria,@peso_liquido,
                             @peso_bruto,@id_cor,@id_tamanho,@id_setor,@id_linha,@id_marca,@id_colecao,@dt_inclusao,@timestamp,@fator_conversao,@codigo_integracao_ws,@codigo_integracao_reshop,
                             @id_produtos_opticos_tipo,@id_sped_tipo_item,@componente,@altura_para_frete,@largura_para_frete,@comprimento_para_frete,@loja_virtual,@cod_comprador,@obrigatorio_identificacao_cliente,
                             @descricao_basica,@curva)";

            try
            {
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter.tableName, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
