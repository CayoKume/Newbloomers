using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxB2CPedidosItensServiceCache : CacheService<LinxB2CPedidosItens>, ICacheService<LinxB2CPedidosItens>, ILinxB2CPedidosItensServiceCache, ICacheBase
    {
        public override string GetKey(LinxB2CPedidosItens entity)
        {
            return $"[{entity.id_pedido_item}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido_item"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
