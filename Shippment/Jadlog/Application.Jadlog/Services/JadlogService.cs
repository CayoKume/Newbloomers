using Application.IntegrationsCore.Interfaces;
using Application.Jadlog.Interfaces;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.Jadlog.DTOs;
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
        private readonly IValidator<Consulta> _validator;
        private readonly IJadlogRepository _jadlogRepository;

        public JadlogService(IJadlogRepository jadlogRepository, IAPICall apiCall, ILoggerService logger, IValidator<Consulta> validator) =>
            (_jadlogRepository, _apiCall, _logger, _validator) = (jadlogRepository, apiCall, logger, validator);

        public Task<bool?> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> InsertOrder()
        {
            throw new NotImplementedException();
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

                var trackings = new List<Domain.Jadlog.Entities.Consulta>();
                var parameters = await _jadlogRepository.GetParameters();
                var shipments = await _jadlogRepository.GetShipmentIds();

                foreach (var parameter in parameters)
                {
                    var array = new JArray();

                    foreach (var shipment in shipments.Where(x => x.product == parameter.product && x.doc_company == parameter.doc_company))
                    {
                        array.Add(
                            new JObject
                            {
                                { "shipmentId", shipment.shipment_id }
                            }
                        );
                    }

                    var consultaObj = new JObject
                    {
                        { "consulta", array }
                    };

                    var response = await _apiCall.PostAsync(
                        rote: "embarcador/api/tracking/consultar",
                        token: parameter.token,
                        clientName: "JadlogTechAPI",
                        contentType: "application/json",
                        jObj: consultaObj
                    );

                    var results = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.Jadlog.DTOs.Root>(response);
                    
                    foreach (var consulta in results.consulta)
                    {
                        var validations = _validator.Validate(consulta);

                        if (validations.Errors.Count() > 0)
                        {
                            for (int j = 0; j < validations.Errors.Count(); j++)
                            {
                                _logger.AddMessage(
                                    stage: EnumStages.DeserializeXMLToObject,
                                    error: EnumError.Validation,
                                    logLevel: EnumMessageLevel.Warning,
                                    message: $"Error when convert record - shipmentId: {consulta.shipmentId} | tracking_code: {consulta.tracking.codigo}\n" +
                                             $"{validations.Errors[j]}"
                                );
                            }
                        }

                        trackings.Add(new Domain.Jadlog.Entities.Consulta(consulta, response)); 
                    }
                }

                if (trackings.Count > 0)
                {
                    //bulkinsert

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
    }
}
