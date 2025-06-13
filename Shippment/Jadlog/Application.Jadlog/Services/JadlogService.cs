using Application.IntegrationsCore.Interfaces;
using Application.Jadlog.Interfaces;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
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
            try
            {
                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
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
            try
            {
                return true;
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

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
                            stage: EnumStages.DeserializeXMLToObject,
                            error: EnumError.Validation,
                            logLevel: EnumMessageLevel.Warning,
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
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        //private JObject? BuildBodyRequest(Domain.Jadlog.Entities.Parameters parameters, Domain.Jadlog.Entities.Order order)
        //{

        //}
    }
}
