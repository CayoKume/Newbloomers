using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaPlanosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaPlanos> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
