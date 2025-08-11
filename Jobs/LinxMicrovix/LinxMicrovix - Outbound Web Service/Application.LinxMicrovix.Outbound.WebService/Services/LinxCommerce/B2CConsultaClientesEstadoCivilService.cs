using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaClientesEstadoCivilService : IB2CConsultaClientesEstadoCivilService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClientesEstadoCivilRepository _b2cConsultaClientesEstadoCivilRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _b2cConsultaClientesEstadoCivilCache { get; set; } = new List<string?>();

        public B2CConsultaClientesEstadoCivilService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            IB2CConsultaClientesEstadoCivilRepository b2cConsultaClientesEstadoCivilRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClientesEstadoCivilRepository = b2cConsultaClientesEstadoCivilRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<B2CConsultaClientesEstadoCivil?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesEstadoCivil>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaClientesEstadoCivil(
                        id_estado_civil: records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault(),
                        estado_civil: records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - id_estado_civil: {records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault()} | estado_civil:{records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_estado_civil: {records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault()} | estado_civil:{records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
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
               .AddLog(EnumJob.B2CConsultaClientesEstadoCivil);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlCnpjsEmp = _linxMicrovixCommandHandler.CreateGetB2CCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company?>(sql);

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

                    if (_b2cConsultaClientesEstadoCivilCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaClientesEstadoCivilRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaClientesEstadoCivilCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesEstadoCivilCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesEstadoCivilRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaClientesEstadoCivilCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
