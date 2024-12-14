using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaTagsServiceCache : CacheService<B2CConsultaTags>, ICacheService<B2CConsultaTags>, IB2CConsultaTagsServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaTags entity)
        {
            return $"[{entity.id_pedido_item}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido_item"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
