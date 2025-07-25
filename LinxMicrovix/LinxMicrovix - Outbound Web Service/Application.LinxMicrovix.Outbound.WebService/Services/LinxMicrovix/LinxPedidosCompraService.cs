using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Domain.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxPedidosCompraService : ILinxPedidosCompraService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxPedidosCompraRepository _linxPedidosCompraRepository;
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;

        private static List<string?> _linxPedidosCompraCache { get; set; } = new List<string?>();

        public LinxPedidosCompraService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxPedidosCompraRepository linxPedidosCompraRepository,
            IIntegrationsCoreRepository integrationsCoreRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxPedidosCompraRepository = linxPedidosCompraRepository;
            _integrationsCoreRepository = integrationsCoreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;

        }

        public List<LinxPedidosCompra?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxPedidosCompra>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxPedidosCompra(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_pedido: records[i].Where(pair => pair.Key == "cod_pedido").Select(pair => pair.Value).FirstOrDefault().Replace("-", ""),
                        data_pedido: records[i].Where(pair => pair.Key == "data_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        transacao: records[i].Where(pair => pair.Key == "transacao").Select(pair => pair.Value).FirstOrDefault(),
                        usuario: records[i].Where(pair => pair.Key == "usuario").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_fornecedor: records[i].Where(pair => pair.Key == "codigo_fornecedor").Select(pair => pair.Value).FirstOrDefault(),
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        quantidade: records[i].Where(pair => pair.Key == "quantidade").Select(pair => pair.Value).FirstOrDefault(),
                        valor_unitario: records[i].Where(pair => pair.Key == "valor_unitario").Select(pair => pair.Value).FirstOrDefault(),
                        cod_comprador: records[i].Where(pair => pair.Key == "cod_comprador").Select(pair => pair.Value).FirstOrDefault(),
                        valor_frete: records[i].Where(pair => pair.Key == "valor_frete").Select(pair => pair.Value).FirstOrDefault(),
                        valor_total: records[i].Where(pair => pair.Key == "valor_total").Select(pair => pair.Value).FirstOrDefault(),
                        cod_plano_pagamento: records[i].Where(pair => pair.Key == "cod_plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        plano_pagamento: records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        aprovado: records[i].Where(pair => pair.Key == "aprovado").Select(pair => pair.Value).FirstOrDefault(),
                        cancelado: records[i].Where(pair => pair.Key == "cancelado").Select(pair => pair.Value).FirstOrDefault(),
                        encerrado: records[i].Where(pair => pair.Key == "encerrado").Select(pair => pair.Value).FirstOrDefault(),
                        data_aprovacao: records[i].Where(pair => pair.Key == "data_aprovacao").Select(pair => pair.Value).FirstOrDefault(),
                        numero_ped_fornec: records[i].Where(pair => pair.Key == "numero_ped_fornec").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_frete: records[i].Where(pair => pair.Key == "tipo_frete").Select(pair => pair.Value).FirstOrDefault(),
                        natureza_operacao: records[i].Where(pair => pair.Key == "natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        previsao_entrega: records[i].Where(pair => pair.Key == "previsao_entrega").Select(pair => pair.Value).FirstOrDefault(),
                        numero_projeto_officina: records[i].Where(pair => pair.Key == "numero_projeto_officina").Select(pair => pair.Value).FirstOrDefault(),
                        status_pedido: records[i].Where(pair => pair.Key == "status_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        qtde_entregue: records[i].Where(pair => pair.Key == "qtde_entregue").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_frete: records[i].Where(pair => pair.Key == "descricao_frete").Select(pair => pair.Value).FirstOrDefault(),
                        integrado_linx: records[i].Where(pair => pair.Key == "integrado_linx").Select(pair => pair.Value).FirstOrDefault(),
                        nf_gerada: records[i].Where(pair => pair.Key == "nf_gerada").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        nf_origem_ws: records[i].Where(pair => pair.Key == "nf_origem_ws").Select(pair => pair.Value).FirstOrDefault(),
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
                    throw new GeneralException(
                        message: $"Error when convert record - cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()} | cod_pedido: {records[i].Where(pair => pair.Key == "cod_pedido").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()}",
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
               .AddLog(EnumJob.LinxPedidosCompra);

            var xmls = new List<Dictionary<string?, string?>>();
           
            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _integrationsCoreRepository.GetRecord<string>(sql);

            var sqlCnpjs = _linxMicrovixCommandHandler.CreateGetMicrovixCompanysQuery();
            var cnpjs_emp = await _integrationsCoreRepository.GetRecords<Company>(sqlCnpjs);

            foreach (var cnpj_emp in cnpjs_emp)
            {
                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", "0").Replace("[data_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}").Replace("[data_alt_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_alt_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
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

                if (_linxPedidosCompraCache.Count == 0)
                {
                    var list = await _linxPedidosCompraRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                        .GroupBy(x => x.cod_pedido)
                                        .Select(g => g.First())
                                        .Select(y => y.cod_pedido)
                                        .ToList()
                    );

                    _linxPedidosCompraCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxPedidosCompraCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxPedidosCompraRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxPedidosCompraCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
