using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaProdutosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaProdutos> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
