using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosServiceCache : CacheService<B2CConsultaPedidos>, ICacheService<B2CConsultaPedidos>, IB2CConsultaPedidosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidos entity)
        {
            return $"[{entity.id_pedido}]|[{entity.cod_cliente_b2c}]|[{entity.cod_cliente_erp}]||[{entity.order_id}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido"]}]|[{dictionaryFields["cod_cliente_b2c"]}]|[{dictionaryFields["cod_cliente_erp"]}]|[{dictionaryFields["order_id"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
