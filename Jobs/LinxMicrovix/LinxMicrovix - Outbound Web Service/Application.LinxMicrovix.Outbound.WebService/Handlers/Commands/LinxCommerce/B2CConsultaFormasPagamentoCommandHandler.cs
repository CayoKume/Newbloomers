using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands
{
    public class B2CConsultaFormasPagamentoCommandHandler : IB2CConsultaFormasPagamentoCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaFormasPagamento> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.cod_forma_pgto}'"));
            return $"SELECT CONCAT('[', COD_FORMA_PGTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAFORMASPAGAMENTO] WHERE COD_FORMA_PGTO IN ({identificadores})";
        }
    }
}
