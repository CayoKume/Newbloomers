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
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services
{
    public class B2CConsultaProdutosCodebarService : IB2CConsultaProdutosCodebarService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly IB2CConsultaProdutosCodebarRepository _b2cConsultaProdutosCodebarRepository;
        private static List<string?> _b2cConsultaProdutosCodebarCache { get; set; } = new List<string?>();

        public B2CConsultaProdutosCodebarService(
            IAPICall apiCall,
            ILoggerService logger,
            ICoreRepository coreRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            IB2CConsultaProdutosCodebarRepository b2cConsultaProdutosCodebarRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _coreRepository = coreRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _b2cConsultaProdutosCodebarRepository = b2cConsultaProdutosCodebarRepository;
        }

        public List<B2CConsultaProdutosCodebar?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaProdutosCodebar>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce.B2CConsultaProdutosCodebar(
                        codigoproduto: records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault(),
                        codebar: records[i].Where(pair => pair.Key == "codebar").Select(pair => pair.Value).FirstOrDefault(),
                        id_produtos_codebar: records[i].Where(pair => pair.Key == "id_produtos_codebar").Select(pair => pair.Value).FirstOrDefault(),
                        principal: records[i].Where(pair => pair.Key == "principal").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_codebar: records[i].Where(pair => pair.Key == "tipo_codebar").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} | codebar: {records[i].Where(pair => pair.Key == "codebar").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - codigoproduto: {records[i].Where(pair => pair.Key == "codigoproduto").Select(pair => pair.Value).FirstOrDefault()} | codebar: {records[i].Where(pair => pair.Key == "codebar").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
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
               .AddLog(EnumJob.B2CConsultaProdutosCodebar);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

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
                    await _b2cConsultaProdutosCodebarRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.B2CConsultaProdutosCodebar);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            string sqlCnpjsEmp = _linxMicrovixCommandHandler.CreateGetB2CCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company?>(sql);

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

                    if (_b2cConsultaProdutosCodebarCache.Count == 0)
                    {
                        var list_existentes = await _b2cConsultaProdutosCodebarRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                        _b2cConsultaProdutosCodebarCache = list_existentes.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaProdutosCodebarCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _b2cConsultaProdutosCodebarRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _b2cConsultaProdutosCodebarCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
