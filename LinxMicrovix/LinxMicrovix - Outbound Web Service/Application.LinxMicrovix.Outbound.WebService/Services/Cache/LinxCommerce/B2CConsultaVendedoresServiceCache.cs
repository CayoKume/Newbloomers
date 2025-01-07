using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaVendedoresServiceCache : CacheService<B2CConsultaVendedores>, ICacheService<B2CConsultaVendedores>, IB2CConsultaVendedoresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaVendedores entity)
        {
            return $"[{entity.cod_vendedor}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_vendedor"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
