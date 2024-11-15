using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Domain.IntegrationsCore.Entities.Parameters;
using System.Xml;
using static Domain.IntegrationsCore.Exceptions.APIErrorsExceptions;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Base
{
    public class LinxMicrovixServiceBase : ILinxMicrovixServiceBase
    {
        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter, string? parametersList, string? cnpj_emp)
        {
            return @$"<?xml version=""1.0"" encoding=""utf-8""?>
                          <LinxMicrovix>
                              <Authentication user=""{jobParameter.userAuthentication}"" password=""{jobParameter.userAuthentication}"" />
                              <ResponseFormat>xml</ResponseFormat>
                              <Command>
                                  <Name>{jobParameter.jobName}</Name>
                                  <Parameters>
                                      <Parameter id=""chave"">{jobParameter.keyAuthorization}</Parameter>
                                      <Parameter id=""cnpjEmp"">{cnpj_emp}</Parameter>
                                      {parametersList}
                                  </Parameters>
                              </Command>
                          </LinxMicrovix>";
        }

        public string? BuildBodyRequest(LinxMicrovixJobParameter jobParameter)
        {
            return @$"<?xml version=""1.0"" encoding=""utf-8""?>
                          <LinxMicrovix>
                              <Authentication user=""{jobParameter.userAuthentication}"" password=""{jobParameter.userAuthentication}"" />
                              <ResponseFormat>xml</ResponseFormat>
                              <Command>
                                  <Name>{jobParameter.jobName}</Name>
                                  <Parameters>
                                      <Parameter id=""chave"">{jobParameter.keyAuthorization}</Parameter>
                                  </Parameters>
                              </Command>
                          </LinxMicrovix>";
        }

        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response)
        {
            try
            {
                var listRegistros = new List<Dictionary<string?, string?>>();
                var xml = new XmlDocument();

                if (response != String.Empty)
                {
                    xml.LoadXml(response);

                    if (xml.GetElementsByTagName("ResponseSuccess")[0].ChildNodes[0].InnerText == "False")
                        throw new APIErrorException()
                        { 
                            project = jobParameter.projectName,
                            job = jobParameter.jobName,
                            response = response,
                            method = "DeserializeResponseToXML",
                            message = "Error unrealizing XML",
                            api_error_message = xml.GetElementsByTagName("Message")[0].ChildNodes[0].InnerText,
                            exception = ""
                        };

                    if (xml.GetElementsByTagName("R").Count > 0)
                    {
                        Parallel.For(0, xml.GetElementsByTagName("R").Count, row =>
                        {
                            var registro = new Dictionary<string?, string?>();
                            var c0 = xml.GetElementsByTagName("C")[0];
                            var rrow = xml.GetElementsByTagName("R")[row];
                            for (int col = 0; col < c0.ChildNodes.Count; col++)
                            {
                                string? key = c0.ChildNodes[col].InnerText;
                                string? value = rrow.ChildNodes[col].InnerText.Replace("'", "''");

                                registro.Add(key, value);
                            }
                            listRegistros.Add(registro);
                        });

                        return listRegistros;
                    }
                    else
                        return listRegistros;
                }
                return listRegistros;
            }
            catch (APIErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new APIErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = $"DeserializeXML",
                    response = response,
                    message = "Error when unrealizing response to records list",
                    api_error_message = "",
                    exception = ex.Message
                };
            }
        }

        public List<Dictionary<string?, string?>> DeserializeResponseToXML(LinxMicrovixJobParameter jobParameter, string? response, ICacheBase entityCache)
        {
            try
            {
                var listRegistros = new List<Dictionary<string?, string?>>();
                var xml = new XmlDocument();

                if (response != String.Empty)
                {
                    xml.LoadXml(response);

                    if (xml.GetElementsByTagName("ResponseSuccess")[0].ChildNodes[0].InnerText == "False")
                        throw new APIErrorException()
                        {
                            project = jobParameter.projectName,
                            job = jobParameter.jobName,
                            response = response,
                            method = "DeserializeResponseToXML",
                            message = "Error unrealizing XML",
                            api_error_message = xml.GetElementsByTagName("Message")[0].ChildNodes[0].InnerText,
                            exception = ""
                        };

                    if (xml.GetElementsByTagName("R").Count > 0)
                    {
                        Parallel.For(0, xml.GetElementsByTagName("R").Count, row =>
                        {
                            var registro = new Dictionary<string?, string?>();
                            var c0 = xml.GetElementsByTagName("C")[0];
                            var rrow = xml.GetElementsByTagName("R")[row];
                            for (int col = 0; col < c0.ChildNodes.Count; col++)
                            {
                                string? key = c0.ChildNodes[col].InnerText;
                                string? value = rrow.ChildNodes[col].InnerText.Replace("'", "''");

                                registro.Add(key, value);
                            }

                            var KeyInDictionary = entityCache.GetKeyInDictionary(registro);
                            string text_xml_row = rrow.InnerXml;
                            entityCache.AddCacheXml(KeyInDictionary, text_xml_row);

                            listRegistros.Add(registro);
                        });

                        return listRegistros;
                    }
                    else
                        return listRegistros;
                }
                return listRegistros;
            }
            catch (APIErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new APIErrorException()
                {
                    project = jobParameter.projectName,
                    job = jobParameter.jobName,
                    method = $"DeserializeXML",
                    response = response,
                    message = "Error when unrealizing response to records list",
                    api_error_message = "",
                    exception = ex.Message
                };
            }
        }

    }
}
