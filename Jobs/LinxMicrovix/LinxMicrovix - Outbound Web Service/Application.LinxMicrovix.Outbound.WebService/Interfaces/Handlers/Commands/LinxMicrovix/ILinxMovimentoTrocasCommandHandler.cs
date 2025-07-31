using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxMovimentoTrocasCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<LinxMovimentoTrocas> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
