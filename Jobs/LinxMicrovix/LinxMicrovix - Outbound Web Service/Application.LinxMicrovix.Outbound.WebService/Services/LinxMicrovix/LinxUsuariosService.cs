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
    public class LinxUsuariosService : ILinxUsuariosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxUsuarios> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxUsuariosRepository _linxUsuariosRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _linxUsuariosCache { get; set; } = new List<string?>();

        public LinxUsuariosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ICoreRepository coreRepository,
            ILinxUsuariosRepository linxUsuariosRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxUsuarios> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _coreRepository = coreRepository;
            _linxUsuariosRepository = linxUsuariosRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<LinxUsuarios?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxUsuarios>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxUsuarios(
                        usuario_id: records[i].Where(pair => pair.Key == "usuario_id").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_login: records[i].Where(pair => pair.Key == "usuario_login").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_nome: records[i].Where(pair => pair.Key == "usuario_nome").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_email: records[i].Where(pair => pair.Key == "usuario_email").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_grupo_id: records[i].Where(pair => pair.Key == "usuario_grupo_id").Select(pair => pair.Value).FirstOrDefault(),
                        grupo_usuarios: records[i].Where(pair => pair.Key == "grupo_usuarios").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_supervisor: records[i].Where(pair => pair.Key == "usuario_supervisor").Select(pair => pair.Value).FirstOrDefault(),
                        usuario_doc: records[i].Where(pair => pair.Key == "usuario_doc").Select(pair => pair.Value).FirstOrDefault(),
                        vendedor: records[i].Where(pair => pair.Key == "vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        data_criacao: records[i].Where(pair => pair.Key == "data_criacao").Select(pair => pair.Value).FirstOrDefault(),
                        desativado: records[i].Where(pair => pair.Key == "desativado").Select(pair => pair.Value).FirstOrDefault(),
                        empresas: records[i].Where(pair => pair.Key == "empresas").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - usuario_id: {records[i].Where(pair => pair.Key == "usuario_id").Select(pair => pair.Value).FirstOrDefault()} | usuario_nome: {records[i].Where(pair => pair.Key == "usuario_nome").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxUsuarios(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - usuario_id: {records[i].Where(pair => pair.Key == "usuario_id").Select(pair => pair.Value).FirstOrDefault()} | usuario_nome: {records[i].Where(pair => pair.Key == "usuario_nome").Select(pair => pair.Value).FirstOrDefault()}",
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
               .AddLog(EnumJob.LinxUsuarios);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);
            
            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0"),
                    jobParameter: jobParameter
                );

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxUsuariosCache.Count == 0)
                {
                    var list = await _linxUsuariosRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.usuario_id)
                                    .ToList()
                    );

                    _linxUsuariosCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxUsuariosCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxUsuariosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxUsuariosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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


