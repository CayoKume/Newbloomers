using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxUsuariosService : ILinxUsuariosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxUsuarios> _linxMicrovixRepositoryBase;
        private readonly ILinxUsuariosRepository _linxUsuariosRepository;
        private static List<string?> _linxUsuariosCache { get; set; } = new List<string?>();

        public LinxUsuariosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<LinxUsuarios> linxMicrovixRepositoryBase,
            ILinxUsuariosRepository linxUsuariosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxUsuariosRepository = linxUsuariosRepository;
        }

        public List<LinxUsuarios?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxUsuarios>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxUsuarios(
                        listValidations: validations,
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
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - usuario_id: {records[i].Where(pair => pair.Key == "usuario_id").Select(pair => pair.Value).FirstOrDefault()} | usuario_nome: {records[i].Where(pair => pair.Key == "usuario_nome").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - usuario_id: {records[i].Where(pair => pair.Key == "usuario_id").Select(pair => pair.Value).FirstOrDefault()} | usuario_nome: {records[i].Where(pair => pair.Key == "usuario_nome").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxUsuarios);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
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
                        _linxUsuariosCache = await _linxUsuariosRepository.GetRegistersExists(
                            jobParameter: jobParameter,
                            registros: listRecords
                                        .Select(x => x.usuario_id)
                                        .ToList()
                        );

                    var _listSomenteNovos = listRecords.Where(x => !_linxUsuariosCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxUsuariosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _linxUsuariosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

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
