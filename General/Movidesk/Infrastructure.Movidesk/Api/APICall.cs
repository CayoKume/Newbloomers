using Domain.Movidesk.Interfaces.Apis;

namespace Infrastructure.Movidesk.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public async Task<string> GetAsync(string rote, string token)
        {
            try
            {
                var client = CreateClient();
                var response = await client.GetAsync(client.BaseAddress + rote + "?token=" + token);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetAsync(string rote, string token, string filters, string selectItens, string expandItens)
        {
            try
            {
                var client = CreateClient();
                var response = await client.GetAsync(client.BaseAddress + rote + "?token=" + token + "&$filter=" + filters + "&$select=" + selectItens + "&$expand=" + expandItens);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient("MovideskAPI");
            client.DefaultRequestHeaders.Add("accept", "application/json");

            return client;
        }
    }
}
