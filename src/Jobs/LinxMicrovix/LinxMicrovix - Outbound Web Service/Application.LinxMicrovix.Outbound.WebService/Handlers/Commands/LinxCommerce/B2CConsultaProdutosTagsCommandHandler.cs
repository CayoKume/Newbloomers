using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxCommerce
{
    public class B2CConsultaProdutosTagsCommandHandler : IB2CConsultaProdutosTagsCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosTags> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r.id_b2c_tags}'"));
            return $"SELECT CONCAT('[', ID_B2C_TAGS, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAPRODUTOSTAGS] WHERE ID_B2C_TAGS IN ({identificadores})";
        }
    }
}
