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
    public class LinxNaturezaOperacaoService : ILinxNaturezaOperacaoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxNaturezaOperacao> _linxMicrovixRepositoryBase;
        private readonly ILinxNaturezaOperacaoRepository _linxNaturezaOperacaoRepository;
        private static List<string?> _linxNaturezaOperacaoCache { get; set; } = new List<string?>();

        public LinxNaturezaOperacaoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<LinxNaturezaOperacao> linxMicrovixRepositoryBase,
            ILinxNaturezaOperacaoRepository linxNaturezaOperacaoRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxNaturezaOperacaoRepository = linxNaturezaOperacaoRepository;
        }

        public List<LinxNaturezaOperacao?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxNaturezaOperacao>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxNaturezaOperacao(
                        listValidations: validations,
                        cod_natureza_operacao: records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        descricao: records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault(),
                        soma_relatorios: records[i].Where(pair => pair.Key == "soma_relatorios").Select(pair => pair.Value).FirstOrDefault(),
                        operacao: records[i].Where(pair => pair.Key == "operacao").Select(pair => pair.Value).FirstOrDefault(),
                        inativa: records[i].Where(pair => pair.Key == "inativa").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_ipi: records[i].Where(pair => pair.Key == "calcula_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_iss: records[i].Where(pair => pair.Key == "calcula_iss").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_irrf: records[i].Where(pair => pair.Key == "calcula_irrf").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_preco: records[i].Where(pair => pair.Key == "tipo_preco").Select(pair => pair.Value).FirstOrDefault(),
                        atualiza_custo: records[i].Where(pair => pair.Key == "atualiza_custo").Select(pair => pair.Value).FirstOrDefault(),
                        transferencia: records[i].Where(pair => pair.Key == "transferencia").Select(pair => pair.Value).FirstOrDefault(),
                        baixar_estoque: records[i].Where(pair => pair.Key == "baixar_estoque").Select(pair => pair.Value).FirstOrDefault(),
                        consumo_proprio: records[i].Where(pair => pair.Key == "consumo_proprio").Select(pair => pair.Value).FirstOrDefault(),
                        contabiliza_cmv: records[i].Where(pair => pair.Key == "contabiliza_cmv").Select(pair => pair.Value).FirstOrDefault(),
                        despesa: records[i].Where(pair => pair.Key == "despesa").Select(pair => pair.Value).FirstOrDefault(),
                        atualiza_custo_medio: records[i].Where(pair => pair.Key == "atualiza_custo_medio").Select(pair => pair.Value).FirstOrDefault(),
                        exige_nf_origem: records[i].Where(pair => pair.Key == "exige_nf_origem").Select(pair => pair.Value).FirstOrDefault(),
                        integra_contabilidade: records[i].Where(pair => pair.Key == "integra_contabilidade").Select(pair => pair.Value).FirstOrDefault(),
                        id_obs: records[i].Where(pair => pair.Key == "id_obs").Select(pair => pair.Value).FirstOrDefault(),
                        venda_futura: records[i].Where(pair => pair.Key == "venda_futura").Select(pair => pair.Value).FirstOrDefault(),
                        base_icms_considera_ipi: records[i].Where(pair => pair.Key == "base_icms_considera_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        permite_escolha_historico: records[i].Where(pair => pair.Key == "permite_escolha_historico").Select(pair => pair.Value).FirstOrDefault(),
                        import_produtos: records[i].Where(pair => pair.Key == "import_produtos").Select(pair => pair.Value).FirstOrDefault(),
                        deposito_reserva_venda: records[i].Where(pair => pair.Key == "deposito_reserva_venda").Select(pair => pair.Value).FirstOrDefault(),
                        exibe_nfe: records[i].Where(pair => pair.Key == "exibe_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        faturamento_antecipado: records[i].Where(pair => pair.Key == "faturamento_antecipado").Select(pair => pair.Value).FirstOrDefault(),
                        exibir_informacoes_imposto: records[i].Where(pair => pair.Key == "exibir_informacoes_imposto").Select(pair => pair.Value).FirstOrDefault(),
                        gera_garantia_nacional: records[i].Where(pair => pair.Key == "gera_garantia_nacional").Select(pair => pair.Value).FirstOrDefault(),
                        transferencia_deposito: records[i].Where(pair => pair.Key == "transferencia_deposito").Select(pair => pair.Value).FirstOrDefault(),
                        venda_diferencial_aliquota: records[i].Where(pair => pair.Key == "venda_diferencial_aliquota").Select(pair => pair.Value).FirstOrDefault(),
                        insere_obs_pis_cofins: records[i].Where(pair => pair.Key == "insere_obs_pis_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        diferencial_ativo_consumo: records[i].Where(pair => pair.Key == "diferencial_ativo_consumo").Select(pair => pair.Value).FirstOrDefault(),
                        recusa_de: records[i].Where(pair => pair.Key == "recusa_de").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_ws: records[i].Where(pair => pair.Key == "codigo_ws").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cod_natureza_operacao: {records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_natureza_operacao: {records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxNaturezaOperacao);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[cod_natureza_operacao]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _linxNaturezaOperacaoRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
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
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxNaturezaOperacao);

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

                    if (_linxNaturezaOperacaoCache.Count == 0)
                        _linxNaturezaOperacaoCache = await _linxNaturezaOperacaoRepository.GetRegistersExists();

                    var _listSomenteNovos = listRecords.Where(x => !_linxNaturezaOperacaoCache.Any(y => 
                        y == x.recordKey
                    )).ToList();
                    
                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxNaturezaOperacaoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _linxNaturezaOperacaoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

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
