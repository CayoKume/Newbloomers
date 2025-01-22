using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosStatusServiceCache : CacheService<B2CConsultaPedidosStatus>, ICacheService<B2CConsultaPedidosStatus>, IB2CConsultaPedidosStatusServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidosStatus entity)
        {
            return $"[{entity.id}]|[{entity.id_status}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id"]}]|[{dictionaryFields["id_status"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
