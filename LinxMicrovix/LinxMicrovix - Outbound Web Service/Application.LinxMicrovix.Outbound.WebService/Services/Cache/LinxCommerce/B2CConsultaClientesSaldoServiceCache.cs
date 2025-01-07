using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesSaldoServiceCache : CacheService<B2CConsultaClientesSaldo>, ICacheService<B2CConsultaClientesSaldo>, IB2CConsultaClientesSaldoServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesSaldo entity)
        {
            return $"[{entity.cod_cliente_erp}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_cliente_erp"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
