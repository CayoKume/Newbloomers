using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaUnidadeServiceCache : CacheService<B2CConsultaUnidade>, ICacheService<B2CConsultaUnidade>, IB2CConsultaUnidadeServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaUnidade entity)
        {
            return $"[{entity.unidade}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["unidade"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
