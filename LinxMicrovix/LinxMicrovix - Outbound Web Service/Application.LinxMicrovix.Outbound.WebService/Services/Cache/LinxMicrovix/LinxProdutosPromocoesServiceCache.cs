using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxProdutosPromocoesServiceCache : CacheService<LinxProdutosPromocoes>, ICacheService<LinxProdutosPromocoes>, ILinxProdutosPromocoesServiceCache, ICacheBase
    {
        public override string GetKey(LinxProdutosPromocoes entity)
        {
            return $"[{entity.cnpj_emp}]|[{entity.cod_produto}]|[{entity.data_cadastro_promocao}]|[{entity.id_campanha}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["data_cadastro_promocao"]}]|[{dictionaryFields["id_campanha"]}]";
        }
    }
}
