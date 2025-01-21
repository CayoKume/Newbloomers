using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxLojasServiceCache : CacheService<LinxLojas>, ICacheService<LinxLojas>, ILinxLojasServiceCache, ICacheBase
    {
        public override string GetKey(LinxLojas entity)
        {
            return $"[{entity.empresa}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["empresa"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
