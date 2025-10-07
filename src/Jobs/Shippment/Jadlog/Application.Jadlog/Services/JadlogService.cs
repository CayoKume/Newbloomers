using Application.Core.Interfaces;
using Application.Jadlog.Interfaces;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Jadlog.Interfaces.Api;
using Domain.Jadlog.Interfaces.Repositorys;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace Application.Jadlog.Services
{
    public class JadlogService : IJadlogService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IValidator<Domain.Jadlog.DTOs.Consulta> _validator;
        private readonly IJadlogRepository _jadlogRepository;

        public JadlogService(IJadlogRepository jadlogRepository, IAPICall apiCall, ILoggerService logger, IValidator<Domain.Jadlog.DTOs.Consulta> validator) =>
            (_jadlogRepository, _apiCall, _logger, _validator) = (jadlogRepository, apiCall, logger, validator);

        public async Task<bool?> CancelOrder()
        {
            //Refatorar Aqui (retirar try catches)

            try
            {
                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    //stage: ex.Stage,
                    //error: ex.Error,
                    //log//level: ex.MessageLevel,
                    message: ex.Message
                    //exceptionMessage: ex.ExceptionMessage
                    //commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (GeneralException ex)
            {
                _logger.AddMessage(
                    //stage: ex.stage,
                    //error: ex.Error,
                    //log//level: ex.MessageLevel,
                    message: ex.Message
                    //exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method"
                    //exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public async Task<bool?> InsertOrder()
        {
            _logger
               .Clear()
               .AddLog(EnumJob.JadlogSendOrders);

            var _listSomenteNovos = new List<Domain.Jadlog.Entities.OrderSent>();
            var orders = await _jadlogRepository.GetInvoicedOrders();
               
            if (orders.Count() > 0)
            {
                foreach (var order in orders)
                {
                    try
                    {
                        var parameter = await _jadlogRepository.GetParameters(order.tomador.doc_company, order.TIPO_SERVICO);
                        var jObject = BuildJObject(parameter, order);
                        var response = await _apiCall.PostAsync(contentType: "application/json", clientName: "JadlogAPI", rote: "embarcador/api/pedido/incluir", token: parameter.token, jObj: jObject);
                        var pedido = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Jadlog.DTOs.Response.Rootobject>(response);
                        _listSomenteNovos.Add(new Domain.Jadlog.Entities.OrderSent(pedido: pedido, cod_pedido: order.number, request: response));
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }                
                }

                if (_listSomenteNovos.Count() > 0)
                {
                    await _jadlogRepository.InsertResponse(_listSomenteNovos, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public Task<bool?> InsertTreatment()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchDACTEXml()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchPickupPoints()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchQRCodePickupDropoff()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchShippingValue()
        {
            throw new NotImplementedException();
        }

        public async Task<bool?> SearchTrackingHistory()
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.JadlogSearchTrackingHistory);

                var consultas = new List<Domain.Jadlog.DTOs.Consulta>();
                var trackings = new List<Domain.Jadlog.Entities.Consulta>();
                var parameters = await _jadlogRepository.GetParameters();
                var shipments = await _jadlogRepository.GetShipmentIds();

                foreach (var parameter in parameters)
                {
                    var listExistingShipments = shipments.Where(x => x.product == parameter.product && x.doc_company == parameter.doc_company).ToList();

                    for (int i = 0; i < listExistingShipments.Count(); i += 100)
                    {
                        var lote = listExistingShipments.Skip(i).Take(100).ToList();
                        var consultaObj = new JObject { 
                            { 
                                "consulta", JArray.FromObject(lote.Select(s => new { shipmentId = s.shipment_id })) 
                            } 
                        };

                        var response = await _apiCall.PostAsync(
                                        rote: "embarcador/api/tracking/consultar",
                                        token: parameter.token,
                                        clientName: "JadlogTechAPI",
                                        contentType: "application/json",
                                        jObj: consultaObj
                                    );

                        var results = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Jadlog.DTOs.Root>(response);

                        consultas.AddRange(results.consulta.Where(x => !listExistingShipments.Any(y => 
                                y.shipment_id == x.shipmentId &&
                                y.eventos.Count() == x.tracking.eventos
                                                                .GroupBy(i => new { i.data, i.status, i.unidade })
                                                                .Select(g => g.First())
                                                                .Count())
                            )
                        );
                    }
                }

                foreach (var consulta in consultas)
                {
                    var validations = _validator.Validate(consulta);

                    foreach (var error in validations.Errors)
                    {
                        _logger.AddMessage(
                            //stage: EnumStages.DeserializeXMLToObject,
                            //error: EnumError.Validation,
                            //log//level: EnumMessageLevel.Warning,
                            message: $"Error when convert record - shipmentId: {consulta.shipmentId} | tracking_code: {consulta.tracking.codigo}\n{error}"
                        );
                    }

                    trackings.Add(new Domain.Jadlog.Entities.Consulta(consulta, Newtonsoft.Json.JsonConvert.SerializeObject(consulta.tracking)));
                }

                if (trackings.Count() > 0)
                {
                    await _jadlogRepository.BulkInsertIntoTableRaw(trackings, _logger.GetExecutionGuid());

                    trackings.ForEach(s =>
                            _logger.AddRecord(
                                s.shipmentId.ToString(),
                                s.Responses
                                    .Where(pair => pair.Key == s.shipmentId)
                                    .Select(pair => pair.Value)
                                    .FirstOrDefault()
                            )
                        );

                    _logger.AddMessage(
                                $"Concluída com sucesso: {trackings.Count()} registro(s) novo(s) inserido(s)!"
                            );
                }
                else
                    _logger.AddMessage(
                        $"Concluída com sucesso: {trackings.Count()} registro(s) novo(s) inserido(s)!"
                    );

                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    //stage: ex.Stage,
                    //error: ex.Error,
                    //log//level: ex.MessageLevel,
                    message: ex.Message
                    //exceptionMessage: ex.ExceptionMessage
                    //commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (GeneralException ex)
            {
                _logger.AddMessage(
                    //stage: ex.stage,
                    //error: ex.Error,
                    //log//level: ex.MessageLevel,
                    message: ex.Message
                    //exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method"
                    //exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        private JObject? BuildJObject(Domain.Jadlog.Entities.Parameters parameter, Domain.Jadlog.Entities.Order order)
        {
            return new JObject
            {
                { "codCliente", parameter.cod_client },
                { "conteudo", order.itens.First().description_product.Replace("Ç","C").Replace("Ú","U").PadRight(25).Substring(0, order.itens.First().description_product.Length > 24 ? 24 : order.itens.First().description_product.Length) },
                { "pedido", new JArray (order.number) },
                { "totPeso", order.itens.First().weight_product },
                { "totValor", order.itens.First().amount_product },
                { "obs", null },
                { "modalidade", parameter.modality },
                { "contaCorrente", parameter.account },
                { "tpColeta", "K" },
                { "tipoFrete", null },
                { "cdUnidadeOri", "1099" },
                { "cdUnidadeDes", null },
                { "cdPickupOri", null },
                { "cdPickupDes", null },
                { "nrContrato", null },
                { "servico", null },
                { "shipmentId", null },
                { "vlColeta", null },
                { "des", new JObject {
                        { "nome", order.client.reason_client },
                        { "cnpjCpf", order.client.doc_client },
                        { "ie", order.client.state_registration_client },
                        { "endereco", order.client.address_client },
                        { "numero", order.client.street_number_client },
                        { "compl", order.client.complement_address_client },
                        { "bairro", order.client.neighborhood_client },
                        { "cidade", order.client.city_client },
                        { "uf", order.client.uf_client },
                        { "cep", order.client.zip_code_client },
                        { "fone", null },
                        { "cel", order.client.fone_client },
                        { "email", order.client.email_client },
                        { "contato", order.client.reason_client }
                    }
                },
                { "rem", new JObject {
                        { "nome", order.company.reason_company },
                        { "cnpjCpf", order.company.doc_company },
                        { "ie", order.company.state_registration_company },
                        { "endereco", order.company.address_company },
                        { "numero", order.company.street_number_company },
                        { "compl", order.company.complement_address_company },
                        { "bairro", order.company.neighborhood_company },
                        { "cidade", order.company.city_company },
                        { "uf", order.company.uf_company },
                        { "cep", order.company.zip_code_company },
                        { "fone", null },
                        { "cel", order.company.fone_company },
                        { "email", order.company.email_company },
                        { "contato", order.company.name_company }
                    }
                },
                { "tomador", new JObject {
                        { "nome", order.tomador.reason_company },
                        { "cnpjCpf", order.tomador.doc_company },
                        { "ie", order.tomador.state_registration_company },
                        { "endereco", order.tomador.address_company },
                        { "numero", order.tomador.street_number_company },
                        { "compl", order.tomador.complement_address_company },
                        { "bairro", order.tomador.neighborhood_company },
                        { "cidade", order.tomador.city_company },
                        { "uf", order.tomador.uf_company },
                        { "cep", order.tomador.zip_code_company },
                        { "fone", null },
                        { "cel", order.tomador.fone_company },
                        { "email", order.tomador.email_company },
                        { "contato", order.tomador.name_company }
                    }
                },
                { "dfe", new JArray(
                    new JObject {
                        { "cfop", order.cfop },
                        { "danfeCte", order.invoice.key_nfe_nf },
                        { "nrDoc", order.invoice.number_nf },
                        { "serie", order.invoice.serie_nf },
                        { "tpDocumento", 2 },
                        { "valor", order.invoice.amount_nf },
                    })
                },
                { "volume", new JArray(
                    new JObject {
                        { "altura", 1 },
                        { "comprimento", 1 },
                        { "identificador", order.number },
                        { "largura", 1 },
                        { "peso", 1 }
                    })
                },
            };
        }
    }
}
