using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Parameters;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Base
{
    public interface ILinxMicrovixServiceBase
    {
        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter, string? parametersList, string? cnpj_emp);
        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter);
        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response);
        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response, ICacheBase entityCache);
    }
}
