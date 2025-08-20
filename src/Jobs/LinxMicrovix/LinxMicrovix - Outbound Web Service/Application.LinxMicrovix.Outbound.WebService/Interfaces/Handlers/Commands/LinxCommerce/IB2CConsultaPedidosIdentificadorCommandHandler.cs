using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaPedidosIdentificadorCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<B2CConsultaPedidosIdentificador> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
