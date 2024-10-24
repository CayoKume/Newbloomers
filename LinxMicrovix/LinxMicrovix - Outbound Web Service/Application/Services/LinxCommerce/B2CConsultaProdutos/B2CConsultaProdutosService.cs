using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaProdutosService<TEntity> : IB2CConsultaProdutosService<TEntity> where TEntity : B2CConsultaProdutos, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosRepository<TEntity> _b2cConsultaProdutosRepository;

        public B2CConsultaProdutosService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosRepository<TEntity> b2cConsultaProdutosRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosRepository = b2cConsultaProdutosRepository;
        }

        public List<TEntity?> DeserializeXMLToObject(JobParameter jobParameter, List<Dictionary<string, string>> records)
        {
            var list = new List<TEntity>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaProdutos(
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First(),
                        referencia: records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).First(),
                        codauxiliar1: records[i].Where(pair => pair.Key == "codauxiliar1").Select(pair => pair.Value).First(),
                        descricao_basica: records[i].Where(pair => pair.Key == "descricao_basica").Select(pair => pair.Value).First(),
                        nome_produto: records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).First(),
                        peso_liquido: records[i].Where(pair => pair.Key == "peso_liquido").Select(pair => pair.Value).First(),
                        codigo_setor: records[i].Where(pair => pair.Key == "codigo_setor").Select(pair => pair.Value).First(),
                        codigo_linha: records[i].Where(pair => pair.Key == "codigo_linha").Select(pair => pair.Value).First(),
                        codigo_marca: records[i].Where(pair => pair.Key == "codigo_marca").Select(pair => pair.Value).First(),
                        codigo_colecao: records[i].Where(pair => pair.Key == "codigo_colecao").Select(pair => pair.Value).First(),
                        codigo_espessura: records[i].Where(pair => pair.Key == "codigo_espessura").Select(pair => pair.Value).First(),
                        codigo_grade1: records[i].Where(pair => pair.Key == "codigo_grade1").Select(pair => pair.Value).First(),
                        codigo_grade2: records[i].Where(pair => pair.Key == "codigo_grade2").Select(pair => pair.Value).First(),
                        unidade: records[i].Where(pair => pair.Key == "unidade").Select(pair => pair.Value).First(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).First(),
                        codigo_classificacao: records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).First(),
                        dt_cadastro: records[i].Where(pair => pair.Key == "dt_cadastro").Select(pair => pair.Value).First(),
                        observacao: records[i].Where(pair => pair.Key == "observacao").Select(pair => pair.Value).First(),
                        cod_fornecedor: records[i].Where(pair => pair.Key == "cod_fornecedor").Select(pair => pair.Value).First(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).First(),
                        altura_para_frete: records[i].Where(pair => pair.Key == "altura_para_frete").Select(pair => pair.Value).First(),
                        largura_para_frete: records[i].Where(pair => pair.Key == "largura_para_frete").Select(pair => pair.Value).First(),
                        comprimento_para_frete: records[i].Where(pair => pair.Key == "comprimento_para_frete").Select(pair => pair.Value).First(),
                        peso_bruto: records[i].Where(pair => pair.Key == "peso_bruto").Select(pair => pair.Value).First(),
                        descricao_completa_commerce: records[i].Where(pair => pair.Key == "descricao_completa_commerce").Select(pair => pair.Value).First(),
                        canais_ecommerce_publicados: records[i].Where(pair => pair.Key == "canais_ecommerce_publicados").Select(pair => pair.Value).First(),
                        codigo_integracao_oms: records[i].Where(pair => pair.Key == "codigo_integracao_oms").Select(pair => pair.Value).First(),
                        inicio_publicacao_produto: records[i].Where(pair => pair.Key == "inicio_publicacao_produto").Select(pair => pair.Value).First(),
                        fim_publicacao_produto: records[i].Where(pair => pair.Key == "fim_publicacao_produto").Select(pair => pair.Value).First(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).First()
                    );

                    list.Add((TEntity)entity);
                }
                catch (Exception ex)
                {
                    throw new InternalErrorException()
                    {
                        project = jobParameter.projectName,
                        job = jobParameter.jobName,
                        method = "DeserializeXMLToObject",
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_produto").Select(pair => pair.Value).First()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(JobParameter jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaProdutosRepository.InsertParametersIfNotExists(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[codigoproduto]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
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

        public async Task<bool> GetRecords(JobParameter jobParameter)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaProdutosRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys(jobParameter);

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0"),
                                jobParameter: jobParameter,
                                cnpj_emp: cnpj_emp.doc_company
                            );

                    string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
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
                await _b2cConsultaProdutosRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
