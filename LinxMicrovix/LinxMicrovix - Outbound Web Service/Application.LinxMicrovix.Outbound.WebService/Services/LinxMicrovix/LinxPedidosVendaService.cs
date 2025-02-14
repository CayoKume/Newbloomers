using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxPedidosVendaService : ILinxPedidosVendaService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixAzureSQLRepositoryBase<LinxPedidosVenda> _linxMicrovixRepositoryBase;
        private readonly ILinxPedidosVendaRepository _linxPedidosVendaRepository;
        private static ILinxPedidosVendaServiceCache _linxPedidosVendaServiceCache { get; set; } = new LinxPedidosVendaServiceCache();

        public LinxPedidosVendaService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixAzureSQLRepositoryBase<LinxPedidosVenda> linxMicrovixRepositoryBase,
            ILinxPedidosVendaRepository linxPedidosVendaRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxPedidosVendaRepository = linxPedidosVendaRepository;
        }

        public List<LinxPedidosVenda?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxPedidosVenda>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxPedidosVenda(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_pedido: records[i].Where(pair => pair.Key == "cod_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        data_lancamento: records[i].Where(pair => pair.Key == "data_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        hora_lancamento: records[i].Where(pair => pair.Key == "hora_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        transacao: records[i].Where(pair => pair.Key == "transacao").Select(pair => pair.Value).FirstOrDefault(),
                        usuario: records[i].Where(pair => pair.Key == "usuario").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_cliente: records[i].Where(pair => pair.Key == "codigo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        quantidade: records[i].Where(pair => pair.Key == "quantidade").Select(pair => pair.Value).FirstOrDefault(),
                        valor_unitario: records[i].Where(pair => pair.Key == "valor_unitario").Select(pair => pair.Value).FirstOrDefault(),
                        cod_vendedor: records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        valor_frete: records[i].Where(pair => pair.Key == "valor_frete").Select(pair => pair.Value).FirstOrDefault(),
                        valor_total: records[i].Where(pair => pair.Key == "valor_total").Select(pair => pair.Value).FirstOrDefault(),
                        desconto_item: records[i].Where(pair => pair.Key == "desconto_item").Select(pair => pair.Value).FirstOrDefault(),
                        cod_plano_pagamento: records[i].Where(pair => pair.Key == "cod_plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        plano_pagamento: records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        aprovado: records[i].Where(pair => pair.Key == "aprovado").Select(pair => pair.Value).FirstOrDefault(),
                        cancelado: records[i].Where(pair => pair.Key == "cancelado").Select(pair => pair.Value).FirstOrDefault(),
                        data_aprovacao: records[i].Where(pair => pair.Key == "data_aprovacao").Select(pair => pair.Value).FirstOrDefault(),
                        data_alteracao: records[i].Where(pair => pair.Key == "data_alteracao").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_frete: records[i].Where(pair => pair.Key == "tipo_frete").Select(pair => pair.Value).FirstOrDefault(),
                        natureza_operacao: records[i].Where(pair => pair.Key == "natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        tabela_preco: records[i].Where(pair => pair.Key == "tabela_preco").Select(pair => pair.Value).FirstOrDefault(),
                        nome_tabela_preco: records[i].Where(pair => pair.Key == "nome_tabela_preco").Select(pair => pair.Value).FirstOrDefault(),
                        previsao_entrega: records[i].Where(pair => pair.Key == "previsao_entrega").Select(pair => pair.Value).FirstOrDefault(),
                        realizado_por: records[i].Where(pair => pair.Key == "realizado_por").Select(pair => pair.Value).FirstOrDefault(),
                        pontuacao_ser: records[i].Where(pair => pair.Key == "pontuacao_ser").Select(pair => pair.Value).FirstOrDefault(),
                        venda_externa: records[i].Where(pair => pair.Key == "venda_externa").Select(pair => pair.Value).FirstOrDefault(),
                        nf_gerada: records[i].Where(pair => pair.Key == "nf_gerada").Select(pair => pair.Value).FirstOrDefault(),
                        status: records[i].Where(pair => pair.Key == "status").Select(pair => pair.Value).FirstOrDefault(),
                        numero_projeto_officina: records[i].Where(pair => pair.Key == "numero_projeto_officina").Select(pair => pair.Value).FirstOrDefault(),
                        cod_natureza_operacao: records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        margem_contribuicao: records[i].Where(pair => pair.Key == "margem_contribuicao").Select(pair => pair.Value).FirstOrDefault(),
                        doc_origem: records[i].Where(pair => pair.Key == "doc_origem").Select(pair => pair.Value).FirstOrDefault(),
                        posicao_item: records[i].Where(pair => pair.Key == "posicao_item").Select(pair => pair.Value).FirstOrDefault(),
                        orcamento_origem: records[i].Where(pair => pair.Key == "orcamento_origem").Select(pair => pair.Value).FirstOrDefault(),
                        transacao_origem: records[i].Where(pair => pair.Key == "transacao_origem").Select(pair => pair.Value).FirstOrDefault(),
                        desconto: records[i].Where(pair => pair.Key == "desconto").Select(pair => pair.Value).FirstOrDefault(),
                        transacao_ws: records[i].Where(pair => pair.Key == "transacao_ws").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        transportador: records[i].Where(pair => pair.Key == "transportador").Select(pair => pair.Value).FirstOrDefault(),
                        deposito: records[i].Where(pair => pair.Key == "deposito").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
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
                                message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_pedido: {records[i].Where(pair => pair.Key == "cod_pedido").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_pedido: {records[i].Where(pair => pair.Key == "cod_pedido").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxPedidosVenda);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[cod_pedido]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _linxPedidosVendaRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
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

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            IList<LinxPedidosVenda> _listSomenteNovos = new List<LinxPedidosVenda>();

            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxPedidosVenda);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys();

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0").Replace("[data_inicial]", $"{DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}").Replace("[data_alt_inicial]", $"{DateTime.Today.AddDays(-14).ToString("yyyy-MM-dd")}").Replace("[data_alt_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                                jobParameter: jobParameter,
                                cnpj_emp: cnpj_emp.doc_company
                            );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response, _linxPedidosVendaServiceCache);

                    if (xmls.Count() > 0)
                    {
                        var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                        if (_linxPedidosVendaServiceCache.GetList().Count == 0)
                        {
                            var list_existentes = await _linxPedidosVendaRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                            _linxPedidosVendaServiceCache.AddList(list_existentes);
                        }

                        _listSomenteNovos = _linxPedidosVendaServiceCache.FiltrarList(listRecords);
                        if (_listSomenteNovos.Count() > 0)
                        {
                            _linxPedidosVendaRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                            for (int i = 0; i < _listSomenteNovos.Count; i++)
                            {
                                var key = _linxPedidosVendaServiceCache.GetKey(_listSomenteNovos[i]);
                                if (_linxPedidosVendaServiceCache.GetDictionaryXml().ContainsKey(key))
                                {
                                    var xml = _linxPedidosVendaServiceCache.GetDictionaryXml()[key];
                                    _logger.AddRecord(key, xml);
                                }
                            }

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

                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
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
                _linxPedidosVendaServiceCache.AddList(_listSomenteNovos);
            }

            return true;
        }
    }
}
