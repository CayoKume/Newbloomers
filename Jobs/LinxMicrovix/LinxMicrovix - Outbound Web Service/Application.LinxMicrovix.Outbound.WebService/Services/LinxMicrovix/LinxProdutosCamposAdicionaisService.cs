using Application.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.Core.Entities.Exceptions;
using Domain.Core.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;

using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;
using Domain.Core.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Handlers.Commands;
using Domain.LinxMicrovix.Outbound.WebService.Models.Base;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxProdutosCamposAdicionaisService : ILinxProdutosCamposAdicionaisService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxProdutosCamposAdicionaisRepository _linxProdutosCamposAdicionaisRepository;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;

        private static List<string> _linxProdutosCamposAdicionaisCache { get; set; } = new List<string>();

        public LinxProdutosCamposAdicionaisService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxProdutosCamposAdicionaisRepository linxProdutosCamposAdicionaisRepository,
            ICoreRepository coreRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxProdutosCamposAdicionaisRepository = linxProdutosCamposAdicionaisRepository;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;

        }

        public List<LinxProdutosCamposAdicionais?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxProdutosCamposAdicionais>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxProdutosCamposAdicionais(
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        campo: records[i].Where(pair => pair.Key == "campo").Select(pair => pair.Value).FirstOrDefault(),
                        valor: records[i].Where(pair => pair.Key == "valor").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | campo: {records[i].Where(pair => pair.Key == "campo").Select(pair => pair.Value).FirstOrDefault()} | valor: {records[i].Where(pair => pair.Key == "valor").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | campo: {records[i].Where(pair => pair.Key == "campo").Select(pair => pair.Value).FirstOrDefault()} | valor: {records[i].Where(pair => pair.Key == "valor").Select(pair => pair.Value).FirstOrDefault()}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxProdutosCamposAdicionais);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[cod_produto]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxProdutosCamposAdicionaisRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.LinxProdutosCamposAdicionais);

            var xmls = new List<Dictionary<string?, string?>>();

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var sqlCnpjs = _linxMicrovixCommandHandler.CreateGetMicrovixCompanysQuery();
            var cnpjs_emp = await _coreRepository.GetRecords<Company>(sqlCnpjs);

            foreach (var cnpj_emp in cnpjs_emp)
            {
                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                            parametersList: parameters.Replace("[0]", "0").Replace("[data_mov_ini]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[data_mov_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
                            jobParameter: jobParameter,
                            cnpj_emp: cnpj_emp.doc_company
                        );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                xmls.AddRange(result);
            }

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxProdutosCamposAdicionaisCache.Count == 0)
                {
                    var list = await _linxProdutosCamposAdicionaisRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .GroupBy(y => y.cod_produto)
                                    .Select(x => x.First())
                                    .ToList()
                    );

                    _linxProdutosCamposAdicionaisCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxProdutosCamposAdicionaisCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxProdutosCamposAdicionaisRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxProdutosCamposAdicionaisCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
