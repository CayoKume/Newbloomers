using IntegrationsCore.Domain.Entities.Parameters;
using LinxCommerce.Domain.Entities.Catolog.Sku;
using LinxCommerce.Infrastructure.Api;
using LinxCommerce.Infrastructure.Repository.Base;

namespace LinxCommerce.Application.Services.Sales.Order
{
    public class OrderService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxCommerceRepositoryBase<SKUs> _linxCommerceRepositoryBase;
        //private readonly IOrderRepository

        public OrderService(IAPICall apiCall, ILinxCommerceRepositoryBase<SKUs> linxCommerceRepositoryBase) =>
            (_apiCall, _linxCommerceRepositoryBase) = (apiCall, linxCommerceRepositoryBase);

        public async Task<bool?> GetOrder(LinxCommerceJobParameter jobParameter, string? orderId)
        {
            try
            {
                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    stringIdentifier: orderId,
                    route: "/v1/Sales/API.svc/web/GetOrder"
                );

                var order = Newtonsoft.Json.JsonConvert.DeserializeObject<LinxCommerce.Domain.Entities.Sales.Order.Order>(response);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
