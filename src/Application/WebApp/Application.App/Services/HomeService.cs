using Application.App.Interfaces.Api;
using Application.App.Interfaces.Services;
using Application.App.ViewModels.Home;

namespace Application.App.Services
{
    public class HomeService : IHomeService
    {
        private readonly IAPICall _apiCall;

        public HomeService(IAPICall apiCall) =>
            (_apiCall) = (apiCall);

        public async Task<List<Order>?> GetPickupOrders(string cnpj_emp)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "cnpj_emp", cnpj_emp }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync("GetPickupOrders", encodedParameters);
                return System.Text.Json.JsonSerializer.Deserialize<List<Order>>(result);
            }
            catch
            {
                throw;
            }
        }
    }
}
