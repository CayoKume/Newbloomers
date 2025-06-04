using Domain.IntegrationsCore.Entities.Parameters;
using LinxCommerce.Domain.Entities.Catolog.Sku;
using LinxCommerce.Infrastructure.Api;
using LinxCommerce.Infrastructure.Repository.Base;
using LinxCommerce.Infrastructure.Repository.Catolog.SKURepository;

namespace LinxCommerce.Application.Services.Catolog.SKU
{
    public class SKUService : ISKUService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxCommerceRepositoryBase<SKUs> _linxCommerceRepositoryBase;
        private readonly ISKURepository _skuRepository;

        public SKUService(IAPICall apiCall, ILinxCommerceRepositoryBase<SKUs> linxCommerceRepositoryBase, ISKURepository skuRepository) =>
            (_apiCall, _linxCommerceRepositoryBase, _skuRepository) = (apiCall, linxCommerceRepositoryBase, skuRepository);

        public async Task<bool?> GetSKU(LinxCommerceJobParameter jobParameter, int productID)
        {
            try
            {
                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    intIdentifier: productID,
                    route: "/v1/Catalog/API.svc/web/GetSKU"
                );

                var skus = Newtonsoft.Json.JsonConvert.DeserializeObject<SKUs>(response);

                await _skuRepository.InsertRecord(jobParameter, skus);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<bool?> SearchSKU(LinxCommerceJobParameter jobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
