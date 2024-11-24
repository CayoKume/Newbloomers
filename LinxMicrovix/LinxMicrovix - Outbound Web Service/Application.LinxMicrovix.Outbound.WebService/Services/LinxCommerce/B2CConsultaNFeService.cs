using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using Domain.IntegrationsCore.Entities.Parameters;

using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.Globalization;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaNFeService : IB2CConsultaNFeService
    {
        private readonly IAPICall _apiCall;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaNFe> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaNFeRepository _b2cConsultaNFeRepository;

        public B2CConsultaNFeService(
            IAPICall apiCall,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaNFe> linxMicrovixRepositoryBase,
            IB2CConsultaNFeRepository b2cConsultaNFeRepository
        )
        {
            _apiCall = apiCall;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaNFeRepository = b2cConsultaNFeRepository;
        }

        public List<B2CConsultaNFe?> DeserializeXMLToObject(LinxMicrovixJobParameter jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaNFe>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new B2CConsultaNFe(
                        id_nfe: records[i].Where(pair => pair.Key == "id_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        id_pedido: records[i].Where(pair => pair.Key == "id_pedido").Select(pair => pair.Value).FirstOrDefault(),
                        documento: records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault(),
                        data_emissao: records[i].Where(pair => pair.Key == "data_emissao").Select(pair => pair.Value).FirstOrDefault(),
                        chave_nfe: records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        situacao: records[i].Where(pair => pair.Key == "situacao").Select(pair => pair.Value).FirstOrDefault(),
                        xml: records[i].Where(pair => pair.Key == "xml").Select(pair => pair.Value).FirstOrDefault(),
                        excluido: records[i].Where(pair => pair.Key == "excluido").Select(pair => pair.Value).FirstOrDefault(),
                        identificador_microvix: records[i].Where(pair => pair.Key == "identificador_microvix").Select(pair => pair.Value).FirstOrDefault(),
                        dt_insert: records[i].Where(pair => pair.Key == "dt_insert").Select(pair => pair.Value).FirstOrDefault(),
                        valor_nota: records[i].Where(pair => pair.Key == "valor_nota").Select(pair => pair.Value).FirstOrDefault(),
                        serie: records[i].Where(pair => pair.Key == "serie").Select(pair => pair.Value).FirstOrDefault(),
                        frete: records[i].Where(pair => pair.Key == "frete").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        nProt: records[i].Where(pair => pair.Key == "nProt").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_modelo_nf: records[i].Where(pair => pair.Key == "codigo_modelo_nf").Select(pair => pair.Value).FirstOrDefault(),
                        justificativa: records[i].Where(pair => pair.Key == "justificativa").Select(pair => pair.Value).FirstOrDefault(),
                        tpAmb: records[i].Where(pair => pair.Key == "tpAmb").Select(pair => pair.Value).FirstOrDefault()
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
                        message = $"Error when convert record: {records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()}",
                        record = $"{records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} - {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()}",
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
                        await _b2cConsultaNFeRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

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
                        _b2cConsultaNFeRepository.BulkInsertIntoTableRaw(records: listRecords, jobParameter: jobParameter);
                    }
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter: jobParameter);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
