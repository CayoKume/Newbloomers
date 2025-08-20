using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxXMLDocumentosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<string> registros);
        string CreateInsertRecordQuery(string tableName);
    }
}
