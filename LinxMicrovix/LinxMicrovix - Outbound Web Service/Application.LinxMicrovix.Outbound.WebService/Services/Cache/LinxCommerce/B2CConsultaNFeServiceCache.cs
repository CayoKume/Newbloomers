using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaNFeServiceCache : CacheService<B2CConsultaNFe>, ICacheService<B2CConsultaNFe>, IB2CConsultaNFeServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaNFe entity)
        {
            return $"[{entity.id_nfe}]|[{entity.chave_nfe}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_nfe"]}]|[{dictionaryFields["chave_nfe"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
