using Domain.IntegrationsCore.Entities.Parameters;

namespace LinxCommerce.Infrastructure.Api
{
    public interface IAPICall
    {
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, object objRequest, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, string stringIdentifier, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, int intIdentifier, string? route);
    }
}
