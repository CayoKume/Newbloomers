using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosAssociadosServiceCache : CacheService<B2CConsultaProdutosAssociados>, ICacheService<B2CConsultaProdutosAssociados>, IB2CConsultaProdutosAssociadosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosAssociados entity)
        {
            return $"[{entity.id}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
