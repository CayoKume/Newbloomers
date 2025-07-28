using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Services.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Handlers.Commands;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxProdutosService : ILinxProdutosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly IIntegrationsCoreRepository _integrationsCoreRepository;
        private readonly ILinxProdutosRepository _linxProdutosRepository;
        private readonly ILinxMicrovixCommandHandler _linxMicrovixCommandHandler;
        private static List<string?> _linxProdutosCache { get; set; } = new List<string?>();

        public LinxProdutosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            IIntegrationsCoreRepository integrationsCoreRepository,
            ILinxProdutosRepository linxProdutosRepository,
            ILinxMicrovixCommandHandler linxMicrovixCommandHandler
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _integrationsCoreRepository = integrationsCoreRepository;
            _linxProdutosRepository = linxProdutosRepository;
            _linxMicrovixCommandHandler = linxMicrovixCommandHandler;
        }

        public List<LinxProdutos?> DeserializeXMLToObject(LinxAPIParam jobParameter, List<Dictionary<string?, string?>> records)
        {
            var list = new List<LinxProdutos>();
            for (int i = 0; i < records.Count(); i++)
            {
                try
                {
                    var validations = new List<ValidationResult>();

                    var entity = new LinxProdutos(
                        listValidations: validations,
                        cod_produto: records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault(),
                        cod_barra: records[i].Where(pair => pair.Key == "cod_barra").Select(pair => pair.Value).FirstOrDefault(),
                        nome: records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).FirstOrDefault(),
                        ncm: records[i].Where(pair => pair.Key == "ncm").Select(pair => pair.Value).FirstOrDefault(),
                        cest: records[i].Where(pair => pair.Key == "cest").Select(pair => pair.Value).FirstOrDefault(),
                        referencia: records[i].Where(pair => pair.Key == "referencia").Select(pair => pair.Value).FirstOrDefault(),
                        cod_auxiliar: records[i].Where(pair => pair.Key == "cod_auxiliar").Select(pair => pair.Value).FirstOrDefault(),
                        unidade: records[i].Where(pair => pair.Key == "unidade").Select(pair => pair.Value).FirstOrDefault(),
                        desc_cor: records[i].Where(pair => pair.Key == "desc_cor").Select(pair => pair.Value).FirstOrDefault(),
                        desc_tamanho: records[i].Where(pair => pair.Key == "desc_tamanho").Select(pair => pair.Value).FirstOrDefault(),
                        desc_setor: records[i].Where(pair => pair.Key == "desc_setor").Select(pair => pair.Value).FirstOrDefault(),
                        desc_linha: records[i].Where(pair => pair.Key == "desc_linha").Select(pair => pair.Value).FirstOrDefault(),
                        desc_marca: records[i].Where(pair => pair.Key == "desc_marca").Select(pair => pair.Value).FirstOrDefault(),
                        desc_colecao: records[i].Where(pair => pair.Key == "desc_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        dt_update: records[i].Where(pair => pair.Key == "dt_update").Select(pair => pair.Value).FirstOrDefault(),
                        cod_fornecedor: records[i].Where(pair => pair.Key == "cod_fornecedor").Select(pair => pair.Value).FirstOrDefault(),
                        desativado: records[i].Where(pair => pair.Key == "desativado").Select(pair => pair.Value).FirstOrDefault(),
                        desc_espessura: records[i].Where(pair => pair.Key == "desc_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        id_espessura: records[i].Where(pair => pair.Key == "id_espessura").Select(pair => pair.Value).FirstOrDefault(),
                        desc_classificacao: records[i].Where(pair => pair.Key == "desc_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                        id_classificacao: records[i].Where(pair => pair.Key == "id_classificacao").Select(pair => pair.Value).FirstOrDefault(),
                        origem_mercadoria: records[i].Where(pair => pair.Key == "origem_mercadoria").Select(pair => pair.Value).FirstOrDefault(),
                        peso_liquido: records[i].Where(pair => pair.Key == "peso_liquido").Select(pair => pair.Value).FirstOrDefault(),
                        peso_bruto: records[i].Where(pair => pair.Key == "peso_bruto").Select(pair => pair.Value).FirstOrDefault(),
                        id_cor: records[i].Where(pair => pair.Key == "id_cor").Select(pair => pair.Value).FirstOrDefault(),
                        id_tamanho: records[i].Where(pair => pair.Key == "id_tamanho").Select(pair => pair.Value).FirstOrDefault(),
                        id_setor: records[i].Where(pair => pair.Key == "id_setor").Select(pair => pair.Value).FirstOrDefault(),
                        id_linha: records[i].Where(pair => pair.Key == "id_linha").Select(pair => pair.Value).FirstOrDefault(),
                        id_marca: records[i].Where(pair => pair.Key == "id_marca").Select(pair => pair.Value).FirstOrDefault(),
                        id_colecao: records[i].Where(pair => pair.Key == "id_colecao").Select(pair => pair.Value).FirstOrDefault(),
                        dt_inclusao: records[i].Where(pair => pair.Key == "dt_inclusao").Select(pair => pair.Value).FirstOrDefault(),
                        fator_conversao: records[i].Where(pair => pair.Key == "fator_conversao").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_integracao_ws: records[i].Where(pair => pair.Key == "codigo_integracao_ws").Select(pair => pair.Value).FirstOrDefault(),
                        codigo_integracao_reshop: records[i].Where(pair => pair.Key == "codigo_integracao_reshop").Select(pair => pair.Value).FirstOrDefault(),
                        id_produtos_opticos_tipo: records[i].Where(pair => pair.Key == "id_produtos_opticos_tipo").Select(pair => pair.Value).FirstOrDefault(),
                        id_sped_tipo_item: records[i].Where(pair => pair.Key == "id_sped_tipo_item").Select(pair => pair.Value).FirstOrDefault(),
                        componente: records[i].Where(pair => pair.Key == "componente").Select(pair => pair.Value).FirstOrDefault(),
                        altura_para_frete: records[i].Where(pair => pair.Key == "altura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        largura_para_frete: records[i].Where(pair => pair.Key == "largura_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        comprimento_para_frete: records[i].Where(pair => pair.Key == "comprimento_para_frete").Select(pair => pair.Value).FirstOrDefault(),
                        loja_virtual: records[i].Where(pair => pair.Key == "loja_virtual").Select(pair => pair.Value).FirstOrDefault(),
                        cod_comprador: records[i].Where(pair => pair.Key == "cod_comprador").Select(pair => pair.Value).FirstOrDefault(),
                        obrigatorio_identificacao_cliente: records[i].Where(pair => pair.Key == "obrigatorio_identificacao_cliente").Select(pair => pair.Value).FirstOrDefault(),
                        descricao_basica: records[i].Where(pair => pair.Key == "descricao_basica").Select(pair => pair.Value).FirstOrDefault(),
                        curva: records[i].Where(pair => pair.Key == "curva").Select(pair => pair.Value).FirstOrDefault(),
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
                                message: $"Error when convert record - cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | nome: {records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).FirstOrDefault()}\n" +
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
                        message: $"Error when convert record - cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | nome: {records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).FirstOrDefault()}",
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
               .AddLog(EnumJob.LinxProdutos);

            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _integrationsCoreRepository.GetRecord<string>(sql);

            var body = _linxMicrovixServiceBase.BuildBodyRequest(
                parametersList: parameters
                .Replace("[0]", "0")
                .Replace("[dt_update_inicio]", "2000-01-01")
                .Replace("[dt_update_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}")
                .Replace("[cod_produto]", identificador),
                jobParameter: jobParameter,
                cnpj_emp: jobParameter.docMainCompany);

            string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
            var xmls = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                foreach (var record in listRecords)
                {
                    await _linxProdutosRepository.InsertRecord(record: record, jobParameter: jobParameter);
                    _logger.AddRecord(record.recordKey, record.recordXml);
                }

                await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

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
               .AddLog(EnumJob.LinxProdutos);

            var xmls = new List<Dictionary<string?, string?>>();
            string sql = _linxMicrovixCommandHandler.CreateGetParametersQuery(jobParameter.parametersInterval, jobParameter.parametersTableName, jobParameter.jobName);
            string? parameters = await _integrationsCoreRepository.GetRecord<string>(sql);
            
            var ids_setor = await _linxProdutosRepository.GetProductsSetorIds(jobParameter);

            foreach (var id_setor in ids_setor)
            {
                string sqlTimestamp = _linxMicrovixCommandHandler.CreateGetLast7DaysMinTimestampQuery(jobParameter.schema, jobParameter.tableName, "dt_update");
                string? timestamp = await _integrationsCoreRepository.GetRecord<string>(sqlTimestamp);

                var body = _linxMicrovixServiceBase.BuildBodyRequest(
                        parametersList: parameters.Replace("[0]", timestamp).Replace("[dt_update_inicio]", $"{DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd")}").Replace("[dt_update_fim]", $"{DateTime.Today.ToString("yyyy-MM-dd")}").Replace("[id_setor]", id_setor),
                        jobParameter: jobParameter,
                        cnpj_emp: jobParameter.docMainCompany
                    );

                string? response = await _apiCall.PostAsync(jobParameter: jobParameter, body: body);
                var result = _linxMicrovixServiceBase.DeserializeResponseToXML(jobParameter, response);
                xmls.AddRange(result);
            }

            if (xmls.Count() > 0)
            {
                var listRecords = DeserializeXMLToObject(jobParameter, xmls);

                if (_linxProdutosCache.Count == 0)
                {
                    var list = await _linxProdutosRepository.GetRegistersExists(
                        jobParameter: jobParameter,
                        registros: listRecords
                                    .Select(x => x.cod_produto)
                                    .ToList()
                    );

                    _linxProdutosCache = list.ToList();
                }

                var _listSomenteNovos = listRecords.Where(x => !_linxProdutosCache.Any(y =>
                    y == x.recordKey
                )).ToList();

                if (_listSomenteNovos.Count() > 0)
                {
                    _linxProdutosRepository.BulkInsertIntoTableRaw(records: _listSomenteNovos, jobParameter: jobParameter);
                    await _integrationsCoreRepository.CallDbProcMerge(jobParameter.schema, jobParameter.tableName, _logger.GetExecutionGuid());

                    for (int i = 0; i < _listSomenteNovos.Count; i++)
                    {
                        _logger.AddRecord(
                            key: _listSomenteNovos[i].recordKey,
                            xml: _listSomenteNovos[i].recordXml
                        );
                    }

                    _linxProdutosCache.AddRange(_listSomenteNovos.Select(x => x.recordKey));
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
