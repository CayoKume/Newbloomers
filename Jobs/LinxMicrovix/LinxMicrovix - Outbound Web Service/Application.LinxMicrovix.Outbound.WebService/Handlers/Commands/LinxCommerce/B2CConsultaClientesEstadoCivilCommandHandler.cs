using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaClientesEstadoCivilCommandHandler : IB2CConsultaClientesEstadoCivilCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaClientesEstadoCivil> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_estado_civil}'"));
            return $"SELECT CONCAT('[', ID_ESTADO_CIVIL, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTACLIENTESESTADOCIVIL] WHERE ID_ESTADO_CIVIL IN ({identificadores})";
        }
    }
}
