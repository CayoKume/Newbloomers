using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxMovimentoPlanosServiceCache : CacheService<LinxMovimentoPlanos>, ICacheService<LinxMovimentoPlanos>, ILinxMovimentoPlanosServiceCache, ICacheBase
    {
        public override string GetKey(LinxMovimentoPlanos entity)
        {
            return $"[{entity.cnpj_emp}]|[{entity.identificador}]|[{entity.plano}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["identificador"]}]|[{dictionaryFields["plano"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
