using Application.WebApp.Interfaces.Api;
using Application.WebApp.Interfaces.Services;
using System.Text.Json;
using Application.WebApp.ViewModels.ExecuteCancellation;

namespace Services
{
    public class ExecuteCancellationService : IExecuteCancellationService
    {
        private readonly IAPICall _apiCall;

        public ExecuteCancellationService(IAPICall apiCall) =>
            _apiCall = apiCall;

        public async Task<List<Order>> GetOrdersToCancel(string serie, string doc_company)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "serie", serie },
                    { "doc_company", doc_company }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetOrdersToCancel", encodedParameters);
                return JsonSerializer.Deserialize<List<Order>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<int, string>> GetReasons()
        {
            try
            {
                var result = await _apiCall.GetAsync("GetReasonsToExecuteCancellation");
                return JsonSerializer.Deserialize<Dictionary<int, string>>(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateDateCanceled(string number, string suporte, string inputObs, int motivo)
        {
            try
            {
                return await _apiCall.PutAsync("UpdateDateCanceled", JsonSerializer.Serialize(new { number, suporte, obs = inputObs, motivo }));
            }
            catch
            {
                throw;
            }
        }
    }
}
