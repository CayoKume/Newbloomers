using IntegrationsCore.Domain.Entities;
using System.Net;
using static IntegrationsCore.Domain.Exceptions.APIErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Api
{
    public class APICall : IAPICall
    {
        public async Task<string?> PostAsync(LinxMicrovixJobParameter jobParameter, string? body)
        {
            try
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(body);
                var request = CreateClient(jobParameter, bytes);

                Stream stream = await request.GetRequestStreamAsync();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                var response = (HttpWebResponse)await request.GetResponseAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                    return new StreamReader(response.GetResponseStream()).ReadToEnd().Replace("'", "");
                else
                    return String.Empty;
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
                    message = $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice",
                    exception = ex.Message
                };
            }
        }

        private HttpWebRequest CreateClient(LinxMicrovixJobParameter jobParameter, byte[] bytes)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://webapi.microvix.com.br/1.0/api/integracao/{jobParameter.jobName}");
                request.ContentType = "text/xml; encoding='utf-8'";
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                request.Timeout = 15 * 1000;

                return request;
            }
            catch (Exception ex)
            {
                throw new APICallErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = "CreateClient",
                    endpoint = jobParameter.jobName,
                    message = $"Error when creating request to query the endpoint: {jobParameter.jobName} on microvix webservice",
                    exception = ex.Message
                };
            }
        }
    }
}
