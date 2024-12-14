using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaStatusServiceCache : CacheService<B2CConsultaStatus>, ICacheService<B2CConsultaStatus>, IB2CConsultaStatusServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaStatus entity)
        {
            return $"[{entity.id_status}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_status"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
