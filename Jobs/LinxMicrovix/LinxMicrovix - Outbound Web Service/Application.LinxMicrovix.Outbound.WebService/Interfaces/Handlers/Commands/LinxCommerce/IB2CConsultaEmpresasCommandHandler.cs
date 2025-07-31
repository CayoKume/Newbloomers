using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaEmpresasCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<string> registros);
    }
}
