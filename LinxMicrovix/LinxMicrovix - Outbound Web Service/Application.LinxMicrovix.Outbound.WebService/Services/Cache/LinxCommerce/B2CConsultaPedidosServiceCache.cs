using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosServiceCache : CacheService<B2CConsultaPedidos>, ICacheService<B2CConsultaPedidos>, IB2CConsultaPedidosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidos entity)
        {
            return $"[{entity.id_pedido}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
