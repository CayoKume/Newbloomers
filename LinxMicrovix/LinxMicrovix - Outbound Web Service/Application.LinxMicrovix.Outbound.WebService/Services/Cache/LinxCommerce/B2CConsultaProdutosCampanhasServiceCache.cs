using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCampanhasServiceCache : CacheService<B2CConsultaProdutosCampanhas>, ICacheService<B2CConsultaProdutosCampanhas>, IB2CConsultaProdutosCampanhasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCampanhas entity)
        {
            return $"[{entity.codigo_campanha}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_campanha"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
