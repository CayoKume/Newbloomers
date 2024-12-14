using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosTagsServiceCache : CacheService<B2CConsultaProdutosTags>, ICacheService<B2CConsultaProdutosTags>, IB2CConsultaProdutosTagsServiceCache
    {
        public override string GetKey(B2CConsultaProdutosTags entity)
        {
            return $"[{entity.id_b2c_tags_produtos}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_b2c_tags_produtos"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
