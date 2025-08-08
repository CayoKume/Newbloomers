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
    /// <summary>
    /// A tabela classificacao geralmente não é grande então efetuamos a busca completa no endpoint indicando o timestamp 0.
    /// E como ela possui dados gerais não é preciso pesquisar por todos os cnpjs, ao pesquisar pelo cnpj da matriz os dados serão os 
    /// mesmos para os demais cnpjs
    /// </summary>
    public class B2CConsultaClassificacaoService : IB2CConsultaClassificacaoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private readonly ICoreRepository _coreRepository;
        private readonly IB2CConsultaClassificacaoRepository _b2cConsultaClassificacaoRepository;
        private static List<string?> _b2cConsultaClassificacaoCache { get; set; } = new List<string?>();

        public B2CConsultaClassificacaoService(
            IAPICall apiCall,
            ILoggerService logger,
            IB2CConsultaClassificacaoRepository b2cConsultaClassificacaoRepository,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler,
            ICoreRepository coreRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _b2cConsultaClassificacaoRepository = b2cConsultaClassificacaoRepository;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
            _coreRepository = coreRepository;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClassificacao);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(
                jobParameter.parametersInterval,
                jobParameter.tableName,
                jobParameter.jobName
            );

            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0"),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany
            );

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_b2cConsultaClassificacaoCache.Count == 0)
                {
                    var list = await _b2cConsultaClassificacaoRepository.GetRegistersExists(jobParameter: jobParameter, registros: listRecords);
                    _b2cConsultaClassificacaoCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_b2cConsultaClassificacaoCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _b2cConsultaClassificacaoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _b2cConsultaClassificacaoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
                }

                _logger.AddMessage(
                    $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                );
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.B2CConsultaClassificacao);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(
                jobParameter.parametersInterval,
                jobParameter.tableName,
                jobParameter.jobName
            );

            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[codigo_classificacao]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _b2cConsultaClassificacaoRepository.InsertRecord(record: record, jobParameter: jobParameter);
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

        public List<B2CConsultaClassificacao?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<B2CConsultaClassificacao>();

            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    //Refatorar Aqui (Não esquecer de voltar esse comentario)
                    //var validations = new List<ValidationResult>();

                    //var entity = new B2CConsultaClassificacao(
                    //    listValidations: validations,
                    //    codigo_classificacao: records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                    //    nome_classificacao: records[i].Where(pair => pair.Key == "nome_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                    //    timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                    //    portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault(),
                    //    recordXml: records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault()
                    //);

                    //var contexto = new ValidationContext(entity, null, null);
                    //Validator.TryValidateObject(entity, contexto, validations, true);

                    //if (validations.Count() > 0)
                    //{
                    //    for (int j = 0; j < validations.Count(); j++)
                    //    {
                    //        _logger.AddMessage(
                    //            message: $"Error when convert record - codigo_classificacao: {records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).FirstOrDefault()} | nome_classificacao: {records[i].Where(pair => pair.Key == "nome_classificacao").Select(pair => pair.Value).FirstOrDefault()}\n" +
                    //                     $"{validations[j].ErrorMessage}"
                    //        );
                    //    }
                    //    continue;
                    //}

                    //list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - codigo_classificacao: {records[i].Where(pair => pair.Key == "codigo_classificacao").Select(pair => pair.Value).FirstOrDefault()} | nome_classificacao: {records[i].Where(pair => pair.Key == "nome_classificacao").Select(pair => pair.Value).FirstOrDefault()} - {ex.Message}",
                        exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }
    }
}
