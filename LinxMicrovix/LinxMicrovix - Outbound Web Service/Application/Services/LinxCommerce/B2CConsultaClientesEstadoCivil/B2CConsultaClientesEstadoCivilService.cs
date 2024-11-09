using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivilService : IB2CConsultaClientesEstadoCivilService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesEstadoCivil> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesEstadoCivilRepository _b2cConsultaClientesEstadoCivilRepository;

        public B2CConsultaClientesEstadoCivilService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaClientesEstadoCivil> linxMicrovixRepositoryBase,
            IB2CConsultaClientesEstadoCivilRepository b2cConsultaClientesEstadoCivilRepository
        )
        {
            _apiCall = apiCall;
            _b2cConsultaClientesEstadoCivilRepository = b2cConsultaClientesEstadoCivilRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaClientesEstadoCivil?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesEstadoCivil>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaClientesEstadoCivil(
                        id_estado_civil: records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault(),
                        estado_civil: records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "id_estado_civil").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "estado_civil").Select(pair => pair.Value).FirstOrDefault()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxMicrovixJobParameter jobParameter)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaClientesEstadoCivilRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaClientesEstadoCivilRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaClientesEstadoCivilRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.InsertLogResponse(
                        jobParameter: jobParameter,
                        response: response,
                        record: new
                        {
                            method = jobParameter.jobName,
                            parameters_interval = jobParameter.parametersInterval,
                            response = response
                        }
                    );
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
