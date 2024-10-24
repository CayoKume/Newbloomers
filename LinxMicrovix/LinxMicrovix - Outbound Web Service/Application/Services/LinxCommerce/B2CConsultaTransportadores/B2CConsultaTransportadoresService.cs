using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaTransportadoresService<TEntity> : IB2CConsultaTransportadoresService<TEntity> where TEntity : B2CConsultaTransportadores, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaTransportadoresRepository<TEntity> _b2cConsultaTransportadoresRepository;

        public B2CConsultaTransportadoresService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaTransportadoresRepository<TEntity> b2cConsultaTransportadoresRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaTransportadoresRepository = b2cConsultaTransportadoresRepository;
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

                        cod_transportador = records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).First() == String.Empty ? 0
                        : Convert.ToInt32(records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).First()),

                        nome = records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).First(),

                        nome_fantasia = records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).First(),

                        tipo_pessoa = records[i].Where(pair => pair.Key == "tipo_pessoa").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "tipo_pessoa").Select(pair => pair.Value).First(),

                        tipo_transportador = records[i].Where(pair => pair.Key == "tipo_transportador").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "tipo_transportador").Select(pair => pair.Value).First(),

                        endereco = records[i].Where(pair => pair.Key == "endereco").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "endereco").Select(pair => pair.Value).First(),

                        numero_rua = records[i].Where(pair => pair.Key == "numero_rua").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "numero_rua").Select(pair => pair.Value).First(),

                        bairro = records[i].Where(pair => pair.Key == "bairro").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "bairro").Select(pair => pair.Value).First(),

                        cep = records[i].Where(pair => pair.Key == "cep").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "cep").Select(pair => pair.Value).First(),

                        cidade = records[i].Where(pair => pair.Key == "cidade").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "cidade").Select(pair => pair.Value).First(),

                        uf = records[i].Where(pair => pair.Key == "uf").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "uf").Select(pair => pair.Value).First(),

                        documento = records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).First(),

                        fone = records[i].Where(pair => pair.Key == "fone").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "fone").Select(pair => pair.Value).First(),

                        email = records[i].Where(pair => pair.Key == "email").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "email").Select(pair => pair.Value).First(),

                        pais = records[i].Where(pair => pair.Key == "pais").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "pais").Select(pair => pair.Value).First(),

                        obs = records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).First() == String.Empty ? ""
                        : records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).First(),

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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "cod_transportador").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_fantasia").Select(pair => pair.Value).First()}",
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
                await _b2cConsultaTransportadoresRepository.InsertParametersIfNotExists(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[documento]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaTransportadoresRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaTransportadoresRepository.InsertParametersIfNotExists(jobParameter);
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
                        _b2cConsultaTransportadoresRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _b2cConsultaTransportadoresRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
