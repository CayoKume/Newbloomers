using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaVendedoresCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaVendedores> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
