using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.publicErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaProdutosService : IB2CConsultaProdutosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosRepository _b2cConsultaProdutosRepository;

        public B2CConsultaProdutosService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaProdutos> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosRepository b2cConsultaProdutosRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosRepository = b2cConsultaProdutosRepository;
        }

        public List<B2CConsultaProdutos?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaProdutos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaProdutos(
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        referencia: records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).FirstOrDefault(),
                        codauxiliar1: records[i].Where(pair => pair.Key == "codauxiliar1").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_basica: records[i].Where(pair => pair.Key == "descricao_basica").Select(pair => pair.Value).FirstOrDefault(),
                        nome_produto: records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault(),
                        peso_liquido: records[i].Where(pair => pair.Key == "peso_liquido").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_setor: records[i].Where(pair => pair.Key == "codigo_setor").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_linha: records[i].Where(pair => pair.Key == "codigo_linha").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_marca: records[i].Where(pair => pair.Key == "codigo_marca").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_colecao: records[i].Where(pair => pair.Key == "codigo_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_espessura: records[i].Where(pair => pair.Key == "codigo_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_grade1: records[i].Where(pair => pair.Key == "codigo_grade1").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_grade2: records[i].Where(pair => pair.Key == "codigo_grade2").Select(pair => pair.Value).FirstOrDefault(),
                        unidade: records[i].Where(pair => pair.Key == "unidade").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_classificacao: records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                        dt_cadastro: records[i].Where(pair => pair.Key == "dt_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                        observacao: records[i].Where(pair => pair.Key == "observacao").Select(pair => pair.Value).FirstOrDefault(),
                        cod_fornecedor: records[i].Where(pair => pair.Key == "cod_fornecedor").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        altura_para_frete: records[i].Where(pair => pair.Key == "altura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        largura_para_frete: records[i].Where(pair => pair.Key == "largura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        comprimento_para_frete: records[i].Where(pair => pair.Key == "comprimento_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        peso_bruto: records[i].Where(pair => pair.Key == "peso_bruto").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_completa_commerce: records[i].Where(pair => pair.Key == "descricao_completa_commerce").Select(pair => pair.Value).FirstOrDefault(),
                        canais_ecommerce_publicados: records[i].Where(pair => pair.Key == "canais_ecommerce_publicados").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_integracao_oms: records[i].Where(pair => pair.Key == "codigo_integracao_oms").Select(pair => pair.Value).FirstOrDefault(),
                        inicio_publicacao_produto: records[i].Where(pair => pair.Key == "inicio_publicacao_produto").Select(pair => pair.Value).FirstOrDefault(),
                        fim_publicacao_produto: records[i].Where(pair => pair.Key == "fim_publicacao_produto").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new publicErrorException()
                    {
                        project = jobParameter.projectName,
                        job = jobParameter.jobName,
                        method = "DeserializeXMLToObject",
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).FirstOrDefault()}",
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
                await _b2cConsultaProdutosRepository.InsertParametersIfNotExists(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[codigoproduto]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaProdutosRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaProdutosRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaProdutosRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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

                //await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
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
