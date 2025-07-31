using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaProdutosCodebarCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCodebar> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
