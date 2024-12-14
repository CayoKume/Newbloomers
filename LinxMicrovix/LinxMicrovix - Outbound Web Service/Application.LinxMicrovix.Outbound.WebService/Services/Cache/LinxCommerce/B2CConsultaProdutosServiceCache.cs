using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosServiceCache : CacheService<B2CConsultaProdutos>, ICacheService<B2CConsultaProdutos>, IB2CConsultaProdutosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutos entity)
        {
            return $"[{entity.codigoproduto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigoproduto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
