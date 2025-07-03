using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxMovimentoRepository : ILinxMovimentoRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxMovimento> _linxMicrovixRepositoryBase;

        public LinxMovimentoRepository(ILinxMicrovixRepositoryBase<LinxMovimento> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxMovimento> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxMovimento());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].transacao, records[i].usuario, records[i].documento,
                        records[i].chave_nf, records[i].ecf, records[i].numero_serie_ecf, records[i].modelo_nf, records[i].data_documento, records[i].data_lancamento,
                        records[i].codigo_cliente, records[i].serie, records[i].desc_cfop, records[i].id_cfop, records[i].cod_vendedor, records[i].quantidade, records[i].preco_custo,
                        records[i].valor_liquido, records[i].desconto, records[i].cst_icms, records[i].cst_pis, records[i].cst_cofins, records[i].cst_ipi, records[i].valor_icms,
                        records[i].aliquota_icms, records[i].base_icms, records[i].valor_pis, records[i].aliquota_pis, records[i].base_pis, records[i].valor_cofins, records[i].aliquota_cofins,
                        records[i].base_cofins, records[i].valor_icms_st, records[i].aliquota_icms_st, records[i].base_icms_st, records[i].valor_ipi, records[i].aliquota_ipi, records[i].base_ipi,
                        records[i].valor_total, records[i].forma_dinheiro, records[i].total_dinheiro, records[i].forma_cheque, records[i].total_cheque, records[i].forma_cartao, records[i].total_cartao,
                        records[i].forma_crediario, records[i].total_crediario, records[i].forma_convenio, records[i].total_convenio, records[i].frete, records[i].operacao, records[i].tipo_transacao,
                        records[i].cod_produto, records[i].cod_barra, records[i].cancelado, records[i].excluido, records[i].soma_relatorio, records[i].identificador, records[i].deposito, records[i].obs,
                        records[i].preco_unitario, records[i].hora_lancamento, records[i].natureza_operacao, records[i].tabela_preco, records[i].nome_tabela_preco, records[i].cod_sefaz_situacao,
                        records[i].desc_sefaz_situacao, records[i].protocolo_aut_nfe, records[i].dt_update, records[i].forma_cheque_prazo, records[i].total_cheque_prazo, records[i].cod_natureza_operacao,
                        records[i].preco_tabela_epoca, records[i].desconto_total_item, records[i].conferido, records[i].transacao_pedido_venda, records[i].codigo_modelo_nf, records[i].acrescimo,
                        records[i].mob_checkout, records[i].aliquota_iss, records[i].base_iss, records[i].ordem, records[i].codigo_rotina_origem, records[i].timestamp, records[i].troco, records[i].transportador,
                        records[i].icms_aliquota_desonerado, records[i].icms_valor_desonerado_item, records[i].empresa, records[i].desconto_item, records[i].aliq_iss, records[i].iss_base_item, records[i].despesas,
                        records[i].seguro_total_item, records[i].acrescimo_total_item, records[i].despesas_total_item, records[i].forma_pix, records[i].total_pix, records[i].forma_deposito_bancario,
                        records[i].total_deposito_bancario, records[i].id_venda_produto_b2c, records[i].item_promocional, records[i].acrescimo_item, records[i].icms_st_antecipado_aliquota, records[i].icms_st_antecipado_margem,
                        records[i].icms_st_antecipado_percentual_reducao, records[i].icms_st_antecipado_valor_item, records[i].icms_base_desonerado_item, records[i].codigo_status_nfe);
                }

                _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                     dataTable: table
                 );

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxMovimento> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<string?>();

                    for (int i = 0; i <= indice; i++)
                    {
                        string identificadores = String.Empty;
                        var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                        for (int j = 0; j < top1000List.Count(); j++)
                        {

                            if (j == top1000List.Count() - 1)
                                identificadores += $"'{top1000List[j].identificador}'";
                            else
                                identificadores += $"'{top1000List[j].identificador}', ";
                        }

                        string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', DOCUMENTO, ']', '|', '[', DATA_DOCUMENTO, ']', '|', '[', CODIGO_CLIENTE, ']', '|', '[', COD_PRODUTO, ']', '|', '[', CANCELADO, ']', '|', '[', EXCLUIDO, ']', '|', '[', TRANSACAO_PEDIDO_VENDA, ']', '|', '[', ORDEM, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxMovimento] WHERE identificador IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<string?>();
                    string identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {

                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i].identificador}'";
                        else
                            identificadores += $"'{registros[i].identificador}', ";
                    }

                    string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', DOCUMENTO, ']', '|', '[', DATA_DOCUMENTO, ']', '|', '[', CODIGO_CLIENTE, ']', '|', '[', COD_PRODUTO, ']', '|', '[', CANCELADO, ']', '|', '[', EXCLUIDO, ']', '|', '[', TRANSACAO_PEDIDO_VENDA, ']', '|', '[', ORDEM, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxMovimento] WHERE identificador IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                    list.AddRange(result);

                    return list;
                }
            }
            catch (Exception ex) when (ex is not GeneralException && ex is not SQLCommandException)
            {
                throw new GeneralException(
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxMovimento? record)
        {
            string? sql = @$"INSERT INTO [untreated].{jobParameter.tableName} 
                            ([lastupdateon],[portal],[cnpj_emp],[transacao],[usuario],[documento],[chave_nf],[ecf],[numero_serie_ecf],[modelo_nf],[data_documento],[data_lancamento],
                             [codigo_cliente],[serie],[desc_cfop],[id_cfop],[cod_vendedor],[quantidade],[preco_custo],[valor_liquido],[desconto],[cst_icms],[cst_pis],[cst_cofins],
                             [cst_ipi],[valor_icms],[aliquota_icms],[base_icms],[valor_pis],[aliquota_pis],[base_pis],[valor_cofins],[aliquota_cofins],[base_cofins],[valor_icms_st],
                             [aliquota_icms_st],[base_icms_st],[valor_ipi],[aliquota_ipi],[base_ipi],[valor_total],[forma_dinheiro],[total_dinheiro],[forma_cheque],[total_cheque],
                             [forma_cartao],[total_cartao],[forma_crediario],[total_crediario],[forma_convenio],[total_convenio],[frete],[operacao],[tipo_transacao],[cod_produto],
                             [cod_barra],[cancelado],[excluido],[soma_relatorio],[identificador],[deposito],[obs],[preco_unitario],[hora_lancamento],[natureza_operacao],[tabela_preco],
                             [nome_tabela_preco],[cod_sefaz_situacao],[desc_sefaz_situacao],[protocolo_aut_nfe],[dt_update],[forma_cheque_prazo],[total_cheque_prazo],[cod_natureza_operacao],
                             [preco_tabela_epoca],[desconto_total_item],[conferido],[transacao_pedido_venda],[codigo_modelo_nf],[acrescimo],[mob_checkout],[aliquota_iss],[base_iss],
                             [ordem],[codigo_rotina_origem],[timestamp],[troco],[transportador],[icms_aliquota_desonerado],[icms_valor_desonerado_item],[empresa],[desconto_item],
                             [aliq_iss],[iss_base_item],[despesas],[seguro_total_item],[acrescimo_total_item],[despesas_total_item],[forma_pix],[total_pix],[forma_deposito_bancario],
                             [total_deposito_bancario],[id_venda_produto_b2c],[item_promocional],[acrescimo_item],[icms_st_antecipado_aliquota],[icms_st_antecipado_margem],[icms_st_antecipado_percentual_reducao],
                             [icms_st_antecipado_valor_item],[icms_base_desonerado_item],[codigo_status_nfe])
                           Values
                            (@lastupdateon,@portal,@cnpj_emp,@transacao,@usuario,@documento,@chave_nf,@ecf,@numero_serie_ecf,@modelo_nf,@data_documento,@data_lancamento,@codigo_cliente,@serie,
                             @desc_cfop,@id_cfop,@cod_vendedor,@quantidade,@preco_custo,@valor_liquido,@desconto,@cst_icms,@cst_pis,@cst_cofins,@cst_ipi,@valor_icms,@aliquota_icms,@base_icms,
                             @valor_pis,@aliquota_pis,@base_pis,@valor_cofins,@aliquota_cofins,@base_cofins,@valor_icms_st,@aliquota_icms_st,@base_icms_st,@valor_ipi,@aliquota_ipi,@base_ipi,
                             @valor_total,@forma_dinheiro,@total_dinheiro,@forma_cheque,@total_cheque,@forma_cartao,@total_cartao,@forma_crediario,@total_crediario,@forma_convenio,@total_convenio,
                             @frete,@operacao,@tipo_transacao,@cod_produto,@cod_barra,@cancelado,@excluido,@soma_relatorio,@identificador,@deposito,@obs,@preco_unitario,@hora_lancamento,@natureza_operacao,
                             @tabela_preco,@nome_tabela_preco,@cod_sefaz_situacao,@desc_sefaz_situacao,@protocolo_aut_nfe,@dt_update,@forma_cheque_prazo,@total_cheque_prazo,@cod_natureza_operacao,
                             @preco_tabela_epoca,@desconto_total_item,@conferido,@transacao_pedido_venda,@codigo_modelo_nf,@acrescimo,@mob_checkout,@aliquota_iss,@base_iss,@ordem,@codigo_rotina_origem,
                             @timestamp,@troco,@transportador,@icms_aliquota_desonerado,@icms_valor_desonerado_item,@empresa,@desconto_item,@aliq_iss,@iss_base_item,@despesas,@seguro_total_item,@acrescimo_total_item,
                             @despesas_total_item,@forma_pix,@total_pix,@forma_deposito_bancario,@total_deposito_bancario,@id_venda_produto_b2c,@item_promocional,@acrescimo_item,
                             @icms_st_antecipado_aliquota,@icms_st_antecipado_margem,@icms_st_antecipado_percentual_reducao,@icms_st_antecipado_valor_item,@icms_base_desonerado_item,@codigo_status_nfe)";

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
