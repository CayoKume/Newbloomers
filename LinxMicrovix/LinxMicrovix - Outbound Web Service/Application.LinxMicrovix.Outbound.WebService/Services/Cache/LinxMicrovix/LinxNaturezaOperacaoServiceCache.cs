using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxNaturezaOperacaoServiceCache : CacheService<LinxNaturezaOperacao>, ICacheService<LinxNaturezaOperacao>, ILinxNaturezaOperacaoServiceCache, ICacheBase
    {
        public override string GetKey(LinxNaturezaOperacao entity)
        {
            return $"[{entity.cod_natureza_operacao}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_natureza_operacao"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
