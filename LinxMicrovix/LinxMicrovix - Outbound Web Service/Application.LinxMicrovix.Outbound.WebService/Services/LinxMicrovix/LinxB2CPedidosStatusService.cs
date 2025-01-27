using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxB2CPedidosStatusService : ILinxB2CPedidosStatusService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxB2CPedidosStatus> _linxMicrovixRepositoryBase;
        private readonly ILinxB2CPedidosStatusRepository _linxB2CPedidosStatusRepository;
        private static ILinxB2CPedidosStatusServiceCache _linxB2CPedidosStatusServiceCache { get; set; } = new LinxB2CPedidosStatusServiceCache();

        public LinxB2CPedidosStatusService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxB2CPedidosStatus> linxMicrovixRepositoryBase,
            ILinxB2CPedidosStatusRepository linxB2CPedidosStatusRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxB2CPedidosStatusRepository = linxB2CPedidosStatusRepository;
        }

        public List<LinxB2CPedidosStatus?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxB2CPedidosStatus>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxB2CPedidosStatus(
                        listValidations: validations,
                        id: records[i].Where(pair => pair.Key == "id").Select(pair => pair.Value).FirstOrDefault(),
                        id_status: records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault(),
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        data_hora: records[i].Where(pair => pair.Key == "data_hora").Select(pair => pair.Value).FirstOrDefault(),
                        anotacao: records[i].Where(pair => pair.Key == "anotacao").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - id_pedido: {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} | id_status: {records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new InternalException(
                        stage: EnumStages.DeserializeXMLToObject,
                        error: EnumError.Exception,
                        level: EnumMessageLevel.Error,
                        message: $"Error when convert record - id_pedido: {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} | id_status: {records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<LinxB2CPedidosStatus> _listSomenteNovos = new List<LinxB2CPedidosStatus>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxB2CPedidosStatus);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(
                    jobParameter: jobParameter,
                    columnDate: "lastupdateon"
                );

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", timestamp),
                            jobParameter: jobParameter,
                            cnpj_emp: jobParameter.docMainCompany
                        );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _linxB2CPedidosStatusServiceCache);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_linxB2CPedidosStatusServiceCache.GetList().Count == 0)
                    {
                        var list_existentes = await _linxB2CPedidosStatusRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _linxB2CPedidosStatusServiceCache.AddList(list_existentes);
                    }

                    _listSomenteNovos = _linxB2CPedidosStatusServiceCache.FiltrarList(listRecords);
                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxB2CPedidosStatusRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            var key = _linxB2CPedidosStatusServiceCache.GetKey(_listSomenteNovos[i]);
                            if (_linxB2CPedidosStatusServiceCache.GetDictionaryXml().ContainsKey(key))
                            {
                                var xml = _linxB2CPedidosStatusServiceCache.GetDictionaryXml()[key];
                                _logger.AddRecord(key, xml);
                            }
                        }

                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);

                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                    }
                    else
                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
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
                _linxB2CPedidosStatusServiceCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
