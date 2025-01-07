using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosTiposServiceCache : CacheService<B2CConsultaPedidosTipos>, ICacheService<B2CConsultaPedidosTipos>, IB2CConsultaPedidosTiposServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidosTipos entity)
        {
            return $"[{entity.id_tipo_b2c}]|[{entity.pos_timestamp_old}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_tipo_b2c"]}]|[{dictionaryFields["pos_timestamp_old"]}]";
        }
    }
}
