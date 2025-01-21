using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxXMLDocumentosServiceCache : CacheService<LinxXMLDocumentos>, ICacheService<LinxXMLDocumentos>, ILinxXMLDocumentosServiceCache, ICacheBase
    {
        public override string GetKey(LinxXMLDocumentos entity)
        {
            return $"[{entity.chave_nfe}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["chave_nfe"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
