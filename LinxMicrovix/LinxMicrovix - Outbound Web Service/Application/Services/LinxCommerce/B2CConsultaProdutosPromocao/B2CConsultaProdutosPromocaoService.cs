using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;
using System.Globalization;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoService<TEntity> : IB2CConsultaProdutosPromocaoService<TEntity> where TEntity : B2CConsultaProdutosPromocao, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosPromocaoRepository<TEntity> _b2cConsultaProdutosPromocaoRepository;

        public B2CConsultaProdutosPromocaoService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosPromocaoRepository<TEntity> b2cConsultaProdutosPromocaoRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosPromocaoRepository = b2cConsultaProdutosPromocaoRepository;
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

                        codigo_promocao = records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).First()),

                        empresa = records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First()),

                        codigoproduto = records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()),

                        preco = records[i].Where(pair => pair.Key == "preco").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "preco").Select(pair => pair.Value).First()),

                        data_inicio = records[i].Where(pair => pair.Key == "data_inicio").Select(pair => pair.Value).First() == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                        : Convert.ToDateTime(records[i].Where(pair => pair.Key == "data_inicio").Select(pair => pair.Value).First()),

                        data_termino = records[i].Where(pair => pair.Key == "data_termino").Select(pair => pair.Value).First() == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                        : Convert.ToDateTime(records[i].Where(pair => pair.Key == "data_termino").Select(pair => pair.Value).First()),

                        data_cadastro = records[i].Where(pair => pair.Key == "data_cadastro").Select(pair => pair.Value).First() == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                        : Convert.ToDateTime(records[i].Where(pair => pair.Key == "data_cadastro").Select(pair => pair.Value).First()),

                        codigo_campanha = records[i].Where(pair => pair.Key == "codigo_campanha").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "codigo_campanha").Select(pair => pair.Value).First()),

                        promocao_opcional = records[i].Where(pair => pair.Key == "promocao_opcional").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "promocao_opcional").Select(pair => pair.Value).First()),

                        timestamp = records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First()),

                        ativa = records[i].Where(pair => pair.Key == "ativa").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "ativa").Select(pair => pair.Value).First(),

                        referencia = records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).First(),

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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "codigo_promocao").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()}",
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
                await _b2cConsultaProdutosPromocaoRepository.InsertParametersIfNotExists(jobParameter);

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
                        await _b2cConsultaProdutosPromocaoRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosPromocaoRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaProdutosPromocaoRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosPromocaoRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
