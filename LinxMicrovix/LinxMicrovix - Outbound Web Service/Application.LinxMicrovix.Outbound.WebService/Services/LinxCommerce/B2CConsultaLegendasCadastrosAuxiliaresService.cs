using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaLegendasCadastrosAuxiliaresService : IB2CConsultaLegendasCadastrosAuxiliaresService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresRepository _b2cConsultaLegendasCadastrosAuxiliaresRepository;
        private static IB2CConsultaLegendasCadastrosAuxiliaresServiceCache _b2cConsultaLegendasCadastrosAuxiliaresCache { get; set; } = new B2CConsultaLegendasCadastrosAuxiliaresServiceCache();

        public B2CConsultaLegendasCadastrosAuxiliaresService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> linxMicrovixRepositoryBase,
            IB2CConsultaLegendasCadastrosAuxiliaresRepository b2cConsultaLegendasCadastrosAuxiliaresRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaLegendasCadastrosAuxiliaresRepository = b2cConsultaLegendasCadastrosAuxiliaresRepository;
        }

        public List<B2CConsultaLegendasCadastrosAuxiliares?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaLegendasCadastrosAuxiliares>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaLegendasCadastrosAuxiliares(
                        listValidations: validations,
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_setor: records[i].Where(pair => pair.Key == "legenda_setor").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_linha: records[i].Where(pair => pair.Key == "legenda_linha").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_marca: records[i].Where(pair => pair.Key == "legenda_marca").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_colecao: records[i].Where(pair => pair.Key == "legenda_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_grade1: records[i].Where(pair => pair.Key == "legenda_grade1").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_grade2: records[i].Where(pair => pair.Key == "legenda_grade2").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_espessura: records[i].Where(pair => pair.Key == "legenda_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_classificacao: records[i].Where(pair => pair.Key == "legenda_classificacao").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<B2CConsultaLegendasCadastrosAuxiliares> _listSomenteNovos = new List<B2CConsultaLegendasCadastrosAuxiliares>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaLegendasCadastrosAuxiliares);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys();

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0"),
                                jobParameter: jobParameter,
                                cnpj_emp: cnpj_emp.doc_company
                            );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _b2cConsultaLegendasCadastrosAuxiliaresCache);

                    if (xmls.Count() > 0)
                    {
                        var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                        if (_b2cConsultaLegendasCadastrosAuxiliaresCache.GetList().Count == 0)
                        {
                            var list_existentes = await _b2cConsultaLegendasCadastrosAuxiliaresRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                            _b2cConsultaLegendasCadastrosAuxiliaresCache.AddList(list_existentes);
                        }

                        _listSomenteNovos = _b2cConsultaLegendasCadastrosAuxiliaresCache.FiltrarList(listRecords);
                        if (_listSomenteNovos.Count() > 0)
                        {
                            _b2cConsultaLegendasCadastrosAuxiliaresRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                            for (int i = 0; i < _listSomenteNovos.Count; i++)
                            {
                                var key = _b2cConsultaLegendasCadastrosAuxiliaresCache.GetKey(_listSomenteNovos[i]);
                                if (_b2cConsultaLegendasCadastrosAuxiliaresCache.GetDictionaryXml().ContainsKey(key))
                                {
                                    var xml = _b2cConsultaLegendasCadastrosAuxiliaresCache.GetDictionaryXml()[key];
                                    _logger.AddRecord(key, xml);
                                }
                            }

                            await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

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

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
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
                //await _logger.CommitAllChanges();
                _b2cConsultaLegendasCadastrosAuxiliaresCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
