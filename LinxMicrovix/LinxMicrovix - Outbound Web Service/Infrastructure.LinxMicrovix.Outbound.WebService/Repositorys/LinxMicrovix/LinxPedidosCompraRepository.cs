using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
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
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxPedidosCompra());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].portal, records[i].cnpj_emp, records[i].cod_pedido, records[i].data_pedido, records[i].transacao,
                        records[i].usuario, records[i].codigo_fornecedor, records[i].cod_produto, records[i].quantidade, records[i].valor_unitario, records[i].cod_comprador,
                        records[i].valor_frete, records[i].valor_total, records[i].cod_plano_pagamento, records[i].plano_pagamento, records[i].obs, records[i].aprovado, records[i].cancelado, records[i].encerrado,
                        records[i].data_aprovacao, records[i].numero_ped_fornec, records[i].tipo_frete, records[i].natureza_operacao, records[i].previsao_entrega, records[i].numero_projeto_officina, records[i].status_pedido, 
                        records[i].qtde_entregue, records[i].descricao_frete, records[i].integrado_linx, records[i].nf_gerada, records[i].timestamp, records[i].empresa, records[i].nf_origem_ws);
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

        public async Task<List<LinxPedidosCompra>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxPedidosCompra> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].cod_pedido}'";
                    else
                        identificadores += $"'{registros[i].cod_pedido}', ";
                }

                string sql = $"SELECT cnpj_emp, cod_pedido, codigo_fornecedor, cod_produto, TIMESTAMP FROM [linx_microvix_erp].[LinxPedidosCompra] WHERE cod_pedido IN ({identificadores})";

                return await _linxMicrovixRepositoryBase.GetRegistersExists(jobParameter, sql);
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
            string? sql = @$"INSERT INTO {jobParameter.tableName} 
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
                return await _linxMicrovixRepositoryBase.InsertRecord(jobParameter: jobParameter, sql: sql, record: record);
            }
            catch
            {
                throw;
            }
        }
    }
}
