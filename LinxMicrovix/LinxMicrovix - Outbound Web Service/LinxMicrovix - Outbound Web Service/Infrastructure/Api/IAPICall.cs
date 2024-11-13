using IntegrationsCore.Domain.Entities;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(LinxMicrovixJobParameter jobParameter, string? body);
    }
}
