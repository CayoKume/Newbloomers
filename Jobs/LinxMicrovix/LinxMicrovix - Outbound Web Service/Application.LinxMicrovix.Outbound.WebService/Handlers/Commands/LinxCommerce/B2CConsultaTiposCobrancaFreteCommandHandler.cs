using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteCommandHandler : IB2CConsultaTiposCobrancaFreteCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaTiposCobrancaFrete> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigo_tipo_cobranca_frete}'"));
            return $"SELECT CONCAT('[', CODIGO_TIPO_COBRANCA_FRETE, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTATIPOSCOBRANCAFRETE] WHERE CODIGO_TIPO_COBRANCA_FRETE IN ({identificadores})";
        }
    }
}
