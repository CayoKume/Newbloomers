using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxMicrovix
{
    public class LinxB2CPedidosRepository : ILinxB2CPedidosRepository
    {
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxB2CPedidos> _linxMicrovixRepositoryBase;

        public LinxB2CPedidosRepository(ILinxMicrovixAzureSQLRepositoryBase<LinxB2CPedidos> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<LinxB2CPedidos> records)
        {
            try
            {
                var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new LinxB2CPedidos());

                for (int i = 0; i < records.Count(); i++)
                {
                    table.Rows.Add(records[i].lastupdateon, records[i].id_pedido, records[i].dt_pedido, records[i].cod_cliente_erp, records[i].cod_cliente_b2c, records[i].vl_frete,
                        records[i].forma_pgto, records[i].plano_pagamento, records[i].anotacao, records[i].taxa_impressao, records[i].finalizado, records[i].valor_frete_gratis,
                        records[i].tipo_frete, records[i].id_status, records[i].cod_transportador, records[i].tipo_cobranca_frete, records[i].ativo, records[i].empresa, records[i].id_tabela_preco, records[i].valor_credito,
                        records[i].cod_vendedor, records[i].timestamp, records[i].dt_insert, records[i].dt_disponivel_faturamento, records[i].mensagem_falha_faturamento, records[i].portal, records[i].id_tipo_b2c,
                        records[i].ecommerce_origem, records[i].marketplace_loja, records[i].order_id);
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

        public async Task<List<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<Int32?> registros)
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
                                identificadores += $"'{top1000List[j]}'";
                            else
                                identificadores += $"'{top1000List[j]}', ";
                        }

                        string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', ID_PEDIDO, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', COD_CLIENTE_ERP, ']', '|', '[', ORDER_ID, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidos] WHERE id_pedido IN ({identificadores})";
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
                            identificadores += $"'{registros[i]}'";
                        else
                            identificadores += $"'{registros[i]}', ";
                    }

                    string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', ID_PEDIDO, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', COD_CLIENTE_ERP, ']', '|', '[', ORDER_ID, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidos] WHERE id_pedido IN ({identificadores})";
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

        public async Task<bool> InsertRecord(LinxAPIParam jobParameter, LinxB2CPedidos? record)
        {
            string? sql = @$"INSERT INTO [untreated].[{jobParameter.tableName}]
                            ([lastupdateon],[id_pedido],[dt_pedido],[cod_cliente_erp],[cod_cliente_b2c],[vl_frete],[forma_pgto],[plano_pagamento],[anotacao],[taxa_impressao],[finalizado],
                             [valor_frete_gratis],[tipo_frete],[id_status],[cod_transportador],[tipo_cobranca_frete],[ativo],[empresa],[id_tabela_preco],[valor_credito],[cod_vendedor],
                             [timestamp],[dt_insert],[dt_disponivel_faturamento],[mensagem_falha_faturamento],[portal],[id_tipo_b2c],[ecommerce_origem],[marketplace_loja],[order_id])
                            Values
                            (@lastupdateon,@id_pedido,@dt_pedido,@cod_cliente_erp,@cod_cliente_b2c,@vl_frete,@forma_pgto,@plano_pagamento,@anotacao,@taxa_impressao,@finalizado,@valor_frete_gratis,
                             @tipo_frete,@id_status,@cod_transportador,@tipo_cobranca_frete,@ativo,@empresa,@id_tabela_preco,@valor_credito,@cod_vendedor,@timestamp,@dt_insert,@dt_disponivel_faturamento,
                             @mensagem_falha_faturamento,@portal,@id_tipo_b2c,@ecommerce_origem,@marketplace_loja, @order_id)";

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
