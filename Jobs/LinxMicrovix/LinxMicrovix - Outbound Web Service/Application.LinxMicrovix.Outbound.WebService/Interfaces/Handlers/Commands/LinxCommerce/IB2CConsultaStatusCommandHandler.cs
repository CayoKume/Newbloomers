using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaStatusCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<int?> registros);
    }
}
