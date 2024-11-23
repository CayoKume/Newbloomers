using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesServiceCache : CacheService<B2CConsultaClientes>, ICacheService<B2CConsultaClientes>, IB2CConsultaClientesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientes entity)
        {
            return $"[{entity.doc_cliente}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["doc_cliente"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
