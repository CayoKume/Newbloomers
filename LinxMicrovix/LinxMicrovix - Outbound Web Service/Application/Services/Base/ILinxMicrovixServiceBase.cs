using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.Base
{
    public interface ILinxMicrovixServiceBase
    {
        public string BuildBodyRequest(JobParameter jobParameter, string? parametersList, string? cnpj_emp);
        public string BuildBodyRequest(JobParameter jobParameter);
        public List<Dictionary<string, string>> DeserializeResponseToXML(JobParameter jobParameter, string? response);
    }
}
