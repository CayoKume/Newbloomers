using Domain.IntegrationsCore.Entities.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(LinxMicrovixJobParameter jobParameter, string? body);
    }
}
