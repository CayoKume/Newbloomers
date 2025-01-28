using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxProdutosTabelasPrecosService : ILinxProdutosTabelasPrecosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxProdutosTabelasPrecos> _linxMicrovixRepositoryBase;
        private readonly ILinxProdutosTabelasPrecosRepository _linxProdutosTabelasPrecosRepository;
        private static ILinxProdutosTabelasPrecosServiceCache _linxProdutosTabelasPrecosServiceCache { get; set; } = new LinxProdutosTabelasPrecosServiceCache();

        public LinxProdutosTabelasPrecosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxProdutosTabelasPrecos> linxMicrovixRepositoryBase,
            ILinxProdutosTabelasPrecosRepository linxProdutosTabelasPrecosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxProdutosTabelasPrecosRepository = linxProdutosTabelasPrecosRepository;
        }

        public List<LinxProdutosTabelasPrecos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxProdutosTabelasPrecos>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxProdutosTabelasPrecos(
                        listValidations: validations,
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        id_tabela: records[i].Where(pair => pair.Key == "id_tabela").Select(pair => pair.Value).FirstOrDefault(),
                        precovenda: records[i].Where(pair => pair.Key == "precovenda").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | id_tabela: {records[i].Where(pair => pair.Key == "id_tabela").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | id_tabela: {records[i].Where(pair => pair.Key == "id_tabela").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? identificador2, string? cnpj_emp)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxProdutosTabelasPrecos);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters
                    .Replace("[0]", "0")
                    .Replace("[id_tabela]", identificador2)
                    .Replace("[cod_produto]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _linxProdutosTabelasPrecosRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
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

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<LinxProdutosTabelasPrecos> _listSomenteNovos = new List<LinxProdutosTabelasPrecos>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxProdutosTabelasPrecos);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys(jobParameter);
                var tables_ids = await _linxProdutosTabelasPrecosRepository.GetProductsTablesIds(jobParameter);

                foreach (var id_tabela in tables_ids)
                {
                    foreach (var cnpj_emp in cnpjs_emp)
                    {
                        string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(
                            jobParameter: jobParameter,
                            columnDate: "lastupdateon",
                            columnCompany: "cnpj_emp",
                            companyValue: cnpj_emp.doc_company
                        );

                        var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                    parametersList: parameters.Replace("[0]", timestamp).Replace("[id_tabela]", id_tabela),
                                    jobParameter: jobParameter,
                                    cnpj_emp: cnpj_emp.doc_company
                                );

                        string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                        var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _linxProdutosTabelasPrecosServiceCache);

                        if (xmls.Count() > 0)
                        {
                            var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                            if (_linxProdutosTabelasPrecosServiceCache.GetList().Count == 0)
                            {
                                var list_existentes = await _linxProdutosTabelasPrecosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                                _linxProdutosTabelasPrecosServiceCache.AddList(list_existentes);
                            }

                            _listSomenteNovos = _linxProdutosTabelasPrecosServiceCache.FiltrarList(listRecords);
                            if (_listSomenteNovos.Count() > 0)
                            {
                                _linxProdutosTabelasPrecosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                                for (int i = 0; i < _listSomenteNovos.Count; i++)
                                {
                                    var key = _linxProdutosTabelasPrecosServiceCache.GetKey(_listSomenteNovos[i]);
                                    if (_linxProdutosTabelasPrecosServiceCache.GetDictionaryXml().ContainsKey(key))
                                    {
                                        var xml = _linxProdutosTabelasPrecosServiceCache.GetDictionaryXml()[key];
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
                _linxProdutosTabelasPrecosServiceCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
