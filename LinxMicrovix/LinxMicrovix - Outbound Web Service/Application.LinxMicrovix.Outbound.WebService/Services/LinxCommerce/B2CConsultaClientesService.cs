using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using System.Data;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Domain.IntegrationsCore.Entities.Enums;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce;
using Domain.IntegrationsCore.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    /// <summary>
    /// A tabela de clientes originados da linx commerce, geralmente é muito grande e o endpoint da microvix não possui parametros de 
    /// busca entre intevalos de datas, então efetuamos a busca do menor timestamp da tabela nos ultimos 7 dias então efetuamos a busca
    /// a partir dele, buscando assim todos os clientes novos e atualizados dos ultimos 7 dias.
    /// E como ela possui dados gerais não é preciso pesquisar por todos os cnpjs, ao pesquisar por um cnpj os dados serão os mesmo para os demais cnpjs
    /// </summary>
    public class B2CConsultaClientesService : IB2CConsultaClientesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientes> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesRepository _b2cConsultaClientesRepository;
        private static IB2CConsultaClientesServiceCache _b2cConsultaClientesCache { get; set; } = new B2CConsultaClientesServiceCache();

        public B2CConsultaClientesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaClientes> linxMicrovixRepositoryBase,
            IB2CConsultaClientesRepository b2cConsultaClientesRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClientesRepository = b2cConsultaClientesRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaClientes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientes>();

            for(int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaClientes(
                         listValidations: validations,
                         cod_cliente_b2c: records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault(),
                         cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                         doc_cliente: records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nm_cliente: records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nm_mae: records[i].Where(pair => pair.Key == "nm_mae").Select(pair => pair.Value).FirstOrDefault(),
                         nm_pai: records[i].Where(pair => pair.Key == "nm_pai").Select(pair => pair.Value).FirstOrDefault(),
                         nm_conjuge: records[i].Where(pair => pair.Key == "nm_conjuge").Select(pair => pair.Value).FirstOrDefault(),
                         dt_cadastro: records[i].Where(pair => pair.Key == "dt_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                         dt_nasc_cliente: records[i].Where(pair => pair.Key == "dt_nasc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         end_cliente: records[i].Where(pair => pair.Key == "end_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         complemento_end_cliente: records[i].Where(pair => pair.Key == "complemento_end_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nr_rua_cliente: records[i].Where(pair => pair.Key == "nr_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         bairro_cliente: records[i].Where(pair => pair.Key == "bairro_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cep_cliente: records[i].Where(pair => pair.Key == "cep_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cidade_cliente: records[i].Where(pair => pair.Key == "cidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         uf_cliente: records[i].Where(pair => pair.Key == "uf_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         fone_cliente: records[i].Where(pair => pair.Key == "fone_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         fone_comercial: records[i].Where(pair => pair.Key == "fone_comercial").Select(pair => pair.Value).FirstOrDefault(),
                         cel_cliente: records[i].Where(pair => pair.Key == "cel_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         email_cliente: records[i].Where(pair => pair.Key == "email_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         rg_cliente: records[i].Where(pair => pair.Key == "rg_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         rg_orgao_emissor: records[i].Where(pair => pair.Key == "rg_orgao_emissor").Select(pair => pair.Value).FirstOrDefault(),
                         estado_civil_cliente: records[i].Where(pair => pair.Key == "estado_civil_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         empresa_cliente: records[i].Where(pair => pair.Key == "empresa_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cargo_cliente: records[i].Where(pair => pair.Key == "cargo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         sexo_cliente: records[i].Where(pair => pair.Key == "sexo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                         ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                         receber_email: records[i].Where(pair => pair.Key == "receber_email").Select(pair => pair.Value).FirstOrDefault(),
                         dt_expedicao_rg: records[i].Where(pair => pair.Key == "dt_expedicao_rg").Select(pair => pair.Value).FirstOrDefault(),
                         naturalidade: records[i].Where(pair => pair.Key == "naturalidade").Select(pair => pair.Value).FirstOrDefault(),
                         tempo_residencia: records[i].Where(pair => pair.Key == "tempo_residencia").Select(pair => pair.Value).FirstOrDefault(),
                         renda: records[i].Where(pair => pair.Key == "renda").Select(pair => pair.Value).FirstOrDefault(),
                         numero_compl_rua_cliente: records[i].Where(pair => pair.Key == "numero_compl_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                         tipo_pessoa: records[i].Where(pair => pair.Key == "tipo_pessoa").Select(pair => pair.Value).FirstOrDefault(),
                         portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                         aceita_programa_fidelidade: records[i].Where(pair => pair.Key == "aceita_programa_fidelidade").Select(pair => pair.Value).FirstOrDefault()
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
                                message: $"Error when convert record - cod_cliente_b2c: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} | nm_cliente: {records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_cliente_b2c: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} | nm_cliente: {records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaClientesRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
            IList<B2CConsultaClientes> _listSomenteNovos = new List<B2CConsultaClientes>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaClientes);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter: jobParameter, columnDate: "DT_UPDATE");

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _b2cConsultaClientesCache);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaClientesCache.GetList().Count == 0)
                    {
                        var list_existentes = await _b2cConsultaClientesRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaClientesCache.AddList(list_existentes);
                    }

                    _listSomenteNovos = _b2cConsultaClientesCache.FiltrarList(listRecords);
                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            var key = _b2cConsultaClientesCache.GetKey(_listSomenteNovos[i]);
                            if (_b2cConsultaClientesCache.GetDictionaryXml().ContainsKey(key))
                            {
                                var xml = _b2cConsultaClientesCache.GetDictionaryXml()[key];
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
                _b2cConsultaClientesCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
