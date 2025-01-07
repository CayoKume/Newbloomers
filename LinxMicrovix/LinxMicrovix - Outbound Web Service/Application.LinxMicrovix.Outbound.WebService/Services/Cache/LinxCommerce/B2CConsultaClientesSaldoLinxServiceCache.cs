using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesSaldoLinxServiceCache : CacheService<B2CConsultaClientesSaldoLinx>, ICacheService<B2CConsultaClientesSaldoLinx>, IB2CConsultaClientesSaldoLinxServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesSaldoLinx entity)
        {
            return $"[{entity.cod_cliente_b2c}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_cliente_b2c"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
