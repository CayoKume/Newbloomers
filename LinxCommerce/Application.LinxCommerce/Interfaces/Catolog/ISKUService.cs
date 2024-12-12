using Domain.LinxCommerce.Entities.Parameters;

namespace Application.LinxCommerce.Interfaces.Catolog
{
    public interface ISKUService
    {
        public Task<bool?> GetSKU(LinxCommerceJobParameter jobParameter, int productID);
        public Task<bool?> SearchSKU(LinxCommerceJobParameter jobParameter);
    }
}
