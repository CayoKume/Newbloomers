using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosIdentificadorServiceCache : CacheService<B2CConsultaPedidosIdentificador>, ICacheService<B2CConsultaPedidosIdentificador>, IB2CConsultaPedidosIdentificadorServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidosIdentificador entity)
        {
            return $"[{entity.id_venda}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_venda"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
