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
    public class B2CConsultaProdutosPromocaoService : IB2CConsultaProdutosPromocaoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosPromocao> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosPromocaoRepository _b2cConsultaProdutosPromocaoRepository;
        private static List<string?> _b2cConsultaProdutosPromocaoCache { get; set; } = new List<string?>();

        public B2CConsultaProdutosPromocaoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaProdutosPromocao> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosPromocaoRepository b2cConsultaProdutosPromocaoRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosPromocaoRepository = b2cConsultaProdutosPromocaoRepository;
        }

        public List<B2CConsultaProdutosPromocao?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaProdutosPromocao>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaProdutosPromocao(
                        listValidations: validations,
                        codigo_promocao: records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        preco: records[i].Where(pair => pair.Key == "preco").Select(pair => pair.Value).FirstOrDefault(),
                        data_inicio: records[i].Where(pair => pair.Key == "data_inicio").Select(pair => pair.Value).FirstOrDefault(),
                        data_termino: records[i].Where(pair => pair.Key == "data_termino").Select(pair => pair.Value).FirstOrDefault(),
                        data_cadastro: records[i].Where(pair => pair.Key == "data_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_campanha: records[i].Where(pair => pair.Key == "codigo_campanha").Select(pair => pair.Value).FirstOrDefault(),
                        promocao_opcional: records[i].Where(pair => pair.Key == "promocao_opcional").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        ativa: records[i].Where(pair => pair.Key == "ativa").Select(pair => pair.Value).FirstOrDefault(),
                        referencia: records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - codigo_promocao: {records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).FirstOrDefault()} | empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - codigo_promocao: {records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).FirstOrDefault()} | empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()}",
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
                    parametersList: parameters.Replace("[0]", "0").Replace("[codigoproduto]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaProdutosPromocaoRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
            IList<B2CConsultaProdutosPromocao> _listSomenteNovos = new List<B2CConsultaProdutosPromocao>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaProdutosPromocao);

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

                        //if (_b2cConsultaProdutosPromocaoCache.GetList().Count == 0)
                        //{
                        //    var list_existentes = await _b2cConsultaProdutosPromocaoRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        //    _b2cConsultaProdutosPromocaoCache.AddList(list_existentes);
                        //}

                        //_listSomenteNovos = _b2cConsultaProdutosPromocaoCache.FiltrarList(listRecords);

                        if (_listSomenteNovos.Count() > 0)
                        {
                            _b2cConsultaProdutosPromocaoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                            
                            //for (int i = 0; i < _listSomenteNovos.Count; i++)
                            //{
                            //    var key = _b2cConsultaProdutosPromocaoCache.GetKey(_listSomenteNovos[i]);
                            //    if (_b2cConsultaProdutosPromocaoCache.GetDictionaryXml().ContainsKey(key))
                            //    {
                            //        var xml = _b2cConsultaProdutosPromocaoCache.GetDictionaryXml()[key];
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
