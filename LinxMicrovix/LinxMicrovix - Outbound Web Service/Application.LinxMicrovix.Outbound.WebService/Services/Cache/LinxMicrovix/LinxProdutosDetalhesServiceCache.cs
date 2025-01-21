using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxProdutosDetalhesServiceCache : CacheService<LinxProdutosDetalhes>, ICacheService<LinxProdutosDetalhes>, ILinxProdutosDetalhesServiceCache, ICacheBase
    {
        public override string GetKey(LinxProdutosDetalhes entity)
        {
            return $"[{entity.cod_produto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
