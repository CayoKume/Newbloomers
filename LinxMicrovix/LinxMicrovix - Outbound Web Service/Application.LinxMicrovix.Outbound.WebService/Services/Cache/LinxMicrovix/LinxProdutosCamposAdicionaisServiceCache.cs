using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxProdutosCamposAdicionaisServiceCache : CacheService<LinxProdutosCamposAdicionais>, ICacheService<LinxProdutosCamposAdicionais>, ILinxProdutosCamposAdicionaisServiceCache, ICacheBase
    {
        public override string GetKey(LinxProdutosCamposAdicionais entity)
        {
            return $"[{entity.cod_produto}]|[{entity.campo}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["campo"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
