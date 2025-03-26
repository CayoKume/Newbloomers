using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
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
    public class LinxProdutosPromocoesService : ILinxProdutosPromocoesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosPromocoes> _linxMicrovixRepositoryBase;
        private readonly ILinxProdutosPromocoesRepository _linxProdutosPromocoesRepository;
        private static List<string?> _linxProdutosPromocoesCache { get; set; } = new List<string?>();

        public LinxProdutosPromocoesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<LinxProdutosPromocoes> linxMicrovixRepositoryBase,
            ILinxProdutosPromocoesRepository linxProdutosPromocoesRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxProdutosPromocoesRepository = linxProdutosPromocoesRepository;
        }

        public List<LinxProdutosPromocoes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxProdutosPromocoes>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxProdutosPromocoes(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        preco_promocao: records[i].Where(pair => pair.Key == "preco_promocao").Select(pair => pair.Value).FirstOrDefault(),
                        data_inicio_promocao: records[i].Where(pair => pair.Key == "data_inicio_promocao").Select(pair => pair.Value).FirstOrDefault(),
                        data_termino_promocao: records[i].Where(pair => pair.Key == "data_termino_promocao").Select(pair => pair.Value).FirstOrDefault(),
                        data_cadastro_promocao: records[i].Where(pair => pair.Key == "data_cadastro_promocao").Select(pair => pair.Value).FirstOrDefault(),
                        promocao_ativa: records[i].Where(pair => pair.Key == "promocao_ativa").Select(pair => pair.Value).FirstOrDefault(),
                        id_campanha: records[i].Where(pair => pair.Key == "id_campanha").Select(pair => pair.Value).FirstOrDefault(),
                        nome_campanha: records[i].Where(pair => pair.Key == "nome_campanha").Select(pair => pair.Value).FirstOrDefault(),
                        promocao_opcional: records[i].Where(pair => pair.Key == "promocao_opcional").Select(pair => pair.Value).FirstOrDefault(),
                        custo_total_campanha: records[i].Where(pair => pair.Key == "custo_total_campanha").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | nome_campanha: {records[i].Where(pair => pair.Key == "nome_campanha").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | nome_campanha: {records[i].Where(pair => pair.Key == "nome_campanha").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxProdutosPromocoes);

                var xmls = new List<Dictionary<string?, string?>>();
                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys();

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters
                                                .Replace("[data_cad_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}")
                                                .Replace("[data_cad_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}")
                                                .Replace("[data_vig_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}")
                                                .Replace("[data_vig_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}")
                                                .Replace("[promocao_ativa]", "N"),
                                jobParameter: jobParameter,
                                cnpj_emp: cnpj_emp.doc_company
                            );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                    xmls.AddRange(result);
                }

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_linxProdutosPromocoesCache.Count == 0)
                        _linxProdutosPromocoesCache = await _linxProdutosPromocoesRepository.GetRegistersExists(
                            jobParameter: jobParameter, 
                            registros: listRecords.Select(x => x.cod_produto).ToList()
                        );

                    var _listSomenteNovos = listRecords.Where(x => !_linxProdutosPromocoesCache.Any(y => 
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxProdutosPromocoesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(
                                key: _listSomenteNovos[i].recordKey, 
                                xml: _listSomenteNovos[i].recordXml
                            );
                        }

                        _linxProdutosPromocoesCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

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
