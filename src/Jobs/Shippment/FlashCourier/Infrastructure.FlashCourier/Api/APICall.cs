using Domain.FlashCourier.Interfaces.Api;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;

namespace Infrastructure.FlashCourier.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public async Task<string?> PostAsync(string? token, JObject jObject, string? rote)
        {
            try
            {
                var client = CreateCliente(token);

                var response = await client.PostAsync(
                    client.BaseAddress + rote,
                    new StringContent(
                        Newtonsoft.Json.JsonConvert.SerializeObject(jObject),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                if (response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch
            {
                throw;
            }
        }

        public async Task<string?> PostAsync(string? userName, string? password, JArray jObject, string? rote)
        {
            try
            {
                var client = CreateCliente(
                    userName: userName,
                    password: password
                );

                var response = await client.PostAsync(
                    client.BaseAddress + rote,
                    new StringContent(
                        JsonConvert.SerializeObject(jObject),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                if (response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode} - {await response.Content.ReadAsStringAsync()}"); //associar request com status code - ou retornar objeto para tratar erro
            }
            catch
            {
                throw;
            }
        }

        private HttpClient CreateCliente(string? token)
        {
            var client = _httpClientFactory.CreateClient("FlashCourierAPI");
            client.DefaultRequestHeaders.Add("Authorization", token);
            return client;
        }

        private HttpClient CreateCliente(string? userName, string? password)
        {
            var client = _httpClientFactory.CreateClient("FlashCourierAPI");
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{userName}:{password}")));
            client.DefaultRequestHeaders.Add("Cookie", "ROUTEID=.1");

            return client;
        }
    }
}
