using Domain.Stone.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Infrastructure.Stone.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public Task<string?> DeleteAsync(string? rote, JObject jObj)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        private HttpClient CreateClient(string? route, string? token)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("StoneAPI");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("content-type", "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return client;
            }
            catch (Exception ex)
            {
                throw new Exception($"{route} - CreateClient - Erro ao criar HttpClientRequest para o end-point {route} - {ex}");
            }
        }
    }
}
