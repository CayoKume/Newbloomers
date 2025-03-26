using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
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
    public class B2CConsultaTransportadoresService : IB2CConsultaTransportadoresService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaTransportadores> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaTransportadoresRepository _b2cConsultaTransportadoresRepository;
        private static List<string?> _b2cConsultaTransportadoresCache { get; set; } = new List<string?>();

        public B2CConsultaTransportadoresService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaTransportadores> linxMicrovixRepositoryBase,
            IB2CConsultaTransportadoresRepository b2cConsultaTransportadoresRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaTransportadoresRepository = b2cConsultaTransportadoresRepository;
        }

        public List<B2CConsultaTransportadores?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaTransportadores>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaTransportadores(
                        listValidations: validations,
                        cod_transportador: records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).FirstOrDefault(),
                        nome: records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).FirstOrDefault(),
                        nome_fantasia: records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_pessoa: records[i].Where(pair => pair.Key == "tipo_pessoa").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_transportador: records[i].Where(pair => pair.Key == "tipo_transportador").Select(pair => pair.Value).FirstOrDefault(),
                        endereco: records[i].Where(pair => pair.Key == "endereco").Select(pair => pair.Value).FirstOrDefault(),
                        numero_rua: records[i].Where(pair => pair.Key == "numero_rua").Select(pair => pair.Value).FirstOrDefault(),
                        bairro: records[i].Where(pair => pair.Key == "bairro").Select(pair => pair.Value).FirstOrDefault(),
                        cep: records[i].Where(pair => pair.Key == "cep").Select(pair => pair.Value).FirstOrDefault(),
                        cidade: records[i].Where(pair => pair.Key == "cidade").Select(pair => pair.Value).FirstOrDefault(),
                        uf: records[i].Where(pair => pair.Key == "uf").Select(pair => pair.Value).FirstOrDefault(),
                        documento: records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault(),
                        fone: records[i].Where(pair => pair.Key == "fone").Select(pair => pair.Value).FirstOrDefault(),
                        email: records[i].Where(pair => pair.Key == "email").Select(pair => pair.Value).FirstOrDefault(),
                        pais: records[i].Where(pair => pair.Key == "pais").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cod_transportador: {records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).FirstOrDefault()} | nome_fantasia: {records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_transportador: {records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).FirstOrDefault()} | nome_fantasia: {records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[documento]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaTransportadoresRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<B2CConsultaTransportadores> _listSomenteNovos = new List<B2CConsultaTransportadores>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaTransportadores);

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
                    var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                    if (xmls.Count() > 0)
                    {
                        var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                        //if (_b2cConsultaTransportadoresCache.GetList().Count == 0)
                        //{
                        //    var list_existentes = await _b2cConsultaTransportadoresRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        //    _b2cConsultaTransportadoresCache.AddList(list_existentes);
                        //}

                        //_listSomenteNovos = _b2cConsultaTransportadoresCache.FiltrarList(listRecords);

                        if (_listSomenteNovos.Count() > 0)
                        {
                            _b2cConsultaTransportadoresRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);

                            //for (int i = 0; i < _listSomenteNovos.Count; i++)
                            //{
                            //    var key = _b2cConsultaTransportadoresCache.GetKey(_listSomenteNovos[i]);
                            //    if (_b2cConsultaTransportadoresCache.GetDictionaryXml().ContainsKey(key))
                            //    {
                            //        var xml = _b2cConsultaTransportadoresCache.GetDictionaryXml()[key];
                            //        _logger.AddRecord(key, xml);
                            //    }
                            //}

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
            }

            return true;
        }
    }
}
