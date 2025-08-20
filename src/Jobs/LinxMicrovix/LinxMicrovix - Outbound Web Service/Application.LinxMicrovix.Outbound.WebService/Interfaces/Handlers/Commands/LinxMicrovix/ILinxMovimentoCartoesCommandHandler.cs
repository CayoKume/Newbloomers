using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxMovimentoCartoesCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<LinxMovimentoCartoes> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
