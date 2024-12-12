using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;

namespace Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(LinxAPIParam jobParameter, string? body);
    }
}
