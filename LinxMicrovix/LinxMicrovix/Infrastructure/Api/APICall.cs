using Application.IntegrationsCore.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Entities.Parameters;
using Domain.IntegrationsCore.Exceptions;
using System.Net;
using static Domain.IntegrationsCore.Exceptions.APIErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Infrastructure.Api
{
    public class APICall : IAPICall
    {
        protected readonly ILoggerAuditoriaService _logger;

        public APICall(ILoggerAuditoriaService logger)
        {
            _logger = logger;
        }

        public async Task<string?> PostAsync(LinxMicrovixJobParameter jobParameter, string? body)
        {
            string msgErrorDefault = $"Error when querying endpoint: {jobParameter.jobName} on microvix webservice CallAPIAsync method";

            try
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(body);
                var request = CreateClient(jobParameter, bytes);

                Stream stream = await request.GetRequestStreamAsync();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                var response = (HttpWebResponse)await request.GetResponseAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new StreamReader(response.GetResponseStream()).ReadToEnd().Replace("'", "");
                }
                else
                    throw new LoggerException(
                                 idError: EnumIdError.EndPointReturnEmpty,
                                 level: EnumIdLogLevel.Error,
                                 steps: EnumIdSteps.Default,
                                 message_log_detalhes_da_ocorrencia: $" {msgErrorDefault} .\n A API retorou HttpStatusCode:'{response.StatusCode}' quando era esperado '{HttpStatusCode.OK}' "
                               )
                             .AddLog(EnumIdLogLevel.Debug, $"body:{body}"
                                            , EnumIdError.EndPointReturnEmpty);
            }
            catch (Exception ex) when (ex is not LoggerException)
            {
                throw new LoggerException(
                    EnumIdError.EndPointException,
                    EnumIdLogLevel.Error,
                    EnumIdSteps.Default,
                    $" {msgErrorDefault} .\n CallAPIAsync retornou a Exception:'{ex.Message}' "
                );
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
                throw new LoggerException(
                    EnumIdError.EndPointException,
                    EnumIdLogLevel.Error,
                    EnumIdSteps.Default,
                    $" Error when creating request to query the endpoint: {jobParameter.jobName} on microvix webservice - Exception:'{ex.Message}' "
                );
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
