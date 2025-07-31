using Application.Core.Interfaces;
using Application.LinxCommerce.Interfaces;
using Domain.Core.Enums;
using Domain.LinxCommerce.Entities.Order;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Interfaces.Api;
using Domain.LinxCommerce.Interfaces.Repositorys;
using FluentValidation;
using static Domain.LinxCommerce.Entities.Responses.SearchOrder;

namespace Application.LinxCommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IOrderRepository _orderRepository;

        private readonly IValidator<Order.Root> _validator;
        private readonly IValidator<SearchOrderStatus.Result> _statusValidator;

        private static List<Order.Root?> SearchOrdersByDateIntervalCache { get; set; } = new List<Order.Root?>();
        private static string SearchOrderStatusJsonCache { get; set; } = String.Empty;

        public OrderService(IAPICall apiCall, ILoggerService logger, IOrderRepository orderRepository, IValidator<Order.Root> validator, IValidator<SearchOrderStatus.Result> statusValidator) =>
            (_apiCall, _logger, _orderRepository, _validator, _statusValidator) = (apiCall, logger, orderRepository, validator, statusValidator);

        public Task<bool?> GetOrder(LinxCommerceJobParameter jobParameter, string? orderId)
        {
            throw new NotImplementedException();
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

        public async Task<bool?> SearchOrdersByDateInterval(LinxCommerceJobParameter jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxCommerceOrders);

            int pageIndex = 0, pageCount = 0;
            var ordersResults = new List<Result>();

            while (pageIndex <= pageCount)
            {
                var objectRequest = new
                {
                    Page = new { PageIndex = pageIndex, PageSize = 500 },
                    Where = $"(ModifiedDate>=\"{DateTime.Now.AddDays(-2).Date:yyyy-MM-dd}T00:00:00\" && ModifiedDate<=\"{DateTime.Now.Date:yyyy-MM-dd}T23:59:59\")",
                    WhereMetadata = "",
                    OrderBy = "OrderNumber",
                };

                var response = await _apiCall.PostRequest(
                    jobParameter,
                    objectRequest,
                    "/v1/Sales/API.svc/web/SearchOrders"
                );

                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrder.Root>(response);

                if (pageCount == 0)
                    pageCount = result.Page.PageCount;

                pageIndex++;

                ordersResults.AddRange(result.Result);
            }

            if (SearchOrdersByDateIntervalCache.Count == 0)
            {
                var list = await _orderRepository.GetRegistersExists(
                    ordersResults
                        .Select(x => x.OrderID)
                        .ToList()
                );

                SearchOrdersByDateIntervalCache = list.ToList();
            }

            var _listSomenteNovos = ordersResults.Where(x => SearchOrdersByDateIntervalCache.Any(y =>
               x.OrderID == y.OrderID && x.ModifiedDate > y.ModifiedDate
            )).ToList();

            if (_listSomenteNovos.Count() > 0)
            {
                var ordersAPIList = new List<Order.Root>();

                foreach (var orderID in _listSomenteNovos)
                {
                    var getOrderResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        stringIdentifier: orderID.OrderID.ToString(),
                        route: "/v1/Sales/API.svc/web/GetOrder"
                    );

                    var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order.Root>(getOrderResponse);
                    var validations = _validator.Validate(order);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - order: {order.OrderNumber} | order_id: {order.OrderID}\n" +
                                            $"{validations.Errors[j]}"
                            );
                        }
                    }

                    ordersAPIList.Add(new Order.Root(order, getOrderResponse));
                }

                if (ordersAPIList.Count() > 0)
                {
                    await _orderRepository.BulkInsertIntoTableRaw(jobParameter, ordersAPIList, _logger.GetExecutionGuid());

                    ordersAPIList.ForEach(s =>
                        _logger.AddRecord(
                            s.OrderID.ToString(),
                            s.Responses
                                .Where(pair => pair.Key == s.OrderID)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );

                    ordersAPIList.ForEach(s =>
                        SearchOrdersByDateIntervalCache.AddRange(ordersAPIList)
                    );
                }
            }

            _logger.AddMessage(
                $"Concluída com sucesso: {_listSomenteNovos.Count()} registro(s) novo(s) inserido(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool?> SearchOrdersByQueue(LinxCommerceJobParameter jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxCommerceOrders);

            var objectRequest = new
            {
                QueueID = 21,
                Page = new { PageIndex = 0, PageSize = 1000 },
                Where = "EntityKeyName==\"OrderID\"",
                WhereMetadata = "",
                OrderBy = "QueueItemID",
            };

            var response = await _apiCall.PostRequest(
                jobParameter,
                objectRequest,
                "/v1/Sales/API.svc/web/GetQueueOrders"
            );

            var ordersAPIList = new List<Order.Root>();
            var enqueuedItens = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchQueuedOrder.Root>(response);
            var enqueuedOrders = enqueuedItens
                                .Result
                                .Where(x => x.QueueItem.EntityKeyName == "OrderID")
                                .GroupBy(y => y.QueueItem.EntityKeyValue)
                                .Select(g => g.First())
                                .ToList();

            foreach (var enqueuedOrder in enqueuedOrders)
            {
                var getOrderResponse = await _apiCall.PostRequest(
                    jobParameter: jobParameter,
                    stringIdentifier: enqueuedOrder.QueueItem.EntityKeyValue,
                    route: "/v1/Sales/API.svc/web/GetOrder"
                );

                var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order.Root>(getOrderResponse);
                var validations = _validator.Validate(order);

                if (validations.Errors.Count() > 0)
                {
                    for (int j = 0; j < validations.Errors.Count(); j++)
                    {
                        _logger.AddMessage(
                            message: $"Error when convert record - order: {order.OrderNumber} | order_id: {order.OrderID}\n" +
                                     $"{validations.Errors[j]}"
                        );
                    }
                }

                ordersAPIList.Add(new Order.Root(order, getOrderResponse));
            }

            if (ordersAPIList.Count() > 0)
            {
                await _orderRepository.BulkInsertIntoTableRaw(jobParameter, ordersAPIList, _logger.GetExecutionGuid());

                ordersAPIList.ForEach(s =>
                    _logger.AddRecord(
                        s.OrderID.ToString(),
                        s.Responses
                            .Where(pair => pair.Key == s.OrderID)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );

                _logger.AddMessage(
                    $"Concluída com sucesso: {ordersAPIList.Count()} registro(s) novo(s) inserido(s)!"
                );

                //remover da fila de integração apenas se o registro for inserido no banco de dados
                var listQueueItemID = new List<string>();

                foreach (var order in enqueuedOrders)
                {
                    listQueueItemID.Add(order.QueueItem.QueueItemID);
                }

                var dequeueObjectRequest = new { QueueItems = listQueueItemID };

                var dequeueResponse = await _apiCall.PostRequest(
                    jobParameter,
                    dequeueObjectRequest,
                    "/v1/Queue/API.svc/web/DequeueQueueItems"
                );
            }
            else
                _logger.AddMessage(
                    $"Concluída com sucesso: {ordersAPIList.Count()} registro(s) novo(s) inserido(s)!"
                );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public Task<string?> SearchOrdersBySeller()
        {
            throw new NotImplementedException();
        }

        public Task<string?> SearchOrdersCandidates()
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchOrderStatus(LinxCommerceJobParameter jobParameter)
        {
            _logger
                   .Clear()
                   .AddLog(EnumJob.LinxCommerceOrdersStatus);

            var _listSomenteNovos = new List<SearchOrderStatus.Result>();

            var objectRequest = new
            {
                Page = new { PageIndex = 0, PageSize = 0 },
                Where = $"",
                WhereMetadata = "",
                OrderBy = "OrderStatusID",
            };

            var response = await _apiCall.PostRequest(
                jobParameter,
                objectRequest,
                "/v1/Sales/API.svc/web/SearchOrderStatus"
            );

            var hash = _logger.ComputeSha256Hash(response);

            if (!SearchOrderStatusJsonCache.Equals(hash))
            {
                var orderStatusResult = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrderStatus.Root>(response);

                foreach (var status in orderStatusResult.Result)
                {
                    var validations = _statusValidator.Validate(status);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - OrderStatusID: {status.OrderStatusID} | Status: {status.Status}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    var getOrderStatusResponse = await _apiCall.PostRequest(
                        jobParameter: jobParameter,
                        intIdentifier: status.OrderStatusID,
                        route: "/v1/Sales/API.svc/web/GetOrderStatus"
                    );

                    var orderStatus = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchOrderStatus.Result>(getOrderStatusResponse);

                    _listSomenteNovos.Add(new SearchOrderStatus.Result(status, getOrderStatusResponse));
                }
            }

            if (_listSomenteNovos.Count() > 0)
            {
                await _orderRepository.BulkInsertIntoOrdersStatusTable(jobParameter: jobParameter, registros: _listSomenteNovos, parentExecutionGUID: _logger.GetExecutionGuid());

                _listSomenteNovos.ForEach(p =>
                    _logger.AddRecord(
                        p.OrderStatusID.ToString(),
                        p.Responses
                            .Where(pair => pair.Key == p.OrderStatusID)
                            .Select(pair => pair.Value)
                            .FirstOrDefault()
                    )
                );

                SearchOrderStatusJsonCache = hash;
            }

            _logger.AddMessage(
                $"Concluída com sucesso: {_listSomenteNovos.Count()} registro(s) novo(s) inserido(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public Task<bool?> UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> UpdateTrackingNumberOrder(LinxCommerceJobParameter jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxCommerceUpdateTrackingNumberOrder);

            var successfulTrackingNumber = new List<OrderTrackingNumber>();
            var trackingNumberOrders = await _orderRepository.GetTrackingNumbersToUpdate();

            if (trackingNumberOrders.Count() > 0)
            {
                for (int i = 0; i < trackingNumberOrders.Count(); i += 80)
                {
                    var lote = trackingNumberOrders.Skip(i).Take(80).ToList();

                    foreach (var item in lote)
                    {
                        var objectRequest = new
                        {
                            OrderID = item.OrderID,
                            WorkflowType = "SHIPPED",
                            Invoice = new
                            {
                                OrderInvoiceID = item.OrderInvoiceID,
                                Code = item.OrderInvoiceCode,
                                IsIssued = true
                            },
                            Shipment = new
                            {
                                TrackingNumber = item.TrackingNumber,
                                TrackingUrl = ""
                            },
                        };

                        var result = await _apiCall.PostRequest(
                            jobParameter,
                            "/v1/Sales/API.svc/web/UpdateOrder",
                            objectRequest
                        );

                        if (result)
                        {
                            await _orderRepository.InsertIntoUpdateTrackingNumberOrderTable(jobParameter, item, _logger.GetExecutionGuid());

                            _logger.AddRecord(
                                item.OrderID.ToString(),
                                Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest)
                            );
                        }
                    }

                    Thread.Sleep(5 * 1000);
                }
            }

            _logger.AddMessage(
                $"Concluída com sucesso: {successfulTrackingNumber.Count()} registro(s) atualizados(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
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