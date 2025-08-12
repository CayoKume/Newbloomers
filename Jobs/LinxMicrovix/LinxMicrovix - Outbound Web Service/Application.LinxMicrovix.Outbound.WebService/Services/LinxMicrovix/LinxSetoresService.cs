using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxSetoresService : ILinxSetoresService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSetores> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxSetoresRepository _linxSetoresRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string> _linxSetoresCache { get; set; } = new List<string>();

        public LinxSetoresService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            ILinxSetoresRepository linxSetoresRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSetores> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxSetoresRepository = linxSetoresRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<LinxSetores?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxSetores>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxSetores(
                        id_setor: records[i].Where(pair => pair.Key == "id_setor").Select(pair => pair.Value).FirstOrDefault(),
                        desc_setor: records[i].Where(pair => pair.Key == "desc_setor").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_integracao_ws: records[i].Where(pair => pair.Key == "codigo_integracao_ws").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - id_setor: {records[i].Where(pair => pair.Key == "id_setor").Select(pair => pair.Value).FirstOrDefault()} | desc_setor: {records[i].Where(pair => pair.Key == "desc_setor").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxSetores(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_setor: {records[i].Where(pair => pair.Key == "id_setor").Select(pair => pair.Value).FirstOrDefault()} | desc_setor: {records[i].Where(pair => pair.Key == "desc_setor").Select(pair => pair.Value).FirstOrDefault()}",
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
               .AddLog(EnumJob.LinxSetores);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[id_setor]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxSetoresRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.LinxSetores);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

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

                if (_linxSetoresCache.Count == 0)
                {
                    var list = await _linxSetoresRepository.GetRegistersExists();
                    _linxSetoresCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxSetoresCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxSetoresRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(
                            key: _listSomenteNovos[i].recordKey,
                            xml: _listSomenteNovos[i].recordXml
                        );
                    }

                    _linxSetoresCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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


