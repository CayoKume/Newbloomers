using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxMovimentoPlanosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<LinxMovimentoPlanos> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
