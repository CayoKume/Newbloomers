using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxCommerce;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.Core.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaNFeService : IB2CConsultaNFeService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaNFeRepository _b2cConsultaNFeRepository;
        private static List<string?> _b2cConsultaNFeCache { get; set; } = new List<string?>();

        public B2CConsultaNFeService(
            IAPICall apiCall,
            ILoggerService logger,
            ICoreRepository coreRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaNFeRepository b2cConsultaNFeRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _coreRepository = coreRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2cConsultaNFeRepository = b2cConsultaNFeRepository;
        }

        public List<B2CConsultaNFe?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaNFe>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new B2CConsultaNFe(
                        listValidations: validations,
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
                        tpAmb: records[i].Where(pair => pair.Key == "tpAmb").Select(pair => pair.Value).FirstOrDefault(),
                        recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var contexto = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, contexto, validations, true);

                    if (validations.Count() > 0)
                    {
                        for (int j = 0; j < validations.Count(); j++)
                        {
                            _logger.AddMessage(
                                message: $"Error when convert record - id_nfe: {records[i].Where(pair => pair.Key == "id_nfe").Select(pair => pair.Value).FirstOrDefault()} | chave_nfe: {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - id_nfe: {records[i].Where(pair => pair.Key == "id_nfe").Select(pair => pair.Value).FirstOrDefault()} | chave_nfe: {records[i].Where(pair => pair.Key == "chave_nfe").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            }

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            _logger
                .Clear()
                .AddLog(EnumJob.B2CConsultaNFe);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[id_pedido]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaNFeRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

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
                .AddLog(EnumJob.B2CConsultaNFe);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[0]", "0").Replace("[data_inicial]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                        jobParameter: jobParameter,
                        cnpj_emp: jobParameter.docMainCompany
                    );

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_b2cConsultaNFeCache.Count == 0)
                {
                    var list = await _b2cConsultaNFeRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.id_nfe)
                                    .ToList()
                    );

                    _b2cConsultaNFeCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaNFeCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaNFeRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _b2cConsultaNFeCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }
    }
}
