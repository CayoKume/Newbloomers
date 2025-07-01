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
    public class LinxMovimentoService : ILinxMovimentoService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxMovimento> _linxMicrovixRepositoryBase;
        private readonly ILinxMovimentoRepository _linxMovimentoRepository;
        private static List<string?> _linxMovimentoCache { get; set; } = new List<string?>();

        public LinxMovimentoService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxMovimento> linxMicrovixRepositoryBase,
            ILinxMovimentoRepository linxMovimentoRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxMovimentoRepository = linxMovimentoRepository;
        }

        public List<LinxMovimento?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxMovimento>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxMovimento(
                        listValidations: validations,
                        cnpj_emp: records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault(),
                        transacao: records[i].Where(pair => pair.Key == "transacao").Select(pair => pair.Value).FirstOrDefault(),
                        usuario: records[i].Where(pair => pair.Key == "usuario").Select(pair => pair.Value).FirstOrDefault(),
                        documento: records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault(),
                        chave_nf: records[i].Where(pair => pair.Key == "chave_nf").Select(pair => pair.Value).FirstOrDefault(),
                        ecf: records[i].Where(pair => pair.Key == "ecf").Select(pair => pair.Value).FirstOrDefault(),
                        numero_serie_ecf: records[i].Where(pair => pair.Key == "numero_serie_ecf").Select(pair => pair.Value).FirstOrDefault(),
                        modelo_nf: records[i].Where(pair => pair.Key == "modelo_nf").Select(pair => pair.Value).FirstOrDefault(),
                        data_documento: records[i].Where(pair => pair.Key == "data_documento").Select(pair => pair.Value).FirstOrDefault(),
                        data_lancamento: records[i].Where(pair => pair.Key == "data_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_cliente: records[i].Where(pair => pair.Key == "codigo_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        serie: records[i].Where(pair => pair.Key == "serie").Select(pair => pair.Value).FirstOrDefault(),
                        desc_cfop: records[i].Where(pair => pair.Key == "desc_cfop").Select(pair => pair.Value).FirstOrDefault(),
                        id_cfop: records[i].Where(pair => pair.Key == "id_cfop").Select(pair => pair.Value).FirstOrDefault(),
                        cod_vendedor: records[i].Where(pair => pair.Key == "cod_vendedor").Select(pair => pair.Value).FirstOrDefault(),
                        quantidade: records[i].Where(pair => pair.Key == "quantidade").Select(pair => pair.Value).FirstOrDefault(),
                        preco_custo: records[i].Where(pair => pair.Key == "preco_custo").Select(pair => pair.Value).FirstOrDefault(),
                        valor_liquido: records[i].Where(pair => pair.Key == "valor_liquido").Select(pair => pair.Value).FirstOrDefault(),
                        desconto: records[i].Where(pair => pair.Key == "desconto").Select(pair => pair.Value).FirstOrDefault(),
                        cst_icms: records[i].Where(pair => pair.Key == "cst_icms").Select(pair => pair.Value).FirstOrDefault(),
                        cst_pis: records[i].Where(pair => pair.Key == "cst_pis").Select(pair => pair.Value).FirstOrDefault(),
                        cst_cofins: records[i].Where(pair => pair.Key == "cst_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        cst_ipi: records[i].Where(pair => pair.Key == "cst_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        valor_icms: records[i].Where(pair => pair.Key == "valor_icms").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_icms: records[i].Where(pair => pair.Key == "aliquota_icms").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_icms_st: records[i].Where(pair => pair.Key == "aliquota_icms_st").Select(pair => pair.Value).FirstOrDefault(),
                        base_icms: records[i].Where(pair => pair.Key == "base_icms").Select(pair => pair.Value).FirstOrDefault(),
                        valor_pis: records[i].Where(pair => pair.Key == "valor_pis").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_pis: records[i].Where(pair => pair.Key == "aliquota_pis").Select(pair => pair.Value).FirstOrDefault(),
                        base_pis: records[i].Where(pair => pair.Key == "base_pis").Select(pair => pair.Value).FirstOrDefault(),
                        valor_cofins: records[i].Where(pair => pair.Key == "valor_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_cofins: records[i].Where(pair => pair.Key == "aliquota_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        base_cofins: records[i].Where(pair => pair.Key == "base_cofins").Select(pair => pair.Value).FirstOrDefault(),
                        valor_icms_st: records[i].Where(pair => pair.Key == "valor_icms_st").Select(pair => pair.Value).FirstOrDefault(),
                        base_icms_st: records[i].Where(pair => pair.Key == "base_icms_st").Select(pair => pair.Value).FirstOrDefault(),
                        valor_ipi: records[i].Where(pair => pair.Key == "valor_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_ipi: records[i].Where(pair => pair.Key == "aliquota_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        base_ipi: records[i].Where(pair => pair.Key == "base_ipi").Select(pair => pair.Value).FirstOrDefault(),
                        valor_total: records[i].Where(pair => pair.Key == "valor_total").Select(pair => pair.Value).FirstOrDefault(),
                        forma_dinheiro: records[i].Where(pair => pair.Key == "forma_dinheiro").Select(pair => pair.Value).FirstOrDefault(),
                        total_dinheiro: records[i].Where(pair => pair.Key == "total_dinheiro").Select(pair => pair.Value).FirstOrDefault(),
                        forma_cheque: records[i].Where(pair => pair.Key == "forma_cheque").Select(pair => pair.Value).FirstOrDefault(),
                        total_cheque: records[i].Where(pair => pair.Key == "total_cheque").Select(pair => pair.Value).FirstOrDefault(),
                        forma_cartao: records[i].Where(pair => pair.Key == "forma_cartao").Select(pair => pair.Value).FirstOrDefault(),
                        total_cartao: records[i].Where(pair => pair.Key == "total_cartao").Select(pair => pair.Value).FirstOrDefault(),
                        forma_crediario: records[i].Where(pair => pair.Key == "forma_crediario").Select(pair => pair.Value).FirstOrDefault(),
                        total_crediario: records[i].Where(pair => pair.Key == "total_crediario").Select(pair => pair.Value).FirstOrDefault(),
                        forma_convenio: records[i].Where(pair => pair.Key == "forma_convenio").Select(pair => pair.Value).FirstOrDefault(),
                        total_convenio: records[i].Where(pair => pair.Key == "total_convenio").Select(pair => pair.Value).FirstOrDefault(),
                        frete: records[i].Where(pair => pair.Key == "frete").Select(pair => pair.Value).FirstOrDefault(),
                        operacao: records[i].Where(pair => pair.Key == "operacao").Select(pair => pair.Value).FirstOrDefault(),
                        tipo_transacao: records[i].Where(pair => pair.Key == "tipo_transacao").Select(pair => pair.Value).FirstOrDefault(),
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        cod_barra: records[i].Where(pair => pair.Key == "cod_barra").Select(pair => pair.Value).FirstOrDefault(),
                        cancelado: records[i].Where(pair => pair.Key == "cancelado").Select(pair => pair.Value).FirstOrDefault(),
                        excluido: records[i].Where(pair => pair.Key == "excluido").Select(pair => pair.Value).FirstOrDefault(),
                        soma_relatorio: records[i].Where(pair => pair.Key == "soma_relatorio").Select(pair => pair.Value).FirstOrDefault(),
                        identificador: records[i].Where(pair => pair.Key == "identificador").Select(pair => pair.Value).FirstOrDefault(),
                        deposito: records[i].Where(pair => pair.Key == "deposito").Select(pair => pair.Value).FirstOrDefault(),
                        obs: records[i].Where(pair => pair.Key == "obs").Select(pair => pair.Value).FirstOrDefault(),
                        preco_unitario: records[i].Where(pair => pair.Key == "preco_unitario").Select(pair => pair.Value).FirstOrDefault(),
                        hora_lancamento: records[i].Where(pair => pair.Key == "hora_lancamento").Select(pair => pair.Value).FirstOrDefault(),
                        natureza_operacao: records[i].Where(pair => pair.Key == "natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        tabela_preco: records[i].Where(pair => pair.Key == "tabela_preco").Select(pair => pair.Value).FirstOrDefault(),
                        nome_tabela_preco: records[i].Where(pair => pair.Key == "nome_tabela_preco").Select(pair => pair.Value).FirstOrDefault(),
                        cod_sefaz_situacao: records[i].Where(pair => pair.Key == "cod_sefaz_situacao").Select(pair => pair.Value).FirstOrDefault(),
                        desc_sefaz_situacao: records[i].Where(pair => pair.Key == "desc_sefaz_situacao").Select(pair => pair.Value).FirstOrDefault(),
                        protocolo_aut_nfe: records[i].Where(pair => pair.Key == "protocolo_aut_nfe").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        forma_cheque_prazo: records[i].Where(pair => pair.Key == "forma_cheque_prazo").Select(pair => pair.Value).FirstOrDefault(),
                        total_cheque_prazo: records[i].Where(pair => pair.Key == "total_cheque_prazo").Select(pair => pair.Value).FirstOrDefault(),
                        cod_natureza_operacao: records[i].Where(pair => pair.Key == "cod_natureza_operacao").Select(pair => pair.Value).FirstOrDefault(),
                        preco_tabela_epoca: records[i].Where(pair => pair.Key == "preco_tabela_epoca").Select(pair => pair.Value).FirstOrDefault(),
                        desconto_total_item: records[i].Where(pair => pair.Key == "desconto_total_item").Select(pair => pair.Value).FirstOrDefault(),
                        conferido: records[i].Where(pair => pair.Key == "conferido").Select(pair => pair.Value).FirstOrDefault(),
                        transacao_pedido_venda: records[i].Where(pair => pair.Key == "transacao_pedido_venda").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_modelo_nf: records[i].Where(pair => pair.Key == "codigo_modelo_nf").Select(pair => pair.Value).FirstOrDefault(),
                        acrescimo: records[i].Where(pair => pair.Key == "acrescimo").Select(pair => pair.Value).FirstOrDefault(),
                        mob_checkout: records[i].Where(pair => pair.Key == "mob_checkout").Select(pair => pair.Value).FirstOrDefault(),
                        aliquota_iss: records[i].Where(pair => pair.Key == "aliquota_iss").Select(pair => pair.Value).FirstOrDefault(),
                        base_iss: records[i].Where(pair => pair.Key == "base_iss").Select(pair => pair.Value).FirstOrDefault(),
                        ordem: records[i].Where(pair => pair.Key == "ordem").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_rotina_origem: records[i].Where(pair => pair.Key == "codigo_rotina_origem").Select(pair => pair.Value).FirstOrDefault(),
                        troco: records[i].Where(pair => pair.Key == "troco").Select(pair => pair.Value).FirstOrDefault(),
                        transportador: records[i].Where(pair => pair.Key == "transportador").Select(pair => pair.Value).FirstOrDefault(),
                        icms_aliquota_desonerado: records[i].Where(pair => pair.Key == "icms_aliquota_desonerado").Select(pair => pair.Value).FirstOrDefault(),
                        icms_valor_desonerado_item: records[i].Where(pair => pair.Key == "icms_valor_desonerado_item").Select(pair => pair.Value).FirstOrDefault(),
                        empresa: records[i].Where(pair => pair.Key == "empresa").Select(pair => pair.Value).FirstOrDefault(),
                        desconto_item: records[i].Where(pair => pair.Key == "desconto_item").Select(pair => pair.Value).FirstOrDefault(),
                        aliq_iss: records[i].Where(pair => pair.Key == "aliq_iss").Select(pair => pair.Value).FirstOrDefault(),
                        iss_base_item: records[i].Where(pair => pair.Key == "iss_base_item").Select(pair => pair.Value).FirstOrDefault(),
                        despesas: records[i].Where(pair => pair.Key == "despesas").Select(pair => pair.Value).FirstOrDefault(),
                        seguro_total_item: records[i].Where(pair => pair.Key == "seguro_total_item").Select(pair => pair.Value).FirstOrDefault(),
                        acrescimo_total_item: records[i].Where(pair => pair.Key == "acrescimo_total_item").Select(pair => pair.Value).FirstOrDefault(),
                        despesas_total_item: records[i].Where(pair => pair.Key == "despesas_total_item").Select(pair => pair.Value).FirstOrDefault(),
                        forma_pix: records[i].Where(pair => pair.Key == "forma_pix").Select(pair => pair.Value).FirstOrDefault(),
                        total_pix: records[i].Where(pair => pair.Key == "total_pix").Select(pair => pair.Value).FirstOrDefault(),
                        forma_deposito_bancario: records[i].Where(pair => pair.Key == "forma_deposito_bancario").Select(pair => pair.Value).FirstOrDefault(),
                        total_deposito_bancario: records[i].Where(pair => pair.Key == "total_deposito_bancario").Select(pair => pair.Value).FirstOrDefault(),
                        id_venda_produto_b2c: records[i].Where(pair => pair.Key == "id_venda_produto_b2c").Select(pair => pair.Value).FirstOrDefault(),
                        item_promocional: records[i].Where(pair => pair.Key == "item_promocional").Select(pair => pair.Value).FirstOrDefault(),
                        acrescimo_item: records[i].Where(pair => pair.Key == "acrescimo_item").Select(pair => pair.Value).FirstOrDefault(),
                        icms_st_antecipado_aliquota: records[i].Where(pair => pair.Key == "icms_st_antecipado_aliquota").Select(pair => pair.Value).FirstOrDefault(),
                        icms_st_antecipado_margem: records[i].Where(pair => pair.Key == "icms_st_antecipado_margem").Select(pair => pair.Value).FirstOrDefault(),
                        icms_st_antecipado_percentual_reducao: records[i].Where(pair => pair.Key == "icms_st_antecipado_percentual_reducao").Select(pair => pair.Value).FirstOrDefault(),
                        icms_st_antecipado_valor_item: records[i].Where(pair => pair.Key == "icms_st_antecipado_valor_item").Select(pair => pair.Value).FirstOrDefault(),
                        icms_base_desonerado_item: records[i].Where(pair => pair.Key == "icms_base_desonerado_item").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_status_nfe: records[i].Where(pair => pair.Key == "codigo_status_nfe").Select(pair => pair.Value).FirstOrDefault(),
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
                                stage: EnumStages.DeserializeXMLToObject,
                                error: EnumError.Validation,
                                logLevel: EnumMessageLevel.Warning,
                                message: $"Error when convert record - documento: {records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()}\n" +
                                         $"{validations[j].ErrorMessage}"
                            );
                        }
                        continue;
                    }

                    list.Add(entity);
                }
                catch (Exception ex)
                {
                    throw new InternalException(
                        stage: EnumStages.DeserializeXMLToObject,
                        error: EnumError.Exception,
                        level: EnumMessageLevel.Error,
                        message: $"Error when convert record - documento: {records[i].Where(pair => pair.Key == "documento").Select(pair => pair.Value).FirstOrDefault()} | cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | cnpj_emp: {records[i].Where(pair => pair.Key == "cnpj_emp").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxMovimento);

                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                    parametersList: parameters
                    .Replace("[0]", "0")
                    .Replace("[data_inicial]", "2000-01-01")
                    .Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}")
                    .Replace("[documento]", identificador),
                    jobParameter: jobParameter,
                    cnpj_emp: cnpj_emp);

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

                if (xmls.Count() > 0)
                {
                    var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                    foreach (var record in listRecords)
                    {
                        await _linxMovimentoRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    }

                    await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());
                }
            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            try
            {
                _logger
                   .Clear()
                   .AddLog(EnumJob.LinxMovimento);

                var xmls = new List<Dictionary<string?, string?>>();
                string? parameters = await _linxMicrovixRepositoryBase.GetParameters(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
                var cnpjs_emp = await _linxMicrovixRepositoryBase.GetMicrovixCompanys();

                foreach (var cnpj_emp in cnpjs_emp)
                {
                    var body = _linxMicrovixServiceBase.BuildBodyRequest(
                                parametersList: parameters.Replace("[0]", "0").Replace("[data_inicial]", $"{DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd")}").Replace("[data_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}"),
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

                    if (_linxMovimentoCache.Count == 0)
                    {
                        var list = await _linxMovimentoRepository.GetRegistersExists(
                            jobParameter: jobParameter,
                            registros: listRecords
                                            .GroupBy(y => y.identificador)
                                            .Select(x => x.First())
                                            .ToList()
                        );

                        _linxMovimentoCache = list.ToList();
                    }

                    var _listSomenteNovos = listRecords.Where(x => !_linxMovimentoCache.Any(y =>
                        y == x.recordKey
                    )).ToList();

                    if (_listSomenteNovos.Count() > 0)
                    {
                        _linxMovimentoRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                        await _linxMicrovixRepositoryBase.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                        for (int i = 0; i < _listSomenteNovos.Count; i++)
                        {
                            _logger.AddRecord(_listSomenteNovos[i].recordKey, _listSomenteNovos[i].recordXml);
                        }

                        _linxMovimentoCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));

                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                    }
                    else
                        _logger.AddMessage(
                            $"Concluída com sucesso: {_listSomenteNovos.Count} registro(s) novo(s) inserido(s)!"
                        );
                }

            }
            catch (SQLCommandException ex)
            {
                _logger.AddMessage(
                    stage: ex.Stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage,
                    commandSQL: ex.CommandSQL
                );

                throw;
            }
            catch (InternalException ex)
            {
                _logger.AddMessage(
                    stage: ex.stage,
                    error: ex.Error,
                    logLevel: ex.MessageLevel,
                    message: ex.Message,
                    exceptionMessage: ex.ExceptionMessage
                );

                throw;
            }
            catch (Exception ex)
            {
                _logger.AddMessage(
                    message: "Error when executing GetRecords method",
                    exceptionMessage: ex.Message
                );
            }
            finally
            {
                _logger.SetLogEndDate();
                await _logger.CommitAllChanges();
            }

            return true;
        }
    }
}
