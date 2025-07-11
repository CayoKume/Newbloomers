using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxB2CStatusService : ILinxB2CStatusService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxB2CStatus> _linxMicrovixRepositoryBase;
        private readonly ILinxB2CStatusRepository _linxB2CStatusRepository;
        private static List<string?> _linxB2CStatusCache { get; set; } = new List<string?>();

        public LinxB2CStatusService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxB2CStatus> linxMicrovixRepositoryBase,
            ILinxB2CStatusRepository linxB2CStatusRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxB2CStatusRepository = linxB2CStatusRepository;
        }

        public List<LinxB2CStatus?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxB2CStatus>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxB2CStatus(
                        listValidations: validations,
                        id_status: records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_status: records[i].Where(pair => pair.Key == "descricao_status").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - id_status: {records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault()} | descricao_status: {records[i].Where(pair => pair.Key == "descricao_status").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - id_status: {records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault()} | descricao_status: {records[i].Where(pair => pair.Key == "descricao_status").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxB2CStatus);

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

                if (_linxB2CStatusCache.Count == 0)
                {
                    var list = await _linxB2CStatusRepository.GetRegistersExists();
                    _linxB2CStatusCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxB2CStatusCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxB2CStatusRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxB2CStatusCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
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
