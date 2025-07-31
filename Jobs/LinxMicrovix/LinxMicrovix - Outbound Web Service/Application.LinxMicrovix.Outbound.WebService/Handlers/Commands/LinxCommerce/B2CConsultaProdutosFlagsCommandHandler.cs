using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosFlagsCommandHandler : IB2CConsultaProdutosFlagsCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosFlags> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.codigoproduto}'"));
            return $"SELECT CONCAT('[', CODIGOPRODUTO, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSFLAGS] WHERE CODIGOPRODUTO IN ({identificadores})";
        }
    }
}
