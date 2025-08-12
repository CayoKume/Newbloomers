using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaClientesContatosParentescoService : IB2CConsultaClientesContatosParentescoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesContatosParentescoRepository _b2cConsultaClientesContatosParentescoRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatosParentesco> _validator;
        private static List<string?> _b2cConsultaClientesContatosParentescoCache { get; set; } = new List<string?>();

        public B2CConsultaClientesContatosParentescoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            IB2CConsultaClientesContatosParentescoRepository b2cConsultaClientesContatosParentescoRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatosParentesco> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _validator = validator;
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _b2cConsultaClientesContatosParentescoRepository = b2cConsultaClientesContatosParentescoRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<B2CConsultaClientesContatosParentesco?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesContatosParentesco>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatosParentesco(
                        id_parentesco: records[i].Where(pair => pair.Key == "id_parentesco").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_parentesco: records[i].Where(pair => pair.Key == "descricao_parentesco").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - id_parentesco: {records[i].Where(pair => pair.Key == "id_parentesco").Select(pair => pair.Value).FirstOrDefault()} | descricao_parentesco: {records[i].Where(pair => pair.Key == "descricao_parentesco").Select(pair => pair.Value).FirstOrDefault()}";
    
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
    
                        _logger.AddMessage(message);
                    }
    
                    list.Add(new B2CConsultaClientesContatosParentesco(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_parentesco: {records[i].Where(pair => pair.Key == "id_parentesco").Select(pair => pair.Value).FirstOrDefault()} | descricao_parentesco: {records[i].Where(pair => pair.Key == "descricao_parentesco").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClientesContatosParentesco);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[id_parentesco]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaClientesContatosParentescoRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.B2CConsultaClientesContatosParentesco);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);
            
            var cnpjs_emp = await _coreRepository.GetRecords<Company>(_linxMicrovixCommandHandler.CreateGetB2CCompanysQuery());

            foreach (var cnpj_emp in cnpjs_emp)
            {
                string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampQuery(jobParameter.schema, jobParameter.tableName, "LASTUPDATEON");
                string? timestamp = await _coreRepository.GetRecord<string>(sqlTimestamp);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp.doc_company
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_b2cConsultaClientesContatosParentescoCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaClientesContatosParentescoRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaClientesContatosParentescoCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesContatosParentescoCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesContatosParentescoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaClientesContatosParentescoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                    }

                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
                }
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}

