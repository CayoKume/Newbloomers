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
            return $"[{entity.cnpj_emp}]|[{entity.cod_pedido}]|[{entity.codigo_fornecedor}]|[{entity.cod_produto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["cod_pedido"]}]|[{dictionaryFields["codigo_fornecedor"]}]|[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
