using Domain.IntegrationsCore.Entities.Parameters;

namespace LinxCommerce.Application.Services.Catolog.SKU
{
    public interface ISKUService
    {
        public Task<bool?> GetSKU(LinxCommerceJobParameter jobParameter, int productID);
        public Task<bool?> SearchSKU(LinxCommerceJobParameter jobParameter);
    }
}
