using Domain.IntegrationsCore.Entities.Parameters;

namespace Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(LinxMicrovixJobParameter jobParameter, string? body);
    }
}
