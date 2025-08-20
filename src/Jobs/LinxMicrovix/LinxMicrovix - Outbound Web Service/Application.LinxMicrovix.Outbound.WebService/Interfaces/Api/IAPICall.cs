using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<string?> PostAsync(LinxAPIParam jobParameter, string? body);
    }
}
