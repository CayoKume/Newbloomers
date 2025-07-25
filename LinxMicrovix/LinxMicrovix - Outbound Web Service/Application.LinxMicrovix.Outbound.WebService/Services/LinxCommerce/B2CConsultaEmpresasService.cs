using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaEmpresasService : IB2CConsultaEmpresasService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaEmpresasRepository _b2cConsultaEmpresasRepository;
        private static List<string?> _b2cConsultaEmpresasCache { get; set; } = new List<string?>();

        public B2CConsultaEmpresasService(
            IAPICall apiCall,
            ILoggerService logger,
            IIntegrationsCoreRepository integrationsCoreRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaEmpresasRepository b2cConsultaEmpresasRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _integrationsCoreRepository = integrationsCoreRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2cConsultaEmpresasRepository = b2cConsultaEmpresasRepository;
        }

        public List<B2CConsultaEmpresas?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaEmpresas>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaEmpresas(
                        listValidations: validations,
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        nome_emp: records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpjEmp").Select(pair => pair.Value).FirstOrDefault(),
                        end_unidade: records[i].Where(pair => pair.Key == "end_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        complemento_end_unidade: records[i].Where(pair => pair.Key == "complemento_end_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        nr_rua_unidade: records[i].Where(pair => pair.Key == "nr_rua_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_unidade: records[i].Where(pair => pair.Key == "bairro_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        cep_unidade: records[i].Where(pair => pair.Key == "cep_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_unidade: records[i].Where(pair => pair.Key == "cidade_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        uf_unidade: records[i].Where(pair => pair.Key == "uf_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        email_unidade: records[i].Where(pair => pair.Key == "email_unidade").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        data_criacao: records[i].Where(pair => pair.Key == "data_criacao").Select(pair => pair.Value).FirstOrDefault(),
                        centro_distribuicao: records[i].Where(pair => pair.Key == "centro_distribuicao").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - empresa: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
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
               .AddLog(EnumJob.B2CConsultaEmpresas);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _integrationsCoreRepository.GetRecord<string>(sql);

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

                if (_b2cConsultaEmpresasCache.Count == 0)
                {
                    var list = await _b2cConsultaEmpresasRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.cnpj_emp)
                                    .ToList()
                    );

                    _b2cConsultaEmpresasCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaEmpresasCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaEmpresasRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _b2cConsultaEmpresasCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}
