using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaService<TEntity> : IB2CConsultaProdutosPalavrasChavePesquisaService<TEntity> where TEntity : B2CConsultaProdutosPalavrasChavePesquisa, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosPalavrasChavePesquisaRepository<TEntity> _b2cConsultaProdutosPalavrasChavePesquisaRepository;

        public B2CConsultaProdutosPalavrasChavePesquisaService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosPalavrasChavePesquisaRepository<TEntity> b2cConsultaProdutosPalavrasChavePesquisaRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosPalavrasChavePesquisaRepository = b2cConsultaProdutosPalavrasChavePesquisaRepository;
        }

        public List<TEntity?> DeserializeXMLToObject(JobParameter jobParameter, List<Dictionary<string, string>> records)
        {
            var list = new List<TEntity>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    list.Add(new TEntity
                    {
                        lastupdateon = DateTime.Now,

                        id_b2c_palavras_chave_pesquisa_produtos = records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa_produtos").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa_produtos").Select(pair => pair.Value).First()),

                        id_b2c_palavras_chave_pesquisa = records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First()),

                        codigoproduto = records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()),

                        descricao_b2c_palavras_chave_pesquisa = records[i].Where(pair => pair.Key == "descricao_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "descricao_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First(),

                        timestamp = records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First()),

                        portal = records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).First())
                    });
                }
                catch (Exception ex)
                {
                    throw new InternalErrorException()
                    {
                        project = jobParameter.projectName,
                        job = jobParameter.jobName,
                        method = "DeserializeXMLToObject",
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa_produtos").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "descricao_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "id_b2c_palavras_chave_pesquisa_produtos").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "descricao_b2c_palavras_chave_pesquisa").Select(pair => pair.Value).First()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(JobParameter jobParameter)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaProdutosPalavrasChavePesquisaRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaProdutosPalavrasChavePesquisaRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosPalavrasChavePesquisaRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
