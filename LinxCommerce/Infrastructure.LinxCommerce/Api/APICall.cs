using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.LinxCommerce.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Api;
using System.Net;
using System.Text;

namespace Infrastructure.LinxCommerce.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

        public async Task<bool> PostRequest(LinxCommerceJobParameter jobParameter, string? route, object objRequest)
        {
            try
            {
                var client = CreateClient(
                    jobParameter,
                    route
                    );

                var response = await client.PostAsync(
                    client.BaseAddress + route,
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objRequest),
                    Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                $"Request: {Newtonsoft.Json.JsonConvert.SerializeObject(objRequest)}"
                );
            }
        }

        public async Task<string> PostRequest(LinxCommerceJobParameter jobParameter, object objRequest, string? route)
        {
            try
            {
                var client = CreateClient(
                    jobParameter,
                    route
                    );

                var response = await client.PostAsync(
                    client.BaseAddress + route,
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(objRequest),
                    Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                $"Request: {Newtonsoft.Json.JsonConvert.SerializeObject(objRequest)}"
                );
            }
        }

        public async Task<string> PostRequest(LinxCommerceJobParameter jobParameter, string identifier, string? route)
        {
            try
            {
                var client = CreateClient(
                    jobParameter,
                    route
                    );

                var response = await client.PostAsync(
                client.BaseAddress + route,
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(identifier),
                    Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                $"Request: {identifier}"
                );
            }
        }

        public async Task<string> PostRequest(LinxCommerceJobParameter jobParameter, int identifier, string? route)
        {
            try
            {
                var client = CreateClient(
                    jobParameter,
                    route
                    );

                var response = await client.PostAsync(
                    client.BaseAddress + route,
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(identifier),
                    Encoding.UTF8, "application/json")
                );

                if (response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();
                else
                    throw new Exception($"{response.StatusCode}");
            }
            catch (Exception ex)
            {
                throw new GeneralException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                $"Request: {identifier}"
                );
            }
        }

        private HttpClient CreateClient(LinxCommerceJobParameter? jobParameter, string? route)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{jobParameter.userAuthentication}:{jobParameter.keyAuthorization}");
            var client = _httpClientFactory.CreateClient("LinxCommerceAPI");
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + System.Convert.ToBase64String(plainTextBytes));

            return client;
        }
    }
}
