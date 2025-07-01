using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxPedidosCompraRepository : ILinxPedidosCompraRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxPedidosCompra> _linxMicrovixRepositoryBase;

        public LinxPedidosCompraRepository(ILinxMicrovixRepositoryBase<LinxPedidosCompra> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxPedidosCompra> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxPedidosCompra());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_pedido, records[i].data_pedido, records[i].transacao,
                        records[i].usuario, records[i].codigo_fornecedor, records[i].cod_produto, records[i].quantidade, records[i].valor_unitario, records[i].cod_comprador,
                        records[i].valor_frete, records[i].valor_total, records[i].cod_plano_pagamento, records[i].plano_pagamento, records[i].obs, records[i].aprovado, records[i].cancelado, records[i].encerrado,
                        records[i].data_aprovacao, records[i].numero_ped_fornec, records[i].tipo_frete, records[i].natureza_operacao, records[i].previsao_entrega, records[i].numero_projeto_officina, records[i].status_pedido,
                        records[i].qtde_entregue, records[i].descricao_frete, records[i].integrado_linx, records[i].nf_gerada, records[i].timestamp, records[i].empresa, records[i].nf_origem_ws);
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

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<int?> registros)
        {
            try
            {
                int indice = registros.Count() / 1000;

                if (indice > 0)
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

                        string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', COD_PEDIDO, ']', '|', '[', CODIGO_FORNECEDOR, ']', '|', '[', COD_PRODUTO, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxPedidosCompra] WHERE COD_PEDIDO IN ({identificadores})";
                        var result = await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
                        list.AddRange(result);
                    }

                    return list;
                }
                else
                {
                    var list = new List<string>();
                    string identificadores = String.Empty;

                    for (int i = 0; i < registros.Count(); i++)
                    {

                        if (i == registros.Count() - 1)
                            identificadores += $"'{registros[i]}'";
                        else
                            identificadores += $"'{registros[i]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', CNPJ_EMP, ']', '|', '[', COD_PEDIDO, ']', '|', '[', CODIGO_FORNECEDOR, ']', '|', '[', COD_PRODUTO, ']', '|',  '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxPedidosCompra] WHERE COD_PEDIDO IN ({identificadores})";
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxPedidosCompra? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[portal],[cnpj_emp],[cod_pedido],[data_pedido],[transacao],[usuario],[codigo_fornecedor],[cod_produto],[quantidade],[valor_unitario],
                             [cod_comprador],[valor_frete],[valor_total],[cod_plano_pagamento],[plano_pagamento],[obs],[aprovado],[cancelado],[encerrado],[data_aprovacao],
                             [numero_ped_fornec],[tipo_frete],[natureza_operacao],[previsao_entrega],[numero_projeto_officina],[status_pedido],[qtde_entregue],[descricao_frete],
                             [integrado_linx],[nf_gerada],[timestamp],[empresa],[nf_origem_ws])
                            Values
                            (@lastupdateon,@portal,@cnpj_emp,@cod_pedido,@data_pedido,@transacao,@usuario,@codigo_fornecedor,@cod_produto,@quantidade,@valor_unitario,@cod_comprador,
                             @valor_frete,@valor_total,@cod_plano_pagamento,@plano_pagamento,@obs,@aprovado,@cancelado,@encerrado,@data_aprovacao,@numero_ped_fornec,@tipo_frete,
                             @natureza_operacao,@previsao_entrega,@numero_projeto_officina,@status_pedido,@qtde_entregue,@descricao_frete,@integrado_linx,@nf_gerada,@timestamp,
                             @empresa,@nf_origem_ws)";

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
