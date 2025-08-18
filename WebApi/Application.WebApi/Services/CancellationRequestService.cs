using Domain.WebApi.Interfaces.Repositorys;
using Application.WebApi.Interfaces.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using Domain.WebApi.Models;

namespace Application.WebApi.Services
{
    public class CancellationRequestService : ICancellationRequestService
    {
        private readonly ICancellationRequestRepository _cancellationRequestRepository;

        public CancellationRequestService(ICancellationRequestRepository cancellationRequestRepository) =>
            _cancellationRequestRepository = cancellationRequestRepository;

        public async Task CreateCancellationRequest(string serializedOrder)
        {
            try
            {
                var order = JsonConvert.DeserializeObject<CancellationRequestOrder>(serializedOrder);
                await _cancellationRequestRepository.CreateCancellationRequest(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetOrderToCancel(string number, string serie, string doc_company)
        {
            try
            {
                var order = await _cancellationRequestRepository.GetOrderToCancel(number, serie, doc_company);
                return JsonConvert.SerializeObject(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetReasons()
        {
            try
            {
                var reasons = await _cancellationRequestRepository.GetReasons();
                return JsonConvert.SerializeObject(reasons);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
