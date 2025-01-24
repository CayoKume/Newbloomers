using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    internal class LinxSetoresServiceCache : CacheService<LinxSetores>, ICacheService<LinxSetores>, ILinxSetoresServiceCache, ICacheBase
    {
        public override string GetKey(LinxSetores entity)
        {
            return $"[{entity.id_setor}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_setor"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
