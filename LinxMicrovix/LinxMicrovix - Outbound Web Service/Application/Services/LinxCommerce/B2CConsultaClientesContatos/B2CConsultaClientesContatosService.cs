using LinxMicrovix_Outbound_Web_Service.Infrastructure.Api;
using LinxMicrovix_Outbound_Web_Service.Application.Services.Base;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.LinxCommerce;
using IntegrationsCore.Domain.Entities;
using static IntegrationsCore.Domain.Entities.Exceptions.publicErrorsExceptions;
using System.Globalization;
using LinxMicrovix_Outbound_Web_Service.Infrastructure.Repository.Base;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    /// <summary>
    /// A tabela de clientes contatos originados da linx commerce, geralmente é muito grande e o endpoint da microvix não possui parametros de 
    /// busca entre intevalos de datas, então efetuamos a busca do menor timestamp da tabela nos ultimos 7 dias então efetuamos a busca
    /// a partir dele, buscando assim todos os contatos de clientes novos e atualizados dos ultimos 7 dias 
    /// </summary>
    public class B2CConsultaClientesContatosService : IB2CConsultaClientesContatosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesContatosRepository _b2cConsultaClientesContatosRepository;

        public B2CConsultaClientesContatosService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> linxMicrovixRepositoryBase,
            IB2CConsultaClientesContatosRepository b2cConsultaClientesContatosRepository
        )
        {
            _apiCall = apiCall;
            _b2cConsultaClientesContatosRepository = b2cConsultaClientesContatosRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaClientesContatos?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesContatos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaClientesContatos(
                        id_clientes_contatos: records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault(),
                        id_contato_b2c: records[i].Where(pair => pair.Key == "id_contato_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        nome_contato: records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault(),
                        data_nasc_contato: records[i].Where(pair => pair.Key == "data_nasc_contato").Select(pair => pair.Value).FirstOrDefault(),
                        sexo_contato: records[i].Where(pair => pair.Key == "sexo_contato").Select(pair => pair.Value).FirstOrDefault(),
                        id_parentesco: records[i].Where(pair => pair.Key == "id_parentesco").Select(pair => pair.Value).FirstOrDefault(),
                        fone_contato: records[i].Where(pair => pair.Key == "fone_contato").Select(pair => pair.Value).FirstOrDefault(),
                        celular_contato: records[i].Where(pair => pair.Key == "celular_contato").Select(pair => pair.Value).FirstOrDefault(),
                        email_contato: records[i].Where(pair => pair.Key == "email_contato").Select(pair => pair.Value).FirstOrDefault(),
                        cod_cliente_erp: records[i].Where(pair => pair.Key == "cod_cliente_erp").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new publicErrorException()
                    {
                        project = jobParameter.projectName,
                        job = jobParameter.jobName,
                        method = "DeserializeXMLToObject",
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault()}",
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
                await _b2cConsultaClientesContatosRepository.CreateTableMerge(jobParameter: jobParameter);
                await _b2cConsultaClientesContatosRepository.InsertParametersIfNotExists(jobParameter);
                await _linxMicrovixRepositoryBase.ExecuteTruncateRawTable(jobParameter);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys(jobParameter);

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter, columnDate: "LASTUPDATEON");

                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[0]", timestamp),
                        jobParameter: jobParameter,
                        cnpj_emp: cnpj_emp.doc_company
                    );

                    string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                    var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                    if (xmls.Count() > 0)
                    {
                        var listRecords = DeserializeXMLToObject(jobParameter, xmls);
                        _b2cConsultaClientesContatosRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
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
