using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPedidosItensCommandHandler : IB2CConsultaPedidosItensCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<long?> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', ID_PEDIDO, ']', '|', '[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSITENS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO [untreated].[{tableName}] 
                          ([lastupdateon], [id_pedido_item], [id_pedido], [codigoproduto], [quantidade], [vl_unitario], [timestamp], [portal]) 
                          Values 
                          (@lastupdateon, @id_pedido_item, @id_pedido, @codigoproduto, @quantidade, @vl_unitario, @timestamp, @portal)";
        }
    }
}
