using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaCNPJsChaveService : IB2CConsultaCNPJsChaveService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaCNPJsChaveRepository _b2cConsultaCNPJsChaveRepository;

        public B2CConsultaCNPJsChaveService(
            IAPICall apiCall,
            IB2CConsultaCNPJsChaveRepository b2cConsultaCNPJsChaveRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaCNPJsChave> linxMicrovixRepositoryBase
        )
        {
            _apiCall = apiCall;
            _b2cConsultaCNPJsChaveRepository = b2cConsultaCNPJsChaveRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaCNPJsChave?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaCNPJsChave>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaCNPJsChave(
                        cnpj: records[i].Where(pair => pair.Key == "cnpj").Select(pair => pair.Value).FirstOrDefault(),
                        nome_empresa: records[i].Where(pair => pair.Key == "nome_empresa").Select(pair => pair.Value).FirstOrDefault(),
                        id_empresas_rede: records[i].Where(pair => pair.Key == "id_empresas_rede").Select(pair => pair.Value).FirstOrDefault(),
                        rede: records[i].Where(pair => pair.Key == "rede").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        nome_portal: records[i].Where(pair => pair.Key == "nome_portal").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        classificacao_portal: records[i].Where(pair => pair.Key == "classificacao_portal").Select(pair => pair.Value).FirstOrDefault(),
                        b2c: records[i].Where(pair => pair.Key == "b2c").Select(pair => pair.Value).FirstOrDefault(),
                        oms: records[i].Where(pair => pair.Key == "oms").Select(pair => pair.Value).FirstOrDefault()
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "cnpj").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_empresa").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "cnpj").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_empresa").Select(pair => pair.Value).FirstOrDefault()}",
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
                await _b2cConsultaCNPJsChaveRepository.InsertParametersIfNotExists(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[id_classificacao]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaCNPJsChaveRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaCNPJsChaveRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaCNPJsChaveRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(jobParameter: jobParameter);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                    _b2cConsultaCNPJsChaveRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
