using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesContatosParentescoServiceCache : CacheService<B2CConsultaClientesContatosParentesco>, ICacheService<B2CConsultaClientesContatosParentesco>, IB2CConsultaClientesContatosParentescoServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesContatosParentesco entity)
        {
            return $"[{entity.id_parentesco}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_parentesco"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
