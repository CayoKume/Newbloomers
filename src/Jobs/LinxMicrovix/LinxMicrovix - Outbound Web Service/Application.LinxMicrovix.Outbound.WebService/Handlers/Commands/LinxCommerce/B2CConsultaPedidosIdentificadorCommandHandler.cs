using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorCommandHandler : IB2CConsultaPedidosIdentificadorCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPedidosIdentificador> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.identificador}'"));
            return $"SELECT CONCAT('[', IDENTIFICADOR, ']', '|', '[', [TIMESTAMP], ']') FROM linx_microvix_commerce.B2CCONSULTAPEDIDOSIDENTIFICADOR WHERE IDENTIFICADOR IN ({identificadores})";
        }

        public string CreateInsertRecordQuery(string tableName)
        {
            return @$"INSERT INTO {tableName} 
                          ([lastupdateon], [portal], [empresa], [identificador], [id_venda], [order_id], [id_cliente], [valor_frete], [data_origem], [timestamp]) 
                          Values 
                          (@lastupdateon, @portal, @empresa, @identificador, @id_venda, @order_id, @id_cliente, @valor_frete, @data_origem, @timestamp)";
        }
    }
}
