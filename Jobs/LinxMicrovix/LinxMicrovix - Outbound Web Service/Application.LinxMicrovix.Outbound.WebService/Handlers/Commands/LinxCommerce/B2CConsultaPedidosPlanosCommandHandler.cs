using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPedidosPlanosCommandHandler : IB2CConsultaPedidosPlanosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPedidosPlanos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_pedido_planos}'"));
            return $"SELECT CONCAT('[', ID_PEDIDO_PLANOS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSPLANOS] WHERE ID_PEDIDO_PLANOS IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [id_pedido_planos], [id_pedido], [plano_pagamento], [valor_plano], [nsu_sitef], [cod_autorizacao], [texto_comprovante], [cod_loja_sitef], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_pedido_planos, @id_pedido, @plano_pagamento, @valor_plano, @nsu_sitef, @cod_autorizacao, @texto_comprovante, @cod_loja_sitef, @timestamp, @portal)";
        }
    }
}
