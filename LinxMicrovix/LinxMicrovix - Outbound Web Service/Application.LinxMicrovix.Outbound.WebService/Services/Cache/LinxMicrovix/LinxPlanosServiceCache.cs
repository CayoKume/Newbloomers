using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxPlanosServiceCache : CacheService<LinxPlanos>, ICacheService<LinxPlanos>, ILinxPlanosServiceCache, ICacheBase
    {
        public override string GetKey(LinxPlanos entity)
        {
            return $"[{entity.plano}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["plano"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
