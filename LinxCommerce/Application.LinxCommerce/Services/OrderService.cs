using Application.LinxCommerce.Interfaces;
using Domain.LinxCommerce.Entities.Order;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Entities.SalesRepresentative;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys.Order;

namespace Application.LinxCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAPICall _apiCall;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderRepository _orderRepository;
        private static String _orderStatusCache = String.Empty;
        private static List<Order.Root> _ordersDboList = new List<Order.Root>();

        public OrderService(IAPICall apiCall, IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository) =>
            (_apiCall, _orderRepository, _orderStatusRepository) = (apiCall, orderRepository, orderStatusRepository);

        public async Task<bool?> GetOrder(LinxCommerceJobParameter jobParameter, string? orderId)
        {
            try
            {
                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    stringIdentifier: orderId,
                    route: "/v1/Sales/API.svc/web/GetOrder"
                );

                var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(response);

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

        public async Task<string?> SearchOrders(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    //Where = $"(ModifiedDate>=\"{DateTime.Now.AddDays(-1).Date:yyyy-MM-dd}T00:00:00\" && ModifiedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    Where = $"(ModifiedDate>=\"{DateTime.Now.Date:yyyy-MM-dd}T00:00:00\" && ModifiedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Sales/API.svc/web/SearchOrders"
                );

                var ordersAPIList = new List<Order.Root>();
                var ordersIDs = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrder.Root>(response); 
                
                foreach (var orderID in ordersIDs.Result)
                {
                    var getSaleRepresentativeResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        stringIdentifier: orderID.OrderID,
                        route: "/v1/Sales/API.svc/web/GetOrder"
                    );

                    var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order.Root>(getSaleRepresentativeResponse);

                    ordersAPIList.Add(order);
                }

                _orderRepository.BulkInsertIntoTableRaw(jobParameter, ordersAPIList);

                return "true";
            }
            catch
            {
                throw;
            }
        }

        public Task<string?> SearchOrdersBySeller()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrdersCandidates()
        {
            throw new NotImplementedException();
        }

        public async Task<string?> SearchOrderStatus(LinxCommerceJobParameter jobParameter)
        {
            try
            {
                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    Where = $"",
                    WhereMetadata = "",
                    OrderBy = "OrderStatusID",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Sales/API.svc/web/SearchOrderStatus"
                );

                if (_orderStatusCache != response)
                {
                    _orderStatusCache = response;

                    var orderStatus = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrderStatus.Root>(response);

                    _orderStatusRepository.BulkInsertIntoTableRaw(jobParameter: jobParameter, registros: orderStatus);
                }

                return "true";
            }
            catch
            {
                throw;
            }
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
