using Domain.IntegrationsCore.Entities.Parameters;
using Domain.LinxMicrovix_Outbound_Web_Service.Entites.LinxCommerce;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.LinxCommerce;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Api;
using static Domain.IntegrationsCore.Exceptions.InternalErrorsExceptions;
using System.Data;
using Domain.LinxMicrovix_Outbound_Web_Service.Interfaces.Repositorys.Base;
using Application.LinxMicrovix_Outbound_Web_Service.Interfaces.LinxCommerce;
using Application.LinxMicrovix_Outbound_Web_Service.Interfaces.Base;

namespace Application.LinxMicrovix_Outbound_Web_Service.Services
{
    /// <summary>
    /// A tabela de clientes originados da linx commerce, geralmente é muito grande e o endpoint da microvix não possui parametros de 
    /// busca entre intevalos de datas, então efetuamos a busca do menor timestamp da tabela nos ultimos 7 dias então efetuamos a busca
    /// a partir dele, buscando assim todos os clientes novos e atualizados dos ultimos 7 dias.
    /// E como ela possui dados gerais não é preciso pesquisar por todos os cnpjs, ao pesquisar por um cnpj os dados serão os mesmo para os demais cnpjs
    /// </summary>
    public class B2CConsultaClientesService : IB2CConsultaClientesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientes> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesRepository _b2cConsultaClientesRepository;

        public B2CConsultaClientesService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaClientes> linxMicrovixRepositoryBase,
            IB2CConsultaClientesRepository b2cConsultaClientesRepository
        )
        {
            _apiCall = apiCall;
            _b2cConsultaClientesRepository = b2cConsultaClientesRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaClientes?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientes>();

            for(int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaClientes(
                         cod_cliente_b2c: records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault(),
                         cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                         doc_cliente: records[i].Where(pair => pair.Key == "doc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nm_cliente: records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nm_mae: records[i].Where(pair => pair.Key == "nm_mae").Select(pair => pair.Value).FirstOrDefault(),
                         nm_pai: records[i].Where(pair => pair.Key == "nm_pai").Select(pair => pair.Value).FirstOrDefault(),
                         nm_conjuge: records[i].Where(pair => pair.Key == "nm_conjuge").Select(pair => pair.Value).FirstOrDefault(),
                         dt_cadastro: records[i].Where(pair => pair.Key == "dt_cadastro").Select(pair => pair.Value).FirstOrDefault(),
                         dt_nasc_cliente: records[i].Where(pair => pair.Key == "dt_nasc_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         end_cliente: records[i].Where(pair => pair.Key == "end_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         complemento_end_cliente: records[i].Where(pair => pair.Key == "complemento_end_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         nr_rua_cliente: records[i].Where(pair => pair.Key == "nr_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         bairro_cliente: records[i].Where(pair => pair.Key == "bairro_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cep_cliente: records[i].Where(pair => pair.Key == "cep_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cidade_cliente: records[i].Where(pair => pair.Key == "cidade_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         uf_cliente: records[i].Where(pair => pair.Key == "uf_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         fone_cliente: records[i].Where(pair => pair.Key == "fone_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         fone_comercial: records[i].Where(pair => pair.Key == "fone_comercial").Select(pair => pair.Value).FirstOrDefault(),
                         cel_cliente: records[i].Where(pair => pair.Key == "cel_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         email_cliente: records[i].Where(pair => pair.Key == "email_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         rg_cliente: records[i].Where(pair => pair.Key == "rg_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         rg_orgao_emissor: records[i].Where(pair => pair.Key == "rg_orgao_emissor").Select(pair => pair.Value).FirstOrDefault(),
                         estado_civil_cliente: records[i].Where(pair => pair.Key == "estado_civil_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         empresa_cliente: records[i].Where(pair => pair.Key == "empresa_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         cargo_cliente: records[i].Where(pair => pair.Key == "cargo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         sexo_cliente: records[i].Where(pair => pair.Key == "sexo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                         ativo: records[i].Where(pair => pair.Key == "ativo").Select(pair => pair.Value).FirstOrDefault(),
                         receber_email: records[i].Where(pair => pair.Key == "receber_email").Select(pair => pair.Value).FirstOrDefault(),
                         dt_expedicao_rg: records[i].Where(pair => pair.Key == "dt_expedicao_rg").Select(pair => pair.Value).FirstOrDefault(),
                         naturalidade: records[i].Where(pair => pair.Key == "naturalidade").Select(pair => pair.Value).FirstOrDefault(),
                         tempo_residencia: records[i].Where(pair => pair.Key == "tempo_residencia").Select(pair => pair.Value).FirstOrDefault(),
                         renda: records[i].Where(pair => pair.Key == "renda").Select(pair => pair.Value).FirstOrDefault(),
                         numero_compl_rua_cliente: records[i].Where(pair => pair.Key == "numero_compl_rua_cliente").Select(pair => pair.Value).FirstOrDefault(),
                         timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                         tipo_pessoa: records[i].Where(pair => pair.Key == "tipo_pessoa").Select(pair => pair.Value).FirstOrDefault(),
                         portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                         aceita_programa_fidelidade: records[i].Where(pair => pair.Key == "aceita_programa_fidelidade").Select(pair => pair.Value).FirstOrDefault()
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "cod_cliente_b2c").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nm_cliente").Select(pair => pair.Value).FirstOrDefault()}",
                        propertie = " - ",
                        exception = ex.Message
                    };
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxMicrovixJobParameter jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                await _linxMicrovixRepositoryBase.DeleteLogResponse(jobParameter);
                await _linxMicrovixRepositoryBase.CreateDataTableIfNotExists(jobParameter);
                await _b2cConsultaClientesRepository.InsertParametersIfNotExists(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", "0").Replace("[doc_cliente]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _b2cConsultaClientesRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
                await _b2cConsultaClientesRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaClientesRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter: jobParameter, columnDate: "DT_UPDATE");

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp),
                    jobParameter: jobParameter,
                    cnpj_emp: jobParameter.docMainCompany
                );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                    _b2cConsultaClientesRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
