using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxMicrovix
{
    public interface ILinxUsuariosCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<int?> registros);
    }
}
