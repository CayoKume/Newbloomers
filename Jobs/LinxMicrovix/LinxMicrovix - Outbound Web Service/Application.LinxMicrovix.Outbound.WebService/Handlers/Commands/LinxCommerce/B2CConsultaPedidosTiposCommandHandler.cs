using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaPedidosTiposCommandHandler : IB2CConsultaPedidosTiposCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaPedidosTipos> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_tipo_b2c}'"));
            return $"SELECT CONCAT('[', ID_TIPO_B2C, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPEDIDOSTIPOS] WHERE ID_TIPO_B2C IN ({identificadores})";
        }
    }
}
