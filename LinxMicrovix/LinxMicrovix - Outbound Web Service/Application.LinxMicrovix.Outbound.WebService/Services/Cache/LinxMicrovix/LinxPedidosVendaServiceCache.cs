using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxPedidosVendaServiceCache : CacheService<LinxPedidosVenda>, ICacheService<LinxPedidosVenda>, ILinxPedidosVendaServiceCache, ICacheBase
    {
        public override string GetKey(LinxPedidosVenda entity)
        {
            return $"[{entity.cod_pedido}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_pedido"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
