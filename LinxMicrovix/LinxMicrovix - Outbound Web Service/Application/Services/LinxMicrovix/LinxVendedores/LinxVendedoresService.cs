using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxMicrovix;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxMicrovix;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.InternalErrorsExceptions;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxMicrovix
{
    public class LinxVendedoresService<TEntity> : ILinxVendedoresService<TEntity> where TEntity : LinxVendedores, new()
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<TEntity> _linxMicrovixRepositoryBase;
        private readonly ILinxVendedoresRepository<TEntity> _linxVendedoresRepository;

        public LinxVendedoresService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<TEntity> linxMicrovixRepositoryBase,
            ILinxVendedoresRepository<TEntity> linxVendedoresRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxVendedoresRepository = linxVendedoresRepository;
        }

        public async Task<bool> GetRecords(JobParameter jobParameter)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _linxVendedoresRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[data_upd_inicial]", DateTime.Now.AddDays(-7).ToString("yyyy-mm-dd")).Replace("[data_upd_fim]", DateTime.Now.ToString("yyyy-mm-dd")),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                    _linxVendedoresRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
                await _linxVendedoresRepository.ExecuteTableMerge(jobParameter: jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetRecord(JobParameter jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _linxVendedoresRepository.InsertParametersIfNotExists(jobParameter);

                string parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[codigo_classificacao]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _linxVendedoresRepository.InsertRecord(record: record, jobParameter: jobParameter);
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

        public List<TEntity?> DeserializeXMLToObject(JobParameter jobParameter, List<Dictionary<string, string>> records)
        {
            var list = new List<TEntity>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new LinxVendedores(
                        cod_vendedor: records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        nome_vendedor: records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_vendedor: records[i].Where(pair => pair.Key == "tipo_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_rua: records[i].Where(pair => pair.Key == "end_vend_rua").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_numero: records[i].Where(pair => pair.Key == "end_vend_numero").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_complemento: records[i].Where(pair => pair.Key == "end_vend_complemento").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_bairro: records[i].Where(pair => pair.Key == "end_vend_bairro").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_cep: records[i].Where(pair => pair.Key == "end_vend_cep").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_cidade: records[i].Where(pair => pair.Key == "end_vend_cidade").Select(pair => pair.Value).FirstOrDefault(),
                        end_vend_uf: records[i].Where(pair => pair.Key == "end_vend_uf").Select(pair => pair.Value).FirstOrDefault(),
                        fone_vendedor: records[i].Where(pair => pair.Key == "fone_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        mail_vendedor: records[i].Where(pair => pair.Key == "mail_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        dt_upd: records[i].Where(pair => pair.Key == "dt_upd").Select(pair => pair.Value).FirstOrDefault(),
                        cpf_vendedor: records[i].Where(pair => pair.Key == "cpf_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                        data_admissao: records[i].Where(pair => pair.Key == "data_admissao").Select(pair => pair.Value).FirstOrDefault(),
                        data_saida: records[i].Where(pair => pair.Key == "data_saida").Select(pair => pair.Value).FirstOrDefault(),
                        matricula: records[i].Where(pair => pair.Key == "matricula").Select(pair => pair.Value).FirstOrDefault(),
                        id_tipo_venda: records[i].Where(pair => pair.Key == "id_tipo_venda").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_tipo_venda: records[i].Where(pair => pair.Key == "descricao_tipo_venda").Select(pair => pair.Value).FirstOrDefault(),
                        cargo: records[i].Where(pair => pair.Key == "cargo").Select(pair => pair.Value).FirstOrDefault(),
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).First()}",
                        record = $"{records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).First()} - {records[i].Where(pair => pair.Key == "nome_vendedor").Select(pair => pair.Value).First()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            };

            return list;
        }
    }
}
