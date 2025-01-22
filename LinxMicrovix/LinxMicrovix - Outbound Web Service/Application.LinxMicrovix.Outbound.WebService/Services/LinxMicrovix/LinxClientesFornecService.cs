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
    public class LinxClientesFornecService : ILinxClientesFornecService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxClientesFornec> _linxMicrovixRepositoryBase;
        private readonly ILinxClientesFornecRepository _linxClientesFornecRepository;
        private static ILinxClientesFornecServiceCache _linxClientesFornecServiceCache { get; set; } = new LinxClientesFornecServiceCache();

        public LinxClientesFornecService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxClientesFornec> linxMicrovixRepositoryBase,
            ILinxClientesFornecRepository linxClientesFornecRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxClientesFornecRepository = linxClientesFornecRepository;
        }

        public List<LinxClientesFornec?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxClientesFornec>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxClientesFornec(
                        listValidations: validations,
                        cod_cliente: records[i].Where(pair => pair.Key == "cod_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        razao_cliente: records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        nome_cliente: records[i].Where(pair => pair.Key == "nome_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        doc_cliente: records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_cliente: records[i].Where(pair => pair.Key == "tipo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        endereco_cliente: records[i].Where(pair => pair.Key == "endereco_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        numero_rua_cliente: records[i].Where(pair => pair.Key == "numero_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        complement_end_cli: records[i].Where(pair => pair.Key == "complement_end_cli").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_cliente: records[i].Where(pair => pair.Key == "bairro_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cep_cliente: records[i].Where(pair => pair.Key == "cep_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_cliente: records[i].Where(pair => pair.Key == "cidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        uf_cliente: records[i].Where(pair => pair.Key == "uf_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        pais: records[i].Where(pair => pair.Key == "pais").Select(pair => pair.Value).FirstOrDefault(),
                        fone_cliente: records[i].Where(pair => pair.Key == "fone_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        email_cliente: records[i].Where(pair => pair.Key == "email_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        sexo: records[i].Where(pair => pair.Key == "sexo").Select(pair => pair.Value).FirstOrDefault(),
                        data_cadastro: records[i].Where(pair => pair.Key == "data_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        data_nascimento: records[i].Where(pair => pair.Key == "data_nascimento").Select(pair => pair.Value).FirstOrDefault(),
                        cel_cliente: records[i].Where(pair => pair.Key == "cel_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        inscricao_estadual: records[i].Where(pair => pair.Key == "inscricao_estadual").Select(pair => pair.Value).FirstOrDefault(),
                        incricao_municipal: records[i].Where(pair => pair.Key == "incricao_municipal").Select(pair => pair.Value).FirstOrDefault(),
                        identidade_cliente: records[i].Where(pair => pair.Key == "identidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cartao_fidelidade: records[i].Where(pair => pair.Key == "cartao_fidelidade").Select(pair => pair.Value).FirstOrDefault(),
                        cod_ibge_municipio: records[i].Where(pair => pair.Key == "cod_ibge_municipio").Select(pair => pair.Value).FirstOrDefault(),
                        classe_cliente: records[i].Where(pair => pair.Key == "classe_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        matricula_conveniado: records[i].Where(pair => pair.Key == "matricula_conveniado").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_cadastro: records[i].Where(pair => pair.Key == "tipo_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        empresa_cadastro: records[i].Where(pair => pair.Key == "empresa_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        id_estado_civil: records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault(),
                        fax_cliente: records[i].Where(pair => pair.Key == "fax_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        site_cliente: records[i].Where(pair => pair.Key == "site_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cliente_anonimo: records[i].Where(pair => pair.Key == "cliente_anonimo").Select(pair => pair.Value).FirstOrDefault(),
                        limite_compras: records[i].Where(pair => pair.Key == "limite_compras").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_ws: records[i].Where(pair => pair.Key == "codigo_ws").Select(pair => pair.Value).FirstOrDefault(),
                        limite_credito_compra: records[i].Where(pair => pair.Key == "limite_credito_compra").Select(pair => pair.Value).FirstOrDefault(),
                        id_classe_fiscal: records[i].Where(pair => pair.Key == "id_classe_fiscal").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        mae: records[i].Where(pair => pair.Key == "mae").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - doc_cliente: {records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault()} | razao_cliente: {records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - doc_cliente: {records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault()} | razao_cliente: {records[i].Where(pair => pair.Key == "razao_cliente").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<LinxClientesFornec> _listSomenteNovos = new List<LinxClientesFornec>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxClientesFornec);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter: jobParameter, "dt_update");

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", timestamp).Replace("[data_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}").Replace("[dt_update_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[dt_update_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                            jobParameter: jobParameter,
                            cnpj_emp: jobParameter.docMainCompany
                        );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _linxClientesFornecServiceCache);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_linxClientesFornecServiceCache.GetList().Count == 0)
                    {
                        var list_existentes = await _linxClientesFornecRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _linxClientesFornecServiceCache.AddList(list_existentes);
                    }

                    _listSomenteNovos = _linxClientesFornecServiceCache.FiltrarList(listRecords);
                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxClientesFornecRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            var key = _linxClientesFornecServiceCache.GetKey(_listSomenteNovos[i]);
                            if (_linxClientesFornecServiceCache.GetDictionaryXml().ContainsKey(key))
                            {
                                var xml = _linxClientesFornecServiceCache.GetDictionaryXml()[key];
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
                _linxClientesFornecServiceCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
