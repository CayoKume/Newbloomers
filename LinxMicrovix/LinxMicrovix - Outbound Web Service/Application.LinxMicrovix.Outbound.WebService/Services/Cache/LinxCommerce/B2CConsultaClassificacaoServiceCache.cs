using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClassificacaoServiceCache : CacheService<B2CConsultaClassificacao>, ICacheService<B2CConsultaClassificacao>, IB2CConsultaClassificacaoServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClassificacao entity)
        {
            return $"[{entity.codigo_classificacao}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_classificacao"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}