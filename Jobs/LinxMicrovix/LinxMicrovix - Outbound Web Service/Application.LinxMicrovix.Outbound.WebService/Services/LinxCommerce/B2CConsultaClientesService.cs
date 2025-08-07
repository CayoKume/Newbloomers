using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.Parameters;
using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaClientesService : IB2CConsultaClientesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesRepository _b2cConsultaClientesRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaClientesCommandHandler _b2CConsultaClientesCommandHandler;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientes> _validator;
        private static List<string?> _b2cConsultaClientesCache { get; set; } = new List<string?>();

        public B2CConsultaClientesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            IB2CConsultaClientesRepository b2cConsultaClientesRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaClientesCommandHandler b2CConsultaClientesCommandHandler,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientes> validator
        )
        {
            _validator = validator;
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClientesRepository = b2cConsultaClientesRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2CConsultaClientesCommandHandler = b2CConsultaClientesCommandHandler;
        }

        public List<B2CConsultaClientes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientes>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientes(
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

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message= $"Error when convert record - cod_cliente_b2c: {entity.cod_cliente_b2c} | doc_cliente: {entity.doc_cliente}\n";
                        
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}\n";
                        }

                        _logger.AddMessage(message);
                    }

                    list.Add(new B2CConsultaClientes(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - cod_cliente_b2c: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} | nm_cliente: {records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClientes);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

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
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                _logger.AddMessage(
                    $"Concluída com sucesso: {listRecords.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClientes);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampQuery(jobParameter.schema, jobParameter.tableName, "DT_UPDATE");
            string? timestamp = await _coreRepository.GetRecord<string>(sqlTimestamp);

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
                {
                    var list = await _b2cConsultaClientesRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.doc_cliente)
                                    .ToList()
                    );

                    _b2cConsultaClientesCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaClientesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _b2cConsultaClientesCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> IntegrityLockB2CConsultaClientesRegisters(LinxAPIParam jobParameter)
        {
            try
            {
                var _listSomenteNovos = new List<B2CConsultaClientes>();

                string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                string? parameters = await _coreRepository.GetRecord<string>(sql);

                string integritySql = _b2CConsultaClientesCommandHandler.CreateIntegrityLockQuery();
                var _listRegistrosConsultados = await _coreRepository.GetRecords<IntegrityLockTablesRegister>(integritySql);

                foreach (var cliente in _listRegistrosConsultados)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                    parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", cliente.identifier).Replace("[data_inicial]", "2000-01-01").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                                    jobParameter: jobParameter,
                                    cnpj_emp: jobParameter.docMainCompany
                                );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                    if (xmls.Count() > 0)
                    {
                        var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                        _listSomenteNovos.AddRange(listRecords);
                        cliente.is_present_in_erp = true;
                    }
                }

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaClientesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName);
                }

                if (_listRegistrosConsultados.Count() > 0)
                {
                    _coreRepository.BulkInsertIntoTableRaw<IntegrityLockTablesRegister>(
                                recordsList: _listRegistrosConsultados.ToList(),
                                entity: new IntegrityLockTablesRegister(),
                                tableName: "IntegrityLockTablesRegisters"
                            ); 
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
