using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
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
                    throw new InternalException(
                        stage: EnumStages.PostAsync,
                        error: EnumError.EndPointException,
                        level: EnumMessageLevel.Error,
                        message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                 $"API return HttpStatusCode:'{response.StatusCode}' when it was expected '{HttpStatusCode.OK}'\n" +
                                 $"Request: {body}"
                    );
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.PostAsync,
                    error: EnumError.Exception,
                    level: EnumMessageLevel.Error,
                    message: $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice\n" +
                                $"Request: {body}"
                );
            }
        }

        private HttpWebRequest CreateClient(LinxAPIParam jobParameter, byte[] bytes)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://webapi.microvix.com.br/1.0/api/integracao/{jobParameter.jobName}");
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            request.Timeout = 15 * 1000;

            return request;
        }
    }
}
