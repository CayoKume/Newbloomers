using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaProdutosStatusCommandHandler
    {
        string CreateGetRegistersExistsQuery(IList<B2CConsultaProdutosStatus> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
