using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.Jadlog.Interfaces.Api;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Infrastructure.Jadlog.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public async Task<string?> GetAsync(string? rote, string? token, string? clientName, string? contentType)
        {
            try
            {
                var client = CreateClient(rote, token, clientName, contentType);
                var result = await client.GetAsync($"{client.BaseAddress}{rote}");

                return await result.Content.ReadAsStringAsync();
            }
            catch
            {
                throw new InternalException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {rote} on jadlog webservices"
                );
            }
        }

        public async Task<string?> PostAsync(string? rote, string? token, string? clientName, string? contentType, JObject jObj)
        {
            try
            {
                var client = CreateClient(rote, token, clientName, contentType);
                var response = await client.PostAsync(client.BaseAddress + rote, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(jObj), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch
            {
                throw new InternalException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {rote} on jadlog webservices\n" +
                             $"Request: {Newtonsoft.Json.JsonConvert.SerializeObject(jObj)}"
                );
            }
        }

        private HttpClient CreateClient(string? route, string? token, string? clientName, string? contentType)
        {
            var client = _httpClientFactory.CreateClient($"{clientName}");
            client.DefaultRequestHeaders.Add("ContentType", $"{contentType}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
    }
}
