using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxMovimentoServiceCache : CacheService<LinxMovimento>, ICacheService<LinxMovimento>, ILinxMovimentoServiceCache, ICacheBase
    {
        public override string GetKey(LinxMovimento entity)
        {
            return $"[{entity.documento}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["documento"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
