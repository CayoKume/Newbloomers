using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesEstadoCivilServiceCache : CacheService<B2CConsultaClientesEstadoCivil>, ICacheService<B2CConsultaClientesEstadoCivil>, IB2CConsultaClientesEstadoCivilServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesEstadoCivil entity)
        {
            return $"[{entity.id_estado_civil}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_estado_civil"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
