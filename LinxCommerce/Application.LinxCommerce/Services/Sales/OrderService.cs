using Application.LinxCommerce.Interfaces.Sales;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Catolog.Sku;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys.Base;

namespace Application.LinxCommerce.Services.Sales
{
    public class OrderService : IOrderService
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

                var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.LinxCommerce.Entities.Sales.Order.Order>(response);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public Task<string?> GetOrderByNumber()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderGroup()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderGroupByNumber()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderPackage()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderPayment()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderPayments()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetOrderStatus()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetPaymentTerm()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetQueueOrders()
        {
            throw new NotImplementedException();
        }

        public Task<string?> MakeOrderTransition()
        {
            throw new NotImplementedException();
        }

        public Task<string?> RunOrderWorkflow()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SaveOrderItemSerialKey()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SaveOrderPackage()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchFinancialOrderInfo()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrderPackage()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrders()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrdersBySeller()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrdersCandidates()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrderStatus()
        {
            throw new NotImplementedException();
        }

        public Task<string?> UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string?> UpdateOrderInvoice()
        {
            throw new NotImplementedException();
        }

        public Task<string?> UpdateOrderPackageTrackingNumber()
        {
            throw new NotImplementedException();
        }
    }
}
