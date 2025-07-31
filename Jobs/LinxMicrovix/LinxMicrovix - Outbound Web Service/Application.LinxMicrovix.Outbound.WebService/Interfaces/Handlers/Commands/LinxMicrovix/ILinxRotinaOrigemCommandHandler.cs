using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxRotinaOrigemCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<int?> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
