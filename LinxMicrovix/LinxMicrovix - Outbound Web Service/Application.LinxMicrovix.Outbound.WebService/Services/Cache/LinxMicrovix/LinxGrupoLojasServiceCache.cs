using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxGrupoLojasServiceCache : CacheService<LinxGrupoLojas>, ICacheService<LinxGrupoLojas>, ILinxGrupoLojasServiceCache, ICacheBase
    {
        public override string GetKey(LinxGrupoLojas entity)
        {
            return $"[{entity.empresa}]|[{entity.cnpj}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["empresa"]}]|[{dictionaryFields["CNPJ"]}]";
        }
    }
}
