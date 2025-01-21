using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Base;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.LinxMicrovix;
using Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix;
using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Api;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxMicrovix;
using System.ComponentModel.DataAnnotations;

namespace Application.LinxMicrovix.Outbound.WebService.Services.LinxMicrovix
{
    public class LinxProdutosService : ILinxProdutosService
    {
        private readonly IAPICall _apiCall;
        private readonly ILoggerService _logger;
        private readonly ILinxMicrovixServiceBase _linxMicrovixServiceBase;
        private readonly ILinxMicrovixRepositoryBase<LinxProdutos> _linxMicrovixRepositoryBase;
        private readonly ILinxProdutosRepository _linxProdutosRepository;
        private static ILinxProdutosServiceCache linxProdutosServiceCache { get; set; } = new LinxProdutosServiceCache();

        public LinxProdutosService(
            IAPICall apiCall,
            ILoggerService logger,
            ILinxMicrovixServiceBase linxMicrovixServiceBase,
            ILinxMicrovixRepositoryBase<LinxProdutos> linxMicrovixRepositoryBase,
            ILinxProdutosRepository linxProdutosRepository
        )
        {
            _apiCall = apiCall;
            _logger = logger;
            _linxMicrovixServiceBase = linxMicrovixServiceBase;
            _linxMicrovixRepositoryBase = linxMicrovixRepositoryBase;
            _linxProdutosRepository = linxProdutosRepository;
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
                        portal: records[i].Where(pair => pair.Key == "portal").Select(pair => pair.Value).FirstOrDefault()
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
                    throw new InternalException(
                        stage: EnumStages.DeserializeXMLToObject,
                        error: EnumError.Exception,
                        level: EnumMessageLevel.Error,
                        message: $"Error when convert record - cod_produto: {records[i].Where(pair => pair.Key == "cod_produto").Select(pair => pair.Value).FirstOrDefault()} | nome: {records[i].Where(pair => pair.Key == "nome").Select(pair => pair.Value).FirstOrDefault()}",
                        exceptionMessage: ex.Message
                    );
                }
            };

            return list;
        }

        public async Task<bool> GetRecord(LinxAPIParam jobParameter, string? identificador, string? cnpj_emp)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetRecords(LinxAPIParam jobParameter)
        {
            throw new NotImplementedException();
        }
    }
}
