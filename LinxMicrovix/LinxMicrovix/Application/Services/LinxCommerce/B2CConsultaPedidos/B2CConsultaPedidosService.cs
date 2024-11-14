using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;
using static Domain.IntegrationsCore.Exceptions.InternalErrorsExceptions;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaPedidosService : IB2CConsultaPedidosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaPedidos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaPedidosRepository _b2cConsultaPedidosRepository;

        public B2CConsultaPedidosService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaPedidos> linxMicrovixRepositoryBase,
            IB2CConsultaPedidosRepository b2cConsultaPedidosRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaPedidosRepository = b2cConsultaPedidosRepository;
        }

        public List<B2CConsultaPedidos?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaPedidos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaPedidos(
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        dt_pedido: records[i].Where(pair => pair.Key == "dt_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_b2c: records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        vl_frete: records[i].Where(pair => pair.Key == "vl_frete").Select(pair => pair.Value).FirstOrDefault(),
                        forma_pgto: records[i].Where(pair => pair.Key == "forma_pgto").Select(pair => pair.Value).FirstOrDefault(),
                        plano_pagamento: records[i].Where(pair => pair.Key == "plano_pagamento").Select(pair => pair.Value).FirstOrDefault(),
                        anotacao: records[i].Where(pair => pair.Key == "anotacao").Select(pair => pair.Value).FirstOrDefault(),
                        taxa_impressao: records[i].Where(pair => pair.Key == "taxa_impressao").Select(pair => pair.Value).FirstOrDefault(),
                        finalizado: records[i].Where(pair => pair.Key == "finalizado").Select(pair => pair.Value).FirstOrDefault(),
                        valor_frete_gratis: records[i].Where(pair => pair.Key == "valor_frete_gratis").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_frete: records[i].Where(pair => pair.Key == "tipo_frete").Select(pair => pair.Value).FirstOrDefault(),
                        id_status: records[i].Where(pair => pair.Key == "id_status").Select(pair => pair.Value).FirstOrDefault(),
                        cod_transportador: records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_cobranca_frete: records[i].Where(pair => pair.Key == "tipo_cobranca_frete").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        id_tabela_preco: records[i].Where(pair => pair.Key == "id_tabela_preco").Select(pair => pair.Value).FirstOrDefault(),
                        valor_credito: records[i].Where(pair => pair.Key == "valor_credito").Select(pair => pair.Value).FirstOrDefault(),
                        cod_vendedor: records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        dt_disponivel_faturamento: records[i].Where(pair => pair.Key == "dt_disponivel_faturamento").Select(pair => pair.Value).FirstOrDefault(),
                        dt_insert: records[i].Where(pair => pair.Key == "dt_insert").Select(pair => pair.Value).FirstOrDefault(),
                        mensagem_falha_faturamento: records[i].Where(pair => pair.Key == "mensagem_falha_faturamento").Select(pair => pair.Value).FirstOrDefault(),
                        id_tipo_b2c: records[i].Where(pair => pair.Key == "id_tipo_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        ecommerce_origem: records[i].Where(pair => pair.Key == "ecommerce_origem").Select(pair => pair.Value).FirstOrDefault(),
                        order_id: records[i].Where(pair => pair.Key == "order_id").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new InternalErrorException()
                    {
                        project = jobParameter.projectName,
                        job = jobParameter.jobName,
                        method = "DeserializeXMLToObject",
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "order_id").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "order_id").Select(pair => pair.Value).FirstOrDefault()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaPedidosRepository.InsertParametersIfNotExists(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

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
                        await _b2cConsultaPedidosRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.InsertLogResponse(
                        jobParameter: jobParameter,
                        response: response,
                        record: new
                        {
                            method = jobParameter.jobName,
                            parameters_interval = jobParameter.parametersInterval,
                            response = response
                        });
                    await _linxMicrovixRepositoryBase.UpdateLogParameters(jobParameter: jobParameter, lastResponse: response);

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaPedidosRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaPedidosRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys(jobParameter);

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
                        _b2cConsultaPedidosRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.InsertLogResponse(
                        jobParameter: jobParameter,
                        response: response,
                        record: new
                        {
                            method = jobParameter.jobName,
                            parameters_interval = jobParameter.parametersInterval,
                            response = response
                        });
                    await _linxMicrovixRepositoryBase.UpdateLogParameters(jobParameter: jobParameter, lastResponse: response); 
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
