using Application.AfterSale.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Infrastructure.AfterSale.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public async Task<string?> GetAsync(string? rote, string? token, string? encodedParameters)
        {
            try
            {
                var client = CreateClient(rote, token);
                var result = await client.GetAsync($"{client.BaseAddress}{rote}?{encodedParameters}");
                return await result.Content.ReadAsStringAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> GetAsync(string? rote, string? token)
        {
            try
            {
                var client = CreateClient(rote, token);
                var result = await client.GetAsync($"{client.BaseAddress}{rote}");

                return await result.Content.ReadAsStringAsync();
            }
            catch
            {
                throw;
            }
        }

        public Task<string?> PostAsync(string? rote, JObject jObj)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        public Task<string?> PutAsync(string? rote, JObject jObj)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
        }

        private HttpClient CreateClient(string? route, string? token)
        {
            var client = _httpClientFactory.CreateClient("AfterSaleAPI");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
    }
}
