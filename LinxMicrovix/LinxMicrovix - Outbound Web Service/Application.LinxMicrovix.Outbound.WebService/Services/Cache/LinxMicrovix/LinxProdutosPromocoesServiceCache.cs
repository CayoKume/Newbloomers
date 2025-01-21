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
            return $"[{entity.cod_produto}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_produto"]}]";
        }
    }
}
