using Application.Core.Interfaces;
using Application.Stone.Interfaces.Services;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Stone.Entities;
using Domain.Stone.Interfaces.Api;
using Domain.Stone.Interfaces.Repository;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System.Data.Common;
using System.Linq;

namespace Application.Stone.Services
{
    public class StoneService : IStoneService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IValidator<Domain.Stone.Dtos.Order> _validator;
        private readonly IStoneRepository _stoneRepository;

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

            var ordersAPIList = new List<Order>();
            var parameters = await _stoneRepository.GetParameters();

            foreach (var parameter in parameters)
            {
                var jObject = new JObject
                {
                    { "email", parameter.email },
                    { "password", parameter.password }
                };

                var responseToken = await _apiCall.PostAsync("auth/login", jObject);
                var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(responseToken);
                var orders = await _stoneRepository.GetRegistersExists();

                foreach(var order in orders)
                {
                    var response = await _apiCall.GetAsync($"deliveries/3294_29_{order}", token.accessToken);
                    var orderDto = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Stone.Dtos.Order>(response);
                    var validations = _validator.Validate(orderDto);

                    if (validations.Errors.Count() > 0)
                    {
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - order: {order} | order_id: {orderDto.id}\n" +
                                         $"{validations.Errors[j]}"
                            );
                        }
                    }

                    ordersAPIList.Add(new Order(orderDto, response, order));
                }

                await _stoneRepository.BulkInsertIntoTableRaw(ordersAPIList, _logger.GetExecutionGuid());

                ordersAPIList.ForEach(s =>
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
                $"Concluída com sucesso: {ordersAPIList.Count()} registro(s) novo(s) inserido(s)!"
            );

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public Task<string> CreateDeliveryOrder()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAccessToken()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDeliveryOptions()
        {
            throw new NotImplementedException();
        }
    }
}
