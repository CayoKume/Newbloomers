using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosImagensServiceCache : CacheService<B2CConsultaProdutosImagens>, ICacheService<B2CConsultaProdutosImagens>, IB2CConsultaProdutosImagensServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosImagens entity)
        {
            return $"[{entity.id_imagem_produto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_imagem_produto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
