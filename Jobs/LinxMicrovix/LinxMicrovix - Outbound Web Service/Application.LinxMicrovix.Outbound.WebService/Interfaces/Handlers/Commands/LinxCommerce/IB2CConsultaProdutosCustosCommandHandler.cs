using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaProdutosCustosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaProdutosCustos> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
