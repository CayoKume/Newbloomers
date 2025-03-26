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
using System.Data;


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
        private readonly ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientes> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesRepository _b2cConsultaClientesRepository;
        private static List<string?> _b2cConsultaClientesCache { get; set; } = new List<string?>();

        public B2CConsultaClientesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<B2CConsultaClientes> linxMicrovixRepositoryBase,
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

            for (int i = 0; i < records.Count(); i++)
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
                         aceita_programa_fidelidade: records[i].Where(pair => pair.Key == "aceita_programa_fidelidade").Select(pair => pair.Value).FirstOrDefault(),
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

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaClientes);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaClientesRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                   .AddLog(EnumJob.B2CConsultaClientes);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter.schema, jobParameter.tableName, columnDate: "DT_UPDATE");

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaClientesCache.Count == 0)
                        _b2cConsultaClientesCache = await _b2cConsultaClientesRepository.GetRegistersExists(
                            jobParameter: jobParameter, 
                            registros: listRecords
                                        .Select(x => x.doc_cliente)
                                        .ToList()
                        );

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesCache.Any(y => 
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaClientesCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

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
