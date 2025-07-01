﻿using Application.IntegrationsCore.Interfaces;
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
    public class LinxLojasService : ILinxLojasService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxLojas> _linxMicrovixRepositoryBase;
        private readonly ILinxLojasRepository _linxLojasRepository;
        private static List<string?> _linxLojasCache { get; set; } = new List<string?>();

        public LinxLojasService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxLojas> linxMicrovixRepositoryBase,
            ILinxLojasRepository linxLojasRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxLojasRepository = linxLojasRepository;
        }

        public List<LinxLojas?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxLojas>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxLojas(
                        listValidations: validations,
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        nome_emp: records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault(),
                        razao_emp: records[i].Where(pair => pair.Key == "razao_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        inscricao_emp: records[i].Where(pair => pair.Key == "inscricao_emp").Select(pair => pair.Value).FirstOrDefault(),
                        endereco_emp: records[i].Where(pair => pair.Key == "endereco_emp").Select(pair => pair.Value).FirstOrDefault(),
                        num_emp: records[i].Where(pair => pair.Key == "num_emp").Select(pair => pair.Value).FirstOrDefault(),
                        complement_emp: records[i].Where(pair => pair.Key == "complement_emp").Select(pair => pair.Value).FirstOrDefault(),
                        bairro_emp: records[i].Where(pair => pair.Key == "bairro_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cep_emp: records[i].Where(pair => pair.Key == "cep_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cidade_emp: records[i].Where(pair => pair.Key == "cidade_emp").Select(pair => pair.Value).FirstOrDefault(),
                        estado_emp: records[i].Where(pair => pair.Key == "estado_emp").Select(pair => pair.Value).FirstOrDefault(),
                        fone_emp: records[i].Where(pair => pair.Key == "fone_emp").Select(pair => pair.Value).FirstOrDefault(),
                        email_emp: records[i].Where(pair => pair.Key == "email_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_ibge_municipio: records[i].Where(pair => pair.Key == "cod_ibge_municipio").Select(pair => pair.Value).FirstOrDefault(),
                        data_criacao_emp: records[i].Where(pair => pair.Key == "data_criacao_emp").Select(pair => pair.Value).FirstOrDefault(),
                        data_criacao_portal: records[i].Where(pair => pair.Key == "data_criacao_portal").Select(pair => pair.Value).FirstOrDefault(),
                        sistema_tributacao: records[i].Where(pair => pair.Key == "sistema_tributacao").Select(pair => pair.Value).FirstOrDefault(),
                        regime_tributario: records[i].Where(pair => pair.Key == "regime_tributario").Select(pair => pair.Value).FirstOrDefault(),
                        area_empresa: records[i].Where(pair => pair.Key == "area_empresa").Select(pair => pair.Value).FirstOrDefault(),
                        sigla_empresa: records[i].Where(pair => pair.Key == "sigla_empresa").Select(pair => pair.Value).FirstOrDefault(),
                        id_classe_fiscal: records[i].Where(pair => pair.Key == "id_classe_fiscal").Select(pair => pair.Value).FirstOrDefault(),
                        centro_distribuicao: records[i].Where(pair => pair.Key == "centro_distribuicao").Select(pair => pair.Value).FirstOrDefault(),
                        inscricao_municipal_emp: records[i].Where(pair => pair.Key == "inscricao_municipal_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cnae_emp: records[i].Where(pair => pair.Key == "cnae_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_linx: records[i].Where(pair => pair.Key == "cod_cliente_linx").Select(pair => pair.Value).FirstOrDefault(),
                        tabela_preco_preferencial: records[i].Where(pair => pair.Key == "tabela_preco_preferencial").Select(pair => pair.Value).FirstOrDefault(),
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
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | nome_emp: {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).FirstOrDefault()}",
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
                   .AddLog(EnumJob.LinxLojas);

                var xmls = new List<Dictionary<string?, string?>>();
                string ? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixGroupCompanys();

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0"),
                                jobParameter: jobParameter,
                                cnpj_emp: cnpj_emp.doc_company
                            );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                    xmls.AddRange(result);
                }

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    if (_linxLojasCache.Count == 0)
                    {
                        var list = await _linxLojasRepository.GetRegistersExists();
                        _linxLojasCache = list.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_linxLojasCache.Any(y => 
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxLojasRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _linxLojasCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

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
