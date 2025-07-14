using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxCommerce;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    /// <summary>
    /// A tabela de clientes contatos originados da linx commerce, geralmente é muito grande e o endpoint da microvix não possui parametros de 
    /// busca entre intevalos de datas, então efetuamos a busca do menor timestamp da tabela nos ultimos 7 dias então efetuamos a busca
    /// a partir dele, buscando assim todos os contatos de clientes novos e atualizados dos ultimos 7 dias 
    /// </summary>
    public class B2CConsultaClientesContatosService : IB2CConsultaClientesContatosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaClientesContatosRepository _b2cConsultaClientesContatosRepository;
        private static List<string?> _b2cConsultaClientesContatosCache { get; set; } = new List<string?>();

        public B2CConsultaClientesContatosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaClientesContatos> linxMicrovixRepositoryBase,
            IB2CConsultaClientesContatosRepository b2cConsultaClientesContatosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClientesContatosRepository = b2cConsultaClientesContatosRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
        }

        public List<B2CConsultaClientesContatos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClientesContatos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaClientesContatos(
                        listValidations: validations,
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
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - id_clientes_contatos: {records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault()} | nome_contato: {records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - id_clientes_contatos: {records[i].Where(pair => pair.Key == "id_clientes_contatos").Select(pair => pair.Value).FirstOrDefault()} | nome_contato: {records[i].Where(pair => pair.Key == "nome_contato").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClientesContatos);

            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
            var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys();

            foreach (var cnpj_emp in cnpjs_emp)
            {
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(jobParameter.schema, jobParameter.tableName, columnDate: "LASTUPDATEON");

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

                    if (_b2cConsultaClientesContatosCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaClientesContatosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaClientesContatosCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClientesContatosCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaClientesContatosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaClientesContatosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                    }

                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
                }
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}
