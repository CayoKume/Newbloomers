using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxPedidosCompraServiceCache : CacheService<LinxPedidosCompra>, ICacheService<LinxPedidosCompra>, ILinxPedidosCompraServiceCache, ICacheBase
    {
        public override string GetKey(LinxPedidosCompra entity)
        {
            return $"[{entity.cod_pedido}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_pedido"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
