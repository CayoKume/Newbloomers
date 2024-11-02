using IntegrationsCore.Domain.Entities.Parameters;
using LinxCommerce.Domain.Entities.Sales.Order.Responses;
using LinxCommerce.Infrastructure.Api;
using LinxCommerce.Infrastructure.Repository.Base;
using LinxCommerce.Infrastructure.Repository.Sales;

namespace LinxCommerce.Application.Services.Sales
{
    public class SalesService : ISalesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxCommerceRepositoryBase _linxCommerceRepositoryBase;
        private readonly ISalesRepository _salesRepository;

        public SalesService(IAPICall apiCall) =>
            (_apiCall) = (apiCall);

        public Task<string?> DeleteSalesRepresentative(int salesRepresentativeId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> GetOrder(LinxCommerceJobParameter jobParameter, string? orderId)
        {
            try
            {
                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter, 
                    identifier: orderId, 
                    route: "/v1/Sales/API.svc/web/GetOrder"
                );

                var order = Newtonsoft.Json.JsonConvert.DeserializeObject<GetOrderResponse>(response);

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

        public Task<string?> GetSalesRepresentative()
        {
            throw new NotImplementedException();
        }

        public Task<string?> GetShipment()
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

        public Task<string?> SaveSalesRepresentative()
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

        public Task<string?> SearchPaymentTerm()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchSalesRepresentative()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchShipments()
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

        public Task<string?> UpdateRemarks()
        {
            throw new NotImplementedException();
        }

        public Task<string?> UpdateShipment()
        {
            throw new NotImplementedException();
        }
    }
}
