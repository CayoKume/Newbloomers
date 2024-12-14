using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCodebarServiceCache : CacheService<B2CConsultaProdutosCodebar>, ICacheService<B2CConsultaProdutosCodebar>, IB2CConsultaProdutosCodebarServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCodebar entity)
        {
            return $"[{entity.id_produtos_codebar}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_produtos_codebar"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
