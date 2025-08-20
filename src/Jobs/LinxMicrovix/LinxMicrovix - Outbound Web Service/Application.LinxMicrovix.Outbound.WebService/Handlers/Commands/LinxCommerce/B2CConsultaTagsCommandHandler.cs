using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaTagsCommandHandler : IB2CConsultaTagsCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaTags> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_pedido_item}'"));
            return $"SELECT CONCAT('[', ID_PEDIDO_ITEM, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTATAGS] WHERE ID_PEDIDO_ITEM IN ({identificadores})";
        }
    }
}
