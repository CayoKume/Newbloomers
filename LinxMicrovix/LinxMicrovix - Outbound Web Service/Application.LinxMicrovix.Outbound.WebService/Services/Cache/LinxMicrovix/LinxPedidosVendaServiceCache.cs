using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using static Dapper.SqlMapper;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxPedidosVendaServiceCache : CacheService<LinxPedidosVenda>, ICacheService<LinxPedidosVenda>, ILinxPedidosVendaServiceCache, ICacheBase
    {
        public override string GetKey(LinxPedidosVenda entity)
        {
            return $"[{entity.cod_pedido}]|[{entity.cnpj_emp}]|[{entity.cod_produto}]|[{entity.codigo_cliente}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_pedido"]}]|[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["codigo_cliente"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
