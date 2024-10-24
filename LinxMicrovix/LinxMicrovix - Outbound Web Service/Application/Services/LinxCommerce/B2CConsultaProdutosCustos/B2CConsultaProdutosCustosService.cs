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
    public class B2CConsultaProdutosCustosService<TEntity> : IB2CConsultaProdutosCustosService<TEntity> where TEntity : B2CConsultaProdutosCustos, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosCustosRepository<TEntity> _b2cConsultaProdutosCustosRepository;

        public B2CConsultaProdutosCustosService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosCustosRepository<TEntity> b2cConsultaProdutosCustosRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosCustosRepository = b2cConsultaProdutosCustosRepository;
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

                        id_produtos_custos = records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).First()),

                        codigoproduto = records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt64(records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()),

                        empresa = records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First()),

                        custoicms1 = records[i].Where(pair => pair.Key == "custoicms1").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "custoicms1").Select(pair => pair.Value).First()),

                        ipi1 = records[i].Where(pair => pair.Key == "ipi1").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "ipi1").Select(pair => pair.Value).First()),

                        markup = records[i].Where(pair => pair.Key == "markup").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "markup").Select(pair => pair.Value).First()),

                        customedio = records[i].Where(pair => pair.Key == "customedio").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "customedio").Select(pair => pair.Value).First()),

                        frete1 = records[i].Where(pair => pair.Key == "frete1").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "frete1").Select(pair => pair.Value).First()),

                        precisao = records[i].Where(pair => pair.Key == "precisao").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "precisao").Select(pair => pair.Value).First()),

                        precominimo = records[i].Where(pair => pair.Key == "precominimo").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "precominimo").Select(pair => pair.Value).First()),

                        dt_update = records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).First() == String.Empty ? new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar)
                        : Convert.ToDateTime(records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).First()),

                        custoliquido = records[i].Where(pair => pair.Key == "custoliquido").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "custoliquido").Select(pair => pair.Value).First()),

                        precovenda = records[i].Where(pair => pair.Key == "precovenda").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "precovenda").Select(pair => pair.Value).First()),

                        custototal = records[i].Where(pair => pair.Key == "custototal").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "custototal").Select(pair => pair.Value).First()),

                        precocompra = records[i].Where(pair => pair.Key == "precocompra").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToDecimal(records[i].Where(pair => pair.Key == "precocompra").Select(pair => pair.Value).First()),

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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).First()}",
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
                await _b2cConsultaProdutosCustosRepository.InsertParametersIfNotExists(jobParameter);

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
                        await _b2cConsultaProdutosCustosRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosCustosRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaProdutosCustosRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaProdutosCustosRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
