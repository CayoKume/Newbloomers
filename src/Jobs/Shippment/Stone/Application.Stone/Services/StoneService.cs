using Application.Core.Interfaces;
using Application.Stone.Interfaces.Services;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Extensions;
using Domain.Stone.Entities;
using Domain.Stone.Interfaces.Api;
using Domain.Stone.Interfaces.Repository;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;

namespace Application.Stone.Services
{
    public class StoneService : IStoneService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IValidator<Domain.Stone.Dtos.Order> _validator;
        private readonly IStoneRepository _stoneRepository;
        private static List<Domain.Stone.Entities.Order?> _checkDeliveryOrdersCache { get; set; } = new List<Domain.Stone.Entities.Order?>();

        public StoneService(IStoneRepository stoneRepository, IAPICall apiCall, ILoggerService logger, IValidator<Domain.Stone.Dtos.Order> validator) =>
            (_stoneRepository, _apiCall, _logger, _validator) = (stoneRepository, apiCall, logger, validator);

        public Task<string> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckDeliveryOrder()
        {
            _logger
                .Clear()
                .AddLog(EnumJob.StoneLogisticaTrackingHistory);

            var ordersAPIList = new List<Domain.Stone.Dtos.Order>();
            var listRecords = new List<Order>();
            var parameters = await _stoneRepository.GetParameters();

            foreach (var parameter in parameters)
            {
                var jObject = new JObject
                {
                    { "email", parameter.email },
                    { "password", parameter.password }
                };

                int pageIndex = 1;
                int? pageCount = 1;
                var responseToken = await _apiCall.PostAsync("auth/login", jObject);
                var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(responseToken);

                while (pageIndex <= pageCount)
                {
                    //var response = await _apiCall.GetAsync($"deliveries/?paginated=true&currentPage={pageIndex}&pageLimit=100&orderBy=createdAt", token.accessToken);
                    var response = await _apiCall.GetAsync($"deliveries/?paginated=true&currentPage={pageIndex}&pageLimit=100&fromDate={DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}T00:00:00.000Z&untilDate={DateTime.Today.ToString("yyyy-MM-dd")}T23:59:59.000Z&orderBy=createdAt", token.accessToken);
                    var retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Stone.Dtos.Response>(response);

                    if (pageCount == 1)
                        pageCount = retorno.pagination.lastPage;

                    pageIndex++;

                    ordersAPIList.AddRange(retorno.data);
                }

                foreach (var orderDto in ordersAPIList)
                {
                    var validations = _validator.Validate(orderDto);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - order: {orderDto.referenceKey} | order_id: {orderDto.id}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    try
                    {
                        listRecords.Add(new Order(orderDto));
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                if (_checkDeliveryOrdersCache.Count == 0)
                {
                    var list = await _stoneRepository.GetRegistersExists(
                        registros: listRecords
                                    .Select(x => x.orderId)
                                    .ToList()
                    );

                    _checkDeliveryOrdersCache = list.ToList();
                }

                listRecords.RemoveAll(x => _checkDeliveryOrdersCache.Any(y =>
                   x.orderId == y.orderId &&
                   x.updatedAt <= y.updatedAt
                ));

                if (listRecords.Count() > 0)
                {
                    await _stoneRepository.BulkInsertIntoTableRaw(listRecords, _logger.GetExecutionGuid());

                    listRecords.ForEach(s =>
                        _checkDeliveryOrdersCache.Add(s)
                    );

                    listRecords.ForEach(s =>
                        _logger.AddRecord(
                            s.orderId.ToString(),
                            s.Responses
                                .Where(pair => pair.Key == s.orderNumber)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {listRecords.Count()} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> CreateDeliveryOrder()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.StoneLogisticaSendOrders);

            var _listSomenteNovos = new List<SendedOrder>();
            var parameters = await _stoneRepository.GetParameters();
            var orders = await _stoneRepository.GetRegistersExists();

            if (orders.Count() > 0)
            {
                foreach (var parameter in parameters)
                {
                    var jObject = new JObject
                    {
                        { "email", parameter.email },
                        { "password", parameter.password }
                    };

                    var responseToken = await _apiCall.PostAsync("auth/login", jObject);
                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(responseToken);

                    foreach (var order in orders)
                    {
                        try
                        {
                            var jObj = BuildJObject(order, parameters.FirstOrDefault());

                            string? response = await _apiCall.PostAsync(
                                "deliveries",
                                jObj,
                                token.accessToken
                            );

                            if (response.Contains("message"))
                            {
                                var error = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Stone.Dtos.Error>(response);
                                _listSomenteNovos.Add(new SendedOrder(order.number, Newtonsoft.Json.JsonConvert.SerializeObject(jObj), error.message, error.error));
                                continue;
                            }

                            var pedido = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Stone.Dtos.SendedOrderResponse>(response);
                            _listSomenteNovos.Add(new SendedOrder(pedido, order.number, Newtonsoft.Json.JsonConvert.SerializeObject(jObj)));
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                if (_listSomenteNovos.Count() > 0)
                {
                    await _stoneRepository.BulkInsertIntoTableRaw(_listSomenteNovos, _logger.GetExecutionGuid());

                    _listSomenteNovos.ForEach(s =>
                        _logger.AddRecord(
                            s.orderNumber,
                            s.Responses
                                .Where(pair => pair.Key == s.orderNumber)
                                .Select(pair => pair.Value)
                                .FirstOrDefault()
                        )
                    );
                }
            }

            _logger.AddMessage(
                $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return false;
        }

        public Task<string> GetAccessToken()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDeliveryOptions()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetZplLabels()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.StoneLogisticaGetZplLabels);

            var parameters = await _stoneRepository.GetParameters();
            var orders = await _stoneRepository.GetExistingReferenceKeys();

            if (orders.Count() > 0)
            {
                foreach (var parameter in parameters)
                {
                    var jObject = new JObject
                            {
                                { "email", parameter.email },
                                { "password", parameter.password }
                            };

                    var responseToken = await _apiCall.PostAsync("auth/login", jObject);
                    var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(responseToken);

                    foreach (var order in orders)
                    {
                        try
                        {
                            var response = await _apiCall.GetAsync($"deliveries/{order.referencekey}/label?format=zpl", token.accessToken);
                            
                            if (response.Contains("erro"))
                            {
                                var error = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Stone.Dtos.Error>(response);
                                order.SetError(error.message, error.error);
                                continue;
                            }

                            var zpl = await _apiCall.GetAsync(response);
                            order.SetZpl(zpl);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }

                await _stoneRepository.InsertZpls(orders.ToList());

                _logger.AddMessage(
                    $"Concluída com sucesso: {orders.Count()} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return false;
        }

        private JObject BuildJObject(OrdersToBeSent order, Parameters? parameters)
        {
            var itensArray = new JArray();
            
            foreach (var item in order.itens)
            {
                itensArray.Add(new JObject
                {
                    { "description", $"{item.description_product}" },
                    { "invoiceNumber", $"{order.invoice.number_nf}" },
                    { "invoiceKey", $"{order.invoice.key_nfe_nf}" },
                    { "quantity", item.quantity_product },
                    { "unitPrice", item.unitary_value_product },
                    { "weight", 1 },
                    { "height", 1 },
                    { "depth", 1 },
                    { "width", 1 },
                    { "isDangerous", 0 }
                });
            }

            return new JObject
            {
                { "referenceKey", $"{order.number}" },
                { "acceptedAgreements", true },
                { "quoteId", String.Empty },
                { "contractPrice", 0 },
                { "customer", new JObject {
                        { "name", $"{order.client.reason_client}" },
                        { "document", $"{order.client.doc_client}" },
                        { "phoneNumber", $"999999999" },
                        { "email", $"{order.client.email_client}" }
                    } 
                },
                { "sender", new JObject {
                        { "logisticAccountId", "" },
                        { "name", $"{order.company.reason_company}" },
                        { "phoneNumber", $"{order.company.fone_company}" },
                        { "document", $"{order.company.doc_company}" }
                    }
                },
                { "carrier", new JObject {
                        { "name", String.Empty /*$"{order.shippingCompany.name_shippingCompany}"*/ },
                        { "service", String.Empty }
                    }
                },
                { "deliveryAddress", new JObject {
                        { "address", $"{order.client.address_client}" },
                        { "addressNumber", $"{order.client.street_number_client}" },
                        { "neighborhood", $"{order.client.neighborhood_client}" },
                        { "city", $"{order.client.city_client}" },
                        { "countryState", $"{order.client.uf_client}" },
                        { "zipCode", $"{order.client.zip_code_client.Trim()}" },
                        { "complement", $"{order.client.complement_address_client}" },
                        { "reference", $"{order.client.complement_address_client}" },
                        { "latitude", 0 },
                        { "longitude", 0 }
                    }
                },
                { "pickupAddress", new JObject {
                        { "address", $"{order.company.address_company}" },
                        { "addressNumber", $"{order.company.street_number_company}" },
                        { "neighborhood", $"{order.company.neighborhood_company}" },
                        { "city", $"{order.company.city_company}" },
                        { "countryState", $"{order.company.uf_company}" },
                        { "zipCode", $"{order.company.zip_code_company.Trim()}" },
                        { "complement", $"{order.company.complement_address_company}" },
                        { "reference", $"{order.company.complement_address_company}" },
                        { "latitude", 0 },
                        { "longitude", 0 }
                    }
                },
                { "items", itensArray},
                { "invoiceKey", $"{order.invoice.key_nfe_nf}" },
                { "invoiceNumber", $"{order.invoice.number_nf}" },
                { "invoiceSeries", $"{order.invoice.serie_nf}" },
                { "dceAccessKey", String.Empty },
                { "dceNumber", String.Empty },
                { "dceSeries", String.Empty },
            };
        }
    }
}
