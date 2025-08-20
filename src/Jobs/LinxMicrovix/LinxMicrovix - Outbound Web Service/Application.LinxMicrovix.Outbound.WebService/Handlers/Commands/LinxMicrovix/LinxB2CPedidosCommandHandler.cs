using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class LinxB2CPedidosCommandHandler : ILinxB2CPedidosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<int?> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', ID_PEDIDO, ']', '|', '[', COD_CLIENTE_B2C, ']', '|', '[', COD_CLIENTE_ERP, ']', '|', '[', ORDER_ID, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxB2CPedidos] WHERE id_pedido IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}]
                            ([lastupdateon],[id_pedido],[dt_pedido],[cod_cliente_erp],[cod_cliente_b2c],[vl_frete],[forma_pgto],[plano_pagamento],[anotacao],[taxa_impressao],[finalizado],
                             [valor_frete_gratis],[tipo_frete],[id_status],[cod_transportador],[tipo_cobranca_frete],[ativo],[empresa],[id_tabela_preco],[valor_credito],[cod_vendedor],
                             [timestamp],[dt_insert],[dt_disponivel_faturamento],[mensagem_falha_faturamento],[portal],[id_tipo_b2c],[ecommerce_origem],[marketplace_loja],[order_id])
                            Values
                            (@lastupdateon,@id_pedido,@dt_pedido,@cod_cliente_erp,@cod_cliente_b2c,@vl_frete,@forma_pgto,@plano_pagamento,@anotacao,@taxa_impressao,@finalizado,@valor_frete_gratis,
                             @tipo_frete,@id_status,@cod_transportador,@tipo_cobranca_frete,@ativo,@empresa,@id_tabela_preco,@valor_credito,@cod_vendedor,@timestamp,@dt_insert,@dt_disponivel_faturamento,
                             @mensagem_falha_faturamento,@portal,@id_tipo_b2c,@ecommerce_origem,@marketplace_loja, @order_id)";
        }
    }
}
