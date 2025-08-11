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
    public class B2CConsultaClientesContatosService : IB2CConsultaClientesContatosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesContatosRepository _b2cConsultaClientesContatosRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatos> _validator;
        private static List<string?> _b2cConsultaClientesContatosCache { get; set; } = new List<string?>();

        public B2CConsultaClientesContatosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            IB2CConsultaClientesContatosRepository b2cConsultaClientesContatosRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatos> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _validator = validator;
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClientesContatosRepository = b2cConsultaClientesContatosRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<B2CConsultaClientesContatos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesContatos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesContatos(
                        listValidations: validations,
                        id_clientes_contatos: records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault(),
                        id_contato_b2c: records[i].Where(pair => pair.Key == "id_contato_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        nome_contato: records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault(),
                        data_nasc_contato: records[i].Where(pair => pair.Key == "data_nasc_contato").Select(pair => pair.Value).FirstOrDefault(),
                        sexo_contato: records[i].Where(pair => pair.Key == "sexo_contato").Select(pair => pair.Value).FirstOrDefault(),
                        id_parentesco: records[i].Where(pair => pair.Key == "id_parentesco").Select(pair => pair.Value).FirstOrDefault(),
                        fone_contato: records[i].Where(pair => pair.Key == "fone_contato").Select(pair => pair.Value).FirstOrDefault(),
                        celular_contato: records[i].Where(pair => pair.Key == "celular_contato").Select(pair => pair.Value).FirstOrDefault(),
                        email_contato: records[i].Where(pair => pair.Key == "email_contato").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);`r`n

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - id_clientes_contatos: {records[i].Where(pair => pair.Key == ";
    
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
    
                        _logger.AddMessage(message);
                    }
    
                    list.Add(new B2CConsultaClientesContatos(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_clientes_contatos: {records[i].Where(pair => pair.Key == " - {ex.Message}id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault()} | nome_contato: {records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClientesContatos);

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

                    if (_b2cConsultaClientesContatosCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaClientesContatosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaClientesContatosCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesContatosCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesContatosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaClientesContatosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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

