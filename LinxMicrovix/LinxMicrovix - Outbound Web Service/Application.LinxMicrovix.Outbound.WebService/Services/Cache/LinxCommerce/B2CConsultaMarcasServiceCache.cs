using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaMarcasServiceCache : CacheService<B2CConsultaMarcas>, ICacheService<B2CConsultaMarcas>, IB2CConsultaMarcasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaMarcas entity)
        {
            return $"[{entity.codigo_marca}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_marca"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
