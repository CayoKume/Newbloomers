using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaNFeSituacaoService : IB2CConsultaNFeSituacaoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaNFeSituacao> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaNFeSituacaoRepository _b2cConsultaNFeSituacaoRepository;
        private static List<string?> _b2cConsultaNFeSituacaoCache { get; set; } = new List<string?>();

        public B2CConsultaNFeSituacaoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaNFeSituacao> linxMicrovixRepositoryBase,
            IB2CConsultaNFeSituacaoRepository b2cConsultaNFeSituacaoRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaNFeSituacaoRepository = b2cConsultaNFeSituacaoRepository;
        }

        public List<B2CConsultaNFeSituacao?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaNFeSituacao>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaNFeSituacao(
                        listValidations: validations,
                        id_nfe_situacao: records[i].Where(pair => pair.Key == "id_nfe_situacao").Select(pair => pair.Value).FirstOrDefault(),
                        descricao: records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
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
                                message: $"Error when convert record - id_nfe_situacao: {records[i].Where(pair => pair.Key == "id_nfe_situacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - id_nfe_situacao: {records[i].Where(pair => pair.Key == "id_nfe_situacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaNFeSituacao);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", "0"),
                            jobParameter: jobParameter,
                            cnpj_emp: jobParameter.docMainCompany
                        );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaNFeSituacaoCache.Count == 0)
                        _b2cConsultaNFeSituacaoCache = await _b2cConsultaNFeSituacaoRepository.GetRegistersExists(
                            jobParameter: jobParameter, 
                            registros: listRecords
                                        .Select(x => x.id_nfe_situacao)
                                        .ToList()
                        );

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaNFeSituacaoCache.Any(y => 
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaNFeSituacaoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaNFeSituacaoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                    }
                    else
                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                }
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
