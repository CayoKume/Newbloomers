using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxB2CStatusServiceCache : CacheService<LinxB2CStatus>, ICacheService<LinxB2CStatus>, ILinxB2CStatusServiceCache, ICacheBase
    {
        public override string GetKey(LinxB2CStatus entity)
        {
            return $"[{entity.id_status}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_status"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
