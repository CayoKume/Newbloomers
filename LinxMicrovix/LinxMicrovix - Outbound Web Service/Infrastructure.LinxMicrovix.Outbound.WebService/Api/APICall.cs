using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using System.Net;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Api
{
    public class APICall : IAPICall
    {
        public async Task<string?> PostAsync(LinxAPIParam jobParameter, string? body)
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
                    throw new APIException(
                        message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice",
                        exceptionMessage: $"API return HttpStatusCode:'{response.StatusCode}' when it was expected '{HttpStatusCode.OK}'\n",
                        apiRequestResponse: $"Request: {body}"
                    );
            }
            catch (Exception ex)
            {
                throw new APIException(
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice - {ex.Message}",
                    exceptionMessage: ex.StackTrace,
                    apiRequestResponse: body
                );
            }
        }

        private HttpWebRequest CreateClient(LinxAPIParam jobParameter, byte[] bytes)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://webapi.microvix.com.br/1.0/api/integracao/{jobParameter.jobName}");
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            request.Timeout = 30 * 1000;

            return request;
        }
    }
}
