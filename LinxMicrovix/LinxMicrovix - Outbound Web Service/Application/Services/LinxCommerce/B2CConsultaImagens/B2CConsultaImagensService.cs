using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaImagensService<TEntity> : IB2CConsultaImagensService<TEntity> where TEntity : B2CConsultaImagens, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaImagensRepository<TEntity> _b2cConsultaImagensRepository;

        public B2CConsultaImagensService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaImagensRepository<TEntity> b2cConsultaImagensRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaImagensRepository = b2cConsultaImagensRepository;
        }

        public List<TEntity?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<TEntity>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaImagens(
                        id_imagem: records[i].Where(pair => pair.Key == "id_imagem").Select(pair => pair.Value).FirstOrDefault(),
                        imagem: records[i].Where(pair => pair.Key == "imagem").Select(pair => pair.Value).FirstOrDefault(),
                        md5: records[i].Where(pair => pair.Key == "md5").Select(pair => pair.Value).FirstOrDefault(),
                        url_imagem_blob: records[i].Where(pair => pair.Key == "url_imagem_blob").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "id_imagem").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "imagem").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "id_imagem").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "imagem").Select(pair => pair.Value).FirstOrDefault()}",
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
                await _b2cConsultaImagensRepository.InsertParametersIfNotExists(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[id_imagem]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaImagensRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaImagensRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaImagensRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaImagensRepository.CreateTableMerge(jobParameter: jobParameter);
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
