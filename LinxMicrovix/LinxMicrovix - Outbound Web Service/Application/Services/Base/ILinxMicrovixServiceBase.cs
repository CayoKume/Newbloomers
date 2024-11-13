using IntegrationsCore.Application.Services.Cache;
using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.Base
{
    public interface ILinxMicrovixServiceBase
    {
        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter, string? parametersList, string? cnpj_emp);
        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter);
        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response);
        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response, ICacheXmlUtilActions entityCache);
    }
}
