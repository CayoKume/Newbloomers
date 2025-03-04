using Application.IntegrationsCore.Interfaces;
using Application.LinxCommerce.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
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
        private readonly ILoggerService _logger;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderRepository _orderRepository;
        private static String _orderStatusCache = String.Empty;
        private static List<Domain.LinxCommerce.Entities.Order.Order.Root> _ordersDboList = new List<Domain.LinxCommerce.Entities.Order.Order.Root>();

        public OrderService(IAPICall apiCall, ILoggerService logger, IOrderRepository orderRepository, IOrderStatusRepository orderStatusRepository) =>
            (_apiCall, _logger, _orderRepository, _orderStatusRepository) = (apiCall, logger, orderRepository, orderStatusRepository);

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
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceOrders);

                var objectRequest = new
                {
                    Page = new { PageIndex = 0, PageSize = 0 },
                    Where = $"(ModifiedDate>=\"{DateTime.Now.Date:yyyy-MM-dd}T00:00:00\" && ModifiedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    objRequest: objectRequest,
                    route: "/v1/Sales/API.svc/web/SearchOrders"
                );

                var ordersResults = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrder.Root>(response);

                if (_ordersDboList.Count() == 0)
                    _ordersDboList = await _orderRepository.GetRegistersExists(ordersResults.Result.Select(o => o.OrderID));

                Order.Root.Compare(ordersResults.Result, _ordersDboList);

                if (ordersResults.Result.Count() > 0)
                {
                    var ordersAPIList = new List<Order.Root>();

                    foreach (var orderID in ordersResults.Result)
                    {
                        var getOrderResponse = await _apiCall.PostRequest(
                            jobParameter: jobParameter,
                            stringIdentifier: orderID.OrderID.ToString(),
                            route: "/v1/Sales/API.svc/web/GetOrder"
                        );

                        var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order.Root>(getOrderResponse);
                        order.Responses.Add(order.OrderID.ToString(), getOrderResponse);

                        ordersAPIList.Add(order);
                    }

                    ordersAPIList.ForEach(s =>
                        _logger.AddRecord(
                            s.OrderID.ToString(),
                            s.Responses
                                .Where(pair => pair.Key == s.OrderID.ToString())
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    _orderRepository.BulkInsertIntoTableRaw(jobParameter, ordersAPIList);

                    _logger.AddMessage(
                                $"Concluída com sucesso: {ordersAPIList.Count()} registro(s) novo(s) inserido(s)!"
                            );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {ordersResults.Result.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return "true";
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return "true";
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
