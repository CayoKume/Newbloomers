using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaPedidosRepository : IB2CConsultaPedidosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaPedidos> _linxMicrovixRepositoryBase;

        public B2CConsultaPedidosRepository(ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaPedidos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaPedidos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaPedidos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].dt_pedido, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].vl_frete, records[i].forma_pgto, records[i].plano_pagamento,
                        records[i].anotacao, records[i].taxa_impressao, records[i].finalizado, records[i].valor_frete_gratis, records[i].tipo_frete, records[i].id_status, records[i].cod_transportador, records[i].tipo_cobranca_frete,
                        records[i].ativo, records[i].empresa, records[i].id_tabela_preco, records[i].valor_credito, records[i].cod_vendedor, records[i].timestamp, records[i].dt_insert, records[i].dt_disponivel_faturamento, records[i].portal,
                        records[i].mensagem_falha_faturamento, records[i].id_tipo_b2c, records[i].ecommerce_origem, records[i].order_id);
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
                var identificadores = String.Empty;
                for (int i = 0; i < registros.Count(); i++)
                {
                    if (i == registros.Count() - 1)
                        identificadores += $"'{registros[i]}'";
                    else
                        identificadores += $"'{registros[i]}', ";
                }

                string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', ID_PEDIDO, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', COD_CLIENTE_ERP, ']', '|', '[', ORDER_ID, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOS] WHERE ID_PEDIDO IN ({identificadores})";

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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, B2CConsultaPedidos? record)
        {
            string? sql = $"INSERT INTO [untreated].{jobParameter.tableName} " +
                          "([lastupdateon], [id_pedido], [dt_pedido], [cod_cliente_erp], [cod_cliente_b2c], [vl_frete], [forma_pgto], [plano_pagamento], [anotacao], [taxa_impressao], [finalizado], [valor_frete_gratis], [tipo_frete], " +
                          "[id_status], [cod_transportador], [tipo_cobranca_frete], [ativo], [empresa], [id_tabela_preco], [valor_credito], [cod_vendedor], [timestamp], [dt_insert], [dt_disponivel_faturamento], [portal], " +
                          "[mensagem_falha_faturamento], [id_tipo_b2c], [ecommerce_origem], [order_id]) " +
                          "Values " +
                          "(@lastupdateon, @id_pedido, @dt_pedido, @cod_cliente_erp, @cod_cliente_b2c, @vl_frete, @forma_pgto, @plano_pagamento, @anotacao, @taxa_impressao, @finalizado, @valor_frete_gratis, @tipo_frete, @id_status, " +
                          "@cod_transportador, @tipo_cobranca_frete, @ativo, @empresa, @id_tabela_preco, @valor_credito, @cod_vendedor, @timestamp, @dt_insert, @dt_disponivel_faturamento, @portal, @mensagem_falha_faturamento, @id_tipo_b2c, " +
                          "@ecommerce_origem, @order_id)";

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
