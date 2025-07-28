using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaLegendasCadastrosAuxiliaresService : IB2CConsultaLegendasCadastrosAuxiliaresService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaLegendasCadastrosAuxiliaresRepository _b2cConsultaLegendasCadastrosAuxiliaresRepository;
        private static List<string?> _b2cConsultaLegendasCadastrosAuxiliaresCache { get; set; } = new List<string?>();

        public B2CConsultaLegendasCadastrosAuxiliaresService(
            IAPICall apiCall,
            ILoggerService logger,
            IIntegrationsCoreRepository integrationsCoreRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaLegendasCadastrosAuxiliaresRepository b2cConsultaLegendasCadastrosAuxiliaresRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _integrationsCoreRepository = integrationsCoreRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2cConsultaLegendasCadastrosAuxiliaresRepository = b2cConsultaLegendasCadastrosAuxiliaresRepository;
        }

        public List<B2CConsultaLegendasCadastrosAuxiliares?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaLegendasCadastrosAuxiliares>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaLegendasCadastrosAuxiliares(
                        listValidations: validations,
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_setor: records[i].Where(pair => pair.Key == "legenda_setor").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_linha: records[i].Where(pair => pair.Key == "legenda_linha").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_marca: records[i].Where(pair => pair.Key == "legenda_marca").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_colecao: records[i].Where(pair => pair.Key == "legenda_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_grade1: records[i].Where(pair => pair.Key == "legenda_grade1").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_grade2: records[i].Where(pair => pair.Key == "legenda_grade2").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_espessura: records[i].Where(pair => pair.Key == "legenda_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        legenda_classificacao: records[i].Where(pair => pair.Key == "legenda_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
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
               .AddLog(EnumJob.B2CConsultaLegendasCadastrosAuxiliares);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _integrationsCoreRepository.GetRecord<string>(sql);

            string sqlCnpjsEmp = _linxMicrovixCommandHandler.CreateGetB2CCompanysQuery();
            var cnpjs_emp = await _integrationsCoreRepository.GetRecords<Company?>(sql);

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

                    if (_b2cConsultaLegendasCadastrosAuxiliaresCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaLegendasCadastrosAuxiliaresRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaLegendasCadastrosAuxiliaresCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaLegendasCadastrosAuxiliaresCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaLegendasCadastrosAuxiliaresRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaLegendasCadastrosAuxiliaresCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
