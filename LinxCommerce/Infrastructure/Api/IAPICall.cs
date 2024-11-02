using IntegrationsCore.Domain.Entities.Parameters;

namespace LinxCommerce.Infrastructure.Api
{
    public interface IAPICall
    {
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, object objRequest, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, string identifier, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, int identifier, string? route);
    }
}
