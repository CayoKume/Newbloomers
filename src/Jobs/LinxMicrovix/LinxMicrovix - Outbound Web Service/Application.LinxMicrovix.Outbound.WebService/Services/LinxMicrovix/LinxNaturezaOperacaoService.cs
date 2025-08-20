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
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxNaturezaOperacaoService : ILinxNaturezaOperacaoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxNaturezaOperacaoRepository _linxNaturezaOperacaoRepository;
        private readonly IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNaturezaOperacao> _validator;
        private readonly ICoreRepository _coreRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _linxNaturezaOperacaoCache { get; set; } = new List<string?>();

        public LinxNaturezaOperacaoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxNaturezaOperacaoRepository linxNaturezaOperacaoRepository,
            ICoreRepository coreRepository,
            IValidator<Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNaturezaOperacao> validator,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _validator = validator;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxNaturezaOperacaoRepository = linxNaturezaOperacaoRepository;
            _coreRepository = coreRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;

        }

        public List<LinxNaturezaOperacao?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxNaturezaOperacao>();
            
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var entity = new Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix.LinxNaturezaOperacao(
                        cod_natureza_operacao: records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        descricao: records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault(),
                        soma_relatorios: records[i].Where(pair => pair.Key == "soma_relatorios").Select(pair => pair.Value).FirstOrDefault(),
                        operacao: records[i].Where(pair => pair.Key == "operacao").Select(pair => pair.Value).FirstOrDefault(),
                        inativa: records[i].Where(pair => pair.Key == "inativa").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_ipi: records[i].Where(pair => pair.Key == "calcula_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_iss: records[i].Where(pair => pair.Key == "calcula_iss").Select(pair => pair.Value).FirstOrDefault(),
                        calcula_irrf: records[i].Where(pair => pair.Key == "calcula_irrf").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_preco: records[i].Where(pair => pair.Key == "tipo_preco").Select(pair => pair.Value).FirstOrDefault(),
                        atualiza_custo: records[i].Where(pair => pair.Key == "atualiza_custo").Select(pair => pair.Value).FirstOrDefault(),
                        transferencia: records[i].Where(pair => pair.Key == "transferencia").Select(pair => pair.Value).FirstOrDefault(),
                        baixar_estoque: records[i].Where(pair => pair.Key == "baixar_estoque").Select(pair => pair.Value).FirstOrDefault(),
                        consumo_proprio: records[i].Where(pair => pair.Key == "consumo_proprio").Select(pair => pair.Value).FirstOrDefault(),
                        contabiliza_cmv: records[i].Where(pair => pair.Key == "contabiliza_cmv").Select(pair => pair.Value).FirstOrDefault(),
                        despesa: records[i].Where(pair => pair.Key == "despesa").Select(pair => pair.Value).FirstOrDefault(),
                        atualiza_custo_medio: records[i].Where(pair => pair.Key == "atualiza_custo_medio").Select(pair => pair.Value).FirstOrDefault(),
                        exige_nf_origem: records[i].Where(pair => pair.Key == "exige_nf_origem").Select(pair => pair.Value).FirstOrDefault(),
                        integra_contabilidade: records[i].Where(pair => pair.Key == "integra_contabilidade").Select(pair => pair.Value).FirstOrDefault(),
                        id_obs: records[i].Where(pair => pair.Key == "id_obs").Select(pair => pair.Value).FirstOrDefault(),
                        venda_futura: records[i].Where(pair => pair.Key == "venda_futura").Select(pair => pair.Value).FirstOrDefault(),
                        base_icms_considera_ipi: records[i].Where(pair => pair.Key == "base_icms_considera_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        permite_escolha_historico: records[i].Where(pair => pair.Key == "permite_escolha_historico").Select(pair => pair.Value).FirstOrDefault(),
                        import_produtos: records[i].Where(pair => pair.Key == "import_produtos").Select(pair => pair.Value).FirstOrDefault(),
                        deposito_reserva_venda: records[i].Where(pair => pair.Key == "deposito_reserva_venda").Select(pair => pair.Value).FirstOrDefault(),
                        exibe_nfe: records[i].Where(pair => pair.Key == "exibe_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        faturamento_antecipado: records[i].Where(pair => pair.Key == "faturamento_antecipado").Select(pair => pair.Value).FirstOrDefault(),
                        exibir_informacoes_imposto: records[i].Where(pair => pair.Key == "exibir_informacoes_imposto").Select(pair => pair.Value).FirstOrDefault(),
                        gera_garantia_nacional: records[i].Where(pair => pair.Key == "gera_garantia_nacional").Select(pair => pair.Value).FirstOrDefault(),
                        transferencia_deposito: records[i].Where(pair => pair.Key == "transferencia_deposito").Select(pair => pair.Value).FirstOrDefault(),
                        venda_diferencial_aliquota: records[i].Where(pair => pair.Key == "venda_diferencial_aliquota").Select(pair => pair.Value).FirstOrDefault(),
                        insere_obs_pis_cofins: records[i].Where(pair => pair.Key == "insere_obs_pis_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        diferencial_ativo_consumo: records[i].Where(pair => pair.Key == "diferencial_ativo_consumo").Select(pair => pair.Value).FirstOrDefault(),
                        recusa_de: records[i].Where(pair => pair.Key == "recusa_de").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_ws: records[i].Where(pair => pair.Key == "codigo_ws").Select(pair => pair.Value).FirstOrDefault(),
                        timestamp: records[i].Where(pair => pair.Key == "timestamp").Select(pair => pair.Value).FirstOrDefault(),
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
                    );

                    var xml = records[i].Where(pair => pair.Key == "recordXml").Select(pair => pair.Value).FirstOrDefault();
                    var validations = _validator.Validate(entity);

                    if (validations.Errors.Count() > 0)
                    {
                        var message = $"Error when convert record - cod_natureza_operacao: {records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}" + "\n";
		
                        for (int j = 0; j < validations.Errors.Count(); j++)
                        {
                            var msg = validations.Errors[j].ErrorMessage;
                            var property = validations.Errors[j].PropertyName;
                            var value = validations.Errors[j].FormattedMessagePlaceholderValues.Where(x => x.Key == "PropertyValue").FirstOrDefault().Value;
                            message += $"{msg.Replace("[0]", $"{property}: {value}")}";
                        }
		
                        _logger.AddMessage(message);
                    }
		
                    list.Add(new LinxNaturezaOperacao(entity, xml));
                }
                catch (Exception ex)
                {
                    throw new GeneralException(
                        message: $"Error when convert record - cod_natureza_operacao: {records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault()} | descricao: {records[i].Where(pair => pair.Key == "descricao").Select(pair => pair.Value).FirstOrDefault()}",
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
               .AddLog(EnumJob.LinxNaturezaOperacao);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _coreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters.Replace("[0]", "0").Replace("[cod_natureza_operacao]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxNaturezaOperacaoRepository.InsertRecord(record: record, jobParameter: jobParameter);
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
               .AddLog(EnumJob.LinxNaturezaOperacao);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
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

                if (_linxNaturezaOperacaoCache.Count == 0)
                {
                    var list = await _linxNaturezaOperacaoRepository.GetRegistersExists();
                    _linxNaturezaOperacaoCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxNaturezaOperacaoCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxNaturezaOperacaoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _coreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                    }

                    _linxNaturezaOperacaoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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


