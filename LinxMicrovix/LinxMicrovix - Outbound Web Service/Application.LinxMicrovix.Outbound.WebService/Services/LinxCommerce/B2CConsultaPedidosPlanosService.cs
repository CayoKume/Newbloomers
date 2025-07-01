﻿using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaPedidosPlanosService : IB2CConsultaPedidosPlanosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaPedidosPlanosRepository _b2cConsultaPedidosPlanosRepository;
        private static List<string?> _b2cConsultaPedidosPlanosCache { get; set; } = new List<string?>();

        public B2CConsultaPedidosPlanosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaPedidosPlanos> linxMicrovixRepositoryBase,
            IB2CConsultaPedidosPlanosRepository b2cConsultaPedidosPlanosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaPedidosPlanosRepository = b2cConsultaPedidosPlanosRepository;
        }

        public List<B2CConsultaPedidosPlanos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaPedidosPlanos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaPedidosPlanos(
                        listValidations: validations,
                        id_pedido_planos: records[i].Where(pair => pair.Key == "id_pedido_planos").Select(pair => pair.Value).FirstOrDefault(),
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        plano_pagamento: records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        valor_plano: records[i].Where(pair => pair.Key == "valor_plano").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        nsu_sitef: records[i].Where(pair => pair.Key == "nsu_sitef").Select(pair => pair.Value).FirstOrDefault(),
                        cod_autorizacao: records[i].Where(pair => pair.Key == "cod_autorizacao").Select(pair => pair.Value).FirstOrDefault(),
                        texto_comprovante: records[i].Where(pair => pair.Key == "texto_comprovante").Select(pair => pair.Value).FirstOrDefault(),
                        cod_loja_sitef: records[i].Where(pair => pair.Key == "cod_loja_sitef").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - id_pedido_planos: {records[i].Where(pair => pair.Key == "id_pedido_planos").Select(pair => pair.Value).FirstOrDefault()} | plano_pagamento: {records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - id_pedido_planos: {records[i].Where(pair => pair.Key == "id_pedido_planos").Select(pair => pair.Value).FirstOrDefault()} | plano_pagamento: {records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[id_pedido]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaPedidosPlanosRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<B2CConsultaPedidosPlanos> _listSomenteNovos = new List<B2CConsultaPedidosPlanos>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.B2CConsultaPedidosPlanos);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys();

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

                        //if (_b2cConsultaPedidosPlanosCache.GetList().Count == 0)
                        //{
                        //    var list_existentes = await _b2cConsultaPedidosPlanosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        //    _b2cConsultaPedidosPlanosCache.AddList(list_existentes);
                        //}

                        //_listSomenteNovos = _b2cConsultaPedidosPlanosCache.FiltrarList(listRecords);

                        if (_listSomenteNovos.Count() > 0)
                        {
                            _b2cConsultaPedidosPlanosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                            
                            //for (int i = 0; i < _listSomenteNovos.Count; i++)
                            //{
                            //    var key = _b2cConsultaPedidosPlanosCache.GetKey(_listSomenteNovos[i]);
                            //    if (_b2cConsultaPedidosPlanosCache.GetDictionaryXml().ContainsKey(key))
                            //    {
                            //        var xml = _b2cConsultaPedidosPlanosCache.GetDictionaryXml()[key];
                            //        _logger.AddRecord(key, xml);
                            //    }
                            //}

                            await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

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
                //await _logger.CommitAllChanges();
            }

            return true;
        }
    }
}
