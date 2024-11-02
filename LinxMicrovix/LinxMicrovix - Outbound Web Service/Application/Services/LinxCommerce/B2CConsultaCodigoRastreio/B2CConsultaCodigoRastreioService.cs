using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaCodigoRastreioService<TEntity> : IB2CConsultaCodigoRastreioService<TEntity> where TEntity : B2CConsultaCodigoRastreio, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaCodigoRastreioRepository<TEntity> _b2cConsultaCodigoRastreioRepository;

        public B2CConsultaCodigoRastreioService(
            IAPICall apiCall,
            IB2CConsultaCodigoRastreioRepository<TEntity> b2cConsultaCodigoRastreioRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase
        )
        {
            _apiCall = apiCall;
            _b2cConsultaCodigoRastreioRepository = b2cConsultaCodigoRastreioRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<TEntity?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<TEntity>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaCodigoRastreio(
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        documento: records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault(),
                        serie: records[i].Where(pair => pair.Key == "serie").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_rastreio: records[i].Where(pair => pair.Key == "codigo_rastreio").Select(pair => pair.Value).FirstOrDefault(),
                        sequencia_volume: records[i].Where(pair => pair.Key == "sequencia_volume").Select(pair => pair.Value).FirstOrDefault(),
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
                        message = $"Error when convert record: Pedido - {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} Código - {records[i].Where(pair => pair.Key == "codigo_rastreio").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"Pedido - {records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault()} Código - {records[i].Where(pair => pair.Key == "codigo_rastreio").Select(pair => pair.Value).FirstOrDefault()}",
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
                await _b2cConsultaCodigoRastreioRepository.InsertParametersIfNotExists(jobParameter);

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
                        await _b2cConsultaCodigoRastreioRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaCodigoRastreioRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaCodigoRastreioRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaCodigoRastreioRepository.CreateTableMerge(jobParameter: jobParameter);
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
