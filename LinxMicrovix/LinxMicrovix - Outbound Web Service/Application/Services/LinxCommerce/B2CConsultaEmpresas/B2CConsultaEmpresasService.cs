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
    public class B2CConsultaEmpresasService<TEntity> : IB2CConsultaEmpresasService<TEntity> where TEntity : B2CConsultaEmpresas, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaEmpresasRepository<TEntity> _b2cConsultaEmpresasRepository;

        public B2CConsultaEmpresasService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            IB2CConsultaEmpresasRepository<TEntity> b2cConsultaEmpresasRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaEmpresasRepository = b2cConsultaEmpresasRepository;
        }

        public List<TEntity?> DeserializeXMLToObject(JobParameter jobParameter, List<Dictionary<string, string>> records)
        {
            var list = new List<TEntity>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaEmpresas(
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First(),
                        nome_emp: records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).First(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).First(),
                        end_unidade: records[i].Where(pair => pair.Key == "end_unidade").Select(pair => pair.Value).First(),
                        complemento_end_unidade: records[i].Where(pair => pair.Key == "complemento_end_unidade").Select(pair => pair.Value).First(),
                        nr_rua_unidade: records[i].Where(pair => pair.Key == "nr_rua_unidade").Select(pair => pair.Value).First(),
                        bairro_unidade: records[i].Where(pair => pair.Key == "bairro_unidade").Select(pair => pair.Value).First(),
                        cep_unidade: records[i].Where(pair => pair.Key == "cep_unidade").Select(pair => pair.Value).First(),
                        cidade_unidade: records[i].Where(pair => pair.Key == "cidade_unidade").Select(pair => pair.Value).First(),
                        uf_unidade: records[i].Where(pair => pair.Key == "uf_unidade").Select(pair => pair.Value).First(),
                        email_unidade: records[i].Where(pair => pair.Key == "email_unidade").Select(pair => pair.Value).First(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).First(),
                        data_criacao: records[i].Where(pair => pair.Key == "data_criacao").Select(pair => pair.Value).First(),
                        centro_distribuicao: records[i].Where(pair => pair.Key == "centro_distribuicao").Select(pair => pair.Value).First(),
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_emp").Select(pair => pair.Value).First()}",
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
                await _b2cConsultaEmpresasRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0"),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                    _b2cConsultaEmpresasRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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

                //await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);
                await _b2cConsultaEmpresasRepository.ExecuteTableMerge(jobParameter: jobParameter);
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
