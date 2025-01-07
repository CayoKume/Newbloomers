using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaTipoEncomendaServiceCache : CacheService<B2CConsultaTipoEncomenda>, ICacheService<B2CConsultaTipoEncomenda>, IB2CConsultaTipoEncomendaServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaTipoEncomenda entity)
        {
            return $"[{entity.id_tipo_encomenda}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_tipo_encomenda"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
