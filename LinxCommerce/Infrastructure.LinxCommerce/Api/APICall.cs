using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxCommerce.Interfaces.Api;
using System.Net;
using System.Text;
using static Domain.IntegrationsCore.Exceptions.APIErrorsExceptions;

namespace Infrastructure.LinxCommerce.Api
{
    public class APICall : IAPICall
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public APICall(IHttpClientFactory httpClientFactory) =>
            (_httpClientFactory) = (httpClientFactory);

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
            catch (APICallErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new APICallErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CallAPIAsync",
                    endpoint = jobParameter.jobName,
                    message = $"Error when querying endpoint: {jobParameter.jobName} on linxcommerce webservice",
                    exception = ex.Message
                };
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
            catch (APICallErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new APICallErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CallAPIAsync",
                    endpoint = jobParameter.jobName,
                    message = $"Error when querying endpoint: {jobParameter.jobName} on linxcommerce webservice",
                    exception = ex.Message
                };
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
            catch (APICallErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new APICallErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CallAPIAsync",
                    endpoint = jobParameter.jobName,
                    message = $"Error when querying endpoint: {jobParameter.jobName} on linxcommerce webservice",
                    exception = ex.Message
                };
            }
        }

        private HttpClient CreateClient(LinxCommerceJobParameter? jobParameter, string? route)
        {
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{jobParameter.userAuthentication}:{jobParameter.keyAuthorization}");
                var client = _httpClientFactory.CreateClient("LinxCommerceAPI");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + System.Convert.ToBase64String(plainTextBytes));

                return client;
            }
            catch (Exception ex)
            {
                throw new APICallErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CreateClient",
                    endpoint = jobParameter.jobName,
                    message = $"Error when creating request to query the endpoint: {route} on linxcommerce webservice",
                    exception = ex.Message
                };
            }
        }
    }
}
