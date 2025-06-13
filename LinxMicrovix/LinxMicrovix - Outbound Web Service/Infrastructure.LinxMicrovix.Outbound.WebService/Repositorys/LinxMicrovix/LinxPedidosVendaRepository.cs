using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPedidosVendaRepository : ILinxPedidosVendaRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxPedidosVenda> _linxMicrovixRepositoryBase;

        public LinxPedidosVendaRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxPedidosVenda> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosVenda> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxPedidosVenda());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_pedido, records[i].data_lancamento, records[i].hora_lancamento,
                        records[i].transacao, records[i].usuario, records[i].codigo_cliente, records[i].cod_produto, records[i].quantidade, records[i].valor_unitario,
                        records[i].cod_vendedor, records[i].valor_frete, records[i].valor_total, records[i].desconto_item, records[i].cod_plano_pagamento, records[i].plano_pagamento, records[i].obs, records[i].aprovado,
                        records[i].cancelado, records[i].data_aprovacao, records[i].data_alteracao, records[i].tipo_frete, records[i].natureza_operacao, records[i].tabela_preco, records[i].nome_tabela_preco, records[i].previsao_entrega,
                        records[i].realizado_por, records[i].pontuacao_ser, records[i].venda_externa, records[i].nf_gerada, records[i].status, records[i].numero_projeto_officina, records[i].cod_natureza_operacao, records[i].margem_contribuicao,
                        records[i].doc_origem, records[i].posicao_item, records[i].orcamento_origem, records[i].transacao_origem, records[i].timestamp, records[i].desconto, records[i].transacao_ws, records[i].empresa, records[i].transportador, records[i].deposito);
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

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 1)
                {
                    var list = new List<string>();

                    for (int i = 0; i <= indice; i++)
                    {
                        string identificadores = String.Empty;
                        var top1000List = registros.Skip(i * 1000).Take(1000).ToList();

                        for (int j = 0; j < top1000List.Count(); j++)
                        {

                            if (j == top1000List.Count() - 1)
                                identificadores += $"'{top1000List[j]}'";
                            else
                                identificadores += $"'{top1000List[j]}', ";
                        }

                        string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', COD_PEDIDO, ']', '|', '[', COD_PRODUTO, ']', '|', '[', CODIGO_CLIENTE, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxPedidosVenda] WHERE COD_PEDIDO IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<string>();
                    var identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {
                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i]}'";
                        else
                            identificadores += $"'{registros[i]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', COD_PEDIDO, ']', '|', '[', COD_PRODUTO, ']', '|', '[', CODIGO_CLIENTE, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxPedidosVenda] WHERE COD_PEDIDO IN ({identificadores})";
                    var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                    list.AddRange(result);

                    return list;
                }
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosVenda? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[portal],[cnpj_emp],[cod_pedido],[data_lancamento],[hora_lancamento],[transacao],[usuario],[codigo_cliente],[cod_produto],[quantidade],
                             [valor_unitario],[cod_vendedor],[valor_frete],[valor_total],[desconto_item],[cod_plano_pagamento],[plano_pagamento],[obs],[aprovado],[cancelado],[data_aprovacao],
                             [data_alteracao],[tipo_frete],[natureza_operacao],[tabela_preco],[nome_tabela_preco],[previsao_entrega],[realizado_por],[pontuacao_ser],[venda_externa],
                             [nf_gerada],[status],[numero_projeto_officina],[cod_natureza_operacao],[margem_contribuicao],[doc_origem],[posicao_item],[orcamento_origem],[transacao_origem],
                             [timestamp],[desconto],[transacao_ws],[empresa],[transportador],[deposito])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_pedido,@data_lancamento,@hora_lancamento,@transacao,@usuario,@codigo_cliente,@cod_produto,@quantidade,@valor_unitario,@cod_vendedor,
                             @valor_frete,@valor_total,@desconto_item,@cod_plano_pagamento,@plano_pagamento,@obs,@aprovado,@cancelado,@data_aprovacao,@data_alteracao,@tipo_frete,@natureza_operacao,
                             @tabela_preco,@nome_tabela_preco,@previsao_entrega,@realizado_por,@pontuacao_ser,@venda_externa,@nf_gerada,@status,@numero_projeto_officina,@cod_natureza_operacao,
                             @margem_contribuicao,@doc_origem,@posicao_item,@orcamento_origem,@transacao_origem,@timestamp,@desconto,@transacao_ws,@empresa,@transportador,@deposito)";

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
