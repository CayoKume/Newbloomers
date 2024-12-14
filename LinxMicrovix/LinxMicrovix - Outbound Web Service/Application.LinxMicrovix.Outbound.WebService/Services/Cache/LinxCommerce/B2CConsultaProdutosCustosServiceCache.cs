using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCustosServiceCache : CacheService<B2CConsultaProdutosCustos>, ICacheService<B2CConsultaProdutosCustos>, IB2CConsultaProdutosCustosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCustos entity)
        {
            return $"[{entity.id_produtos_custos}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_produtos_custos"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
