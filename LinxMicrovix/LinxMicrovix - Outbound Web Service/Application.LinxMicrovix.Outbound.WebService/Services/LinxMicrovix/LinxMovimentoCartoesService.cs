using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxMovimentoCartoesService : ILinxMovimentoCartoesService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxMovimentoCartoes> _linxMicrovixRepositoryBase;
        private readonly ILinxMovimentoCartoesRepository _linxMovimentoCartoesRepository;
        private static List<string?> _linxMovimentoCartoesCache { get; set; } = new List<string?>();

        public LinxMovimentoCartoesService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxMovimentoCartoes> linxMicrovixRepositoryBase,
            ILinxMovimentoCartoesRepository linxMovimentoCartoesRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxMovimentoCartoesRepository = linxMovimentoCartoesRepository;
        }

        public List<LinxMovimentoCartoes?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxMovimentoCartoes>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxMovimentoCartoes(
                        listValidations: validations,
                        identificador: records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault(),
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        codlojasitef: records[i].Where(pair => pair.Key == "codlojasitef").Select(pair => pair.Value).FirstOrDefault(),
                        data_lancamento: records[i].Where(pair => pair.Key == "data_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        cupomfiscal: records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault(),
                        credito_debito: records[i].Where(pair => pair.Key == "credito_debito").Select(pair => pair.Value).FirstOrDefault(),
                        id_cartao_bandeira: records[i].Where(pair => pair.Key == "id_cartao_bandeira").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_bandeira: records[i].Where(pair => pair.Key == "descricao_bandeira").Select(pair => pair.Value).FirstOrDefault(),
                        valor: records[i].Where(pair => pair.Key == "valor").Select(pair => pair.Value).FirstOrDefault(),
                        ordem_cartao: records[i].Where(pair => pair.Key == "ordem_cartao").Select(pair => pair.Value).FirstOrDefault(),
                        nsu_host: records[i].Where(pair => pair.Key == "nsu_host").Select(pair => pair.Value).FirstOrDefault(),
                        nsu_sitef: records[i].Where(pair => pair.Key == "nsu_sitef").Select(pair => pair.Value).FirstOrDefault(),
                        cod_autorizacao: records[i].Where(pair => pair.Key == "cod_autorizacao").Select(pair => pair.Value).FirstOrDefault(),
                        id_antecipacoes_financeiras: records[i].Where(pair => pair.Key == "id_antecipacoes_financeiras").Select(pair => pair.Value).FirstOrDefault(),
                        transacao_servico_terceiro: records[i].Where(pair => pair.Key == "transacao_servico_terceiro").Select(pair => pair.Value).FirstOrDefault(),
                        texto_comprovante: records[i].Where(pair => pair.Key == "texto_comprovante").Select(pair => pair.Value).FirstOrDefault(),
                        id_maquineta_pos: records[i].Where(pair => pair.Key == "id_maquineta_pos").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_maquineta: records[i].Where(pair => pair.Key == "descricao_maquineta").Select(pair => pair.Value).FirstOrDefault(),
                        serie_maquineta: records[i].Where(pair => pair.Key == "serie_maquineta").Select(pair => pair.Value).FirstOrDefault(),
                        cartao_prepago: records[i].Where(pair => pair.Key == "cartao_prepago").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | cupomfiscal: {records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - identificador: {records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault()} | cupomfiscal: {records[i].Where(pair => pair.Key == "cupomfiscal").Select(pair => pair.Value).FirstOrDefault()}",
                            exceptionMessage: ex.StackTrace
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxMovimentoCartoes);

            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[identificador]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: cnpj_emp);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxMovimentoCartoesRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
            }

            _logger.SetLogEndDate();
            await _logger.CommitAllChanges();

            return true;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            _logger
               .Clear()
               .AddLog(EnumJob.LinxMovimentoCartoes);

            var xmls = new List<Dictionary<string?, string?>>();
            string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys();

            foreach (var cnpj_emp in cnpjs_emp)
            {
                string? timestamp = await _linxMicrovixRepositoryBase.GetLast7DaysMinTimestamp(
                    jobParameter.schema,
                    jobParameter.tableName,
                    columnDate: "data_lancamento",
                    columnCompany: "cnpj_emp",
                    companyValue: cnpj_emp.doc_company
                );

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters.Replace("[0]", timestamp).Replace("[data_inicial]", $"{DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
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

                if (_linxMovimentoCartoesCache.Count == 0)
                {
                    var list = await _linxMovimentoCartoesRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .GroupBy(y => y.identificador)
                                    .Select(x => x.First())
                                    .ToList()
                    );

                    _linxMovimentoCartoesCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxMovimentoCartoesCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxMovimentoCartoesRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxMovimentoCartoesCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

                    _logger.AddMessage(
                        $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                    );
                }
                else
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
