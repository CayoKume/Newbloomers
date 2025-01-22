using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;

namespace Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix
{
    public class LinxB2CPedidosRepository : ILinxB2CPedidosRepository
    {
        private readonly ILinxMicrovixRepositoryBase<LinxB2CPedidos> _linxMicrovixRepositoryBase;

        public LinxB2CPedidosRepository(ILinxMicrovixRepositoryBase<LinxB2CPedidos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter, new LinxB2CPedidos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].dt_pedido, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].vl_frete,
                        records[i].forma_pgto, records[i].plano_pagamento, records[i].anotacao, records[i].taxa_impressao, records[i].finalizado, records[i].valor_frete_gratis,
                        records[i].tipo_frete, records[i].id_status, records[i].cod_transportador, records[i].tipo_cobranca_frete, records[i].ativo, records[i].empresa, records[i].id_tabela_preco, records[i].valor_credito,
                        records[i].cod_vendedor, records[i].timestamp, records[i].dt_insert, records[i].dt_disponivel_faturamento, records[i].mensagem_falha_faturamento, records[i].portal, records[i].id_tipo_b2c, 
                        records[i].ecommerce_origem, records[i].marketplace_loja, records[i].order_id);
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

        public async Task<List<LinxB2CPedidos>> GetRegistersExists(LinxAPIParam jobParameter, List<LinxB2CPedidos> registros)
        {
            try
            {
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i].id_pedido}'";
                    else
                        identificadores += $"'{registros[i].id_pedido}', ";
                }

                string sql = $"SELECT id_pedido, cod_cliente_erp, cod_cliente_b2c, order_id, TIMESTAMP FROM [linx_microvix_erp].[LinxB2CPedidos] WHERE id_pedido IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidos? record)
        {
            string? sql = @$"INSERT INTO {jobParameter.tableName} 
                            ([lastupdateon],[id_pedido],[dt_pedido],[cod_cliente_erp],[cod_cliente_b2c],[vl_frete],[forma_pgto],[plano_pagamento],[anotacao],[taxa_impressao],[finalizado],
                             [valor_frete_gratis],[tipo_frete],[id_status],[cod_transportador],[tipo_cobranca_frete],[ativo],[empresa],[id_tabela_preco],[valor_credito],[cod_vendedor],
                             [timestamp],[dt_insert],[dt_disponivel_faturamento],[mensagem_falha_faturamento],[portal],[id_tipo_b2c],[ecommerce_origem],[marketplace_loja],[order_id])
                            Values
                            (@lastupdateon,@id_pedido,@dt_pedido,@cod_cliente_erp,@cod_cliente_b2c,@vl_frete,@forma_pgto,@plano_pagamento,@anotacao,@taxa_impressao,@finalizado,@valor_frete_gratis,
                             @tipo_frete,@id_status,@cod_transportador,@tipo_cobranca_frete,@ativo,@empresa,@id_tabela_preco,@valor_credito,@cod_vendedor,@timestamp,@dt_insert,@dt_disponivel_faturamento,
                             @mensagem_falha_faturamento,@portal,@id_tipo_b2c,@ecommerce_origem,@marketplace_loja, @order_id)";

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
