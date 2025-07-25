using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaLegendasCadastrosAuxiliaresCommandHandler : IB2CConsultaLegendasCadastrosAuxiliaresCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaLegendasCadastrosAuxiliares> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.empresa}'"));
            return $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTALEGENDASCADASTROSAUXILIARES] WHERE EMPRESA IN ({identificadores})";
        }
    }
}
