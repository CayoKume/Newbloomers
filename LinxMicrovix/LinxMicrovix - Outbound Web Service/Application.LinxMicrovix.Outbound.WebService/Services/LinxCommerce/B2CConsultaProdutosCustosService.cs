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
    public class B2CConsultaProdutosCustosService : IB2CConsultaProdutosCustosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaProdutosCustos> _linxMicrovixRepositoryBase;
        private readonly IB2CConsultaProdutosCustosRepository _b2cConsultaProdutosCustosRepository;
        private static List<string?> _b2cConsultaProdutosCustosCache { get; set; } = new List<string?>();

        public B2CConsultaProdutosCustosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<B2CConsultaProdutosCustos> linxMicrovixRepositoryBase,
            IB2CConsultaProdutosCustosRepository b2cConsultaProdutosCustosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _b2cConsultaProdutosCustosRepository = b2cConsultaProdutosCustosRepository;
        }

        public List<B2CConsultaProdutosCustos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaProdutosCustos>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaProdutosCustos(
                        listValidations: validations,
                        id_produtos_custos: records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).FirstOrDefault(),
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        custoicms1: records[i].Where(pair => pair.Key == "custoicms1").Select(pair => pair.Value).FirstOrDefault(),
                        ipi1: records[i].Where(pair => pair.Key == "ipi1").Select(pair => pair.Value).FirstOrDefault(),
                        markup: records[i].Where(pair => pair.Key == "markup").Select(pair => pair.Value).FirstOrDefault(),
                        customedio: records[i].Where(pair => pair.Key == "customedio").Select(pair => pair.Value).FirstOrDefault(),
                        frete1: records[i].Where(pair => pair.Key == "frete1").Select(pair => pair.Value).FirstOrDefault(),
                        precisao: records[i].Where(pair => pair.Key == "precisao").Select(pair => pair.Value).FirstOrDefault(),
                        precominimo: records[i].Where(pair => pair.Key == "precominimo").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        custoliquido: records[i].Where(pair => pair.Key == "custoliquido").Select(pair => pair.Value).FirstOrDefault(),
                        precovenda: records[i].Where(pair => pair.Key == "precovenda").Select(pair => pair.Value).FirstOrDefault(),
                        custototal: records[i].Where(pair => pair.Key == "custototal").Select(pair => pair.Value).FirstOrDefault(),
                        precocompra: records[i].Where(pair => pair.Key == "precocompra").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - id_produtos_custos: {records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).FirstOrDefault()} | codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - id_produtos_custos: {records[i].Where(pair => pair.Key == "id_produtos_custos").Select(pair => pair.Value).FirstOrDefault()} | codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaProdutosCustos);

            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[codigoproduto]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaProdutosCustosRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                _logger.AddMessage(
                    $"Concluída com sucesso: {listRecords.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaProdutosCustos);

            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.tableName, jobParameter.jobName);
            var cnpjs_emp = await _linxMicrovixRepositoryBase.GetB2CCompanys();

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

                    if (_b2cConsultaProdutosCustosCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaProdutosCustosRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaProdutosCustosCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaProdutosCustosCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaProdutosCustosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaProdutosCustosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
