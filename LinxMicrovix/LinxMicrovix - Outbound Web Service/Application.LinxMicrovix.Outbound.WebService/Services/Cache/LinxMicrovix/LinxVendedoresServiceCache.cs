using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxVendedoresServiceCache : CacheService<LinxVendedores>, ICacheService<LinxVendedores>, ILinxVendedoresServiceCache, ICacheBase
    {
        public override string GetKey(LinxVendedores entity)
        {
            return $"[{entity.cod_vendedor}]|[{entity.cpf_vendedor}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_vendedor"]}]|[{dictionaryFields["cpf_vendedor"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
