using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxClientesFornecServiceCache : CacheService<LinxClientesFornec>, ICacheService<LinxClientesFornec>, ILinxClientesFornecServiceCache, ICacheBase
    {
        public override string GetKey(LinxClientesFornec entity)
        {
            return $"[{entity.cod_cliente}]|[{entity.doc_cliente}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_cliente"]}]|[{dictionaryFields["doc_cliente"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
