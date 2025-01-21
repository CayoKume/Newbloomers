using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxB2CPedidosServiceCache : CacheService<LinxB2CPedidos>, ICacheService<LinxB2CPedidos>, ILinxB2CPedidosServiceCache, ICacheBase
    {
        public override string GetKey(LinxB2CPedidos entity)
        {
            return $"[{entity.id_pedido}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
