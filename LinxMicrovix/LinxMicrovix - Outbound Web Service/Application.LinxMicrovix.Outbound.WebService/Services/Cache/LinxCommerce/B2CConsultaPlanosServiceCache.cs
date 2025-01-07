using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPlanosServiceCache : CacheService<B2CConsultaPlanos>, ICacheService<B2CConsultaPlanos>, IB2CConsultaPlanosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPlanos entity)
        {
            return $"[{entity.plano}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["plano"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
