using Domain.Stone.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

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

        public async Task<string?> PostAsync(string? rote, JObject jObj, string? token)
        {
            try
            {
                var client = CreateClient(rote, token);
                var response = await client.PostAsync($"{client.BaseAddress}{rote}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jObj), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> PostAsync(string? rote, JObject jObj)
        {
            try
            {
                var client = CreateClient(rote);
                var response = await client.PostAsync($"{client.BaseAddress}{rote}", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jObj), Encoding.UTF8, "application/json"));

                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch
            {
                throw;
            }
        }

        private HttpClient CreateClient(string? route)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("StoneAPI");

                return client;
            }
            catch (Exception ex)
            {
                //Refatorar Aqui
                throw new Exception($"{route} - CreateClient - Erro ao criar HttpClientRequest para o end-point {route} - {ex}");
            }
        }

        private HttpClient CreateClient(string? route, string? token)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("StoneAPI");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("content-type", "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return client;
            }
            catch (Exception ex)
            {
                //Refatorar Aqui
                throw new Exception($"{route} - CreateClient - Erro ao criar HttpClientRequest para o end-point {route} - {ex}");
            }
        }
    }
}
