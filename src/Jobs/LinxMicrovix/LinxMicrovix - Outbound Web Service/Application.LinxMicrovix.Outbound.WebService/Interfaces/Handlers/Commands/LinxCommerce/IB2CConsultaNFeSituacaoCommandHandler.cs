using System.Collections.Generic;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce
{
    public interface IB2CConsultaNFeSituacaoCommandHandler
    {
        string CreateGetRegistersExistsQuery(List<int?> registros);
    }
}
