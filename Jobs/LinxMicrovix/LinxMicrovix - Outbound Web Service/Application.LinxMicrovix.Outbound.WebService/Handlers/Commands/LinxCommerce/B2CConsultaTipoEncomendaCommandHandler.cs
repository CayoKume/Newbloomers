using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaTipoEncomendaCommandHandler : IB2CConsultaTipoEncomendaCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaTipoEncomenda> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_tipo_encomenda}'"));
            return $"SELECT CONCAT('[', ID_TIPO_ENCOMENDA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CConsultaTipoEncomenda] WHERE ID_TIPO_ENCOMENDA IN ({identificadores})";
        }
    }
}
