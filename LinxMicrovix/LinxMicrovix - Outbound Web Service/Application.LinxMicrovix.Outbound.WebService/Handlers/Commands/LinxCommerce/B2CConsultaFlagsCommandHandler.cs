using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaFlagsCommandHandler : IB2CConsultaFlagsCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaFlags> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_b2c_flags}'"));
            return $"SELECT CONCAT('[', ID_B2C_FLAGS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAFLAGS] WHERE ID_B2C_FLAGS IN ({identificadores})";
        }
    }
}
