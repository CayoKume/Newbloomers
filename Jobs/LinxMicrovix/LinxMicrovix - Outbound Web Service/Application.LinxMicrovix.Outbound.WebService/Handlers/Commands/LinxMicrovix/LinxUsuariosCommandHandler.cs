using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix;
using System.Collections.Generic;
using System.Linq;

namespace Application.LinxMicrovix.Outbound.WebService.Handlers.Commands.LinxMicrovix
{
    public class LinxUsuariosCommandHandler : ILinxUsuariosCommandHandler
    {
        public string CreateGetRegistersExistsQuery(List<int?> registros)
        {
            string identificadores = string.Join(", ", registros.Select(r => $"'{r}'"));
            return $"SELECT CONCAT('[', usuario_id, ']', '|', '[', usuario_doc, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_erp].[LinxUsuarios] WHERE usuario_id IN ({identificadores})";
        }
    }
}
