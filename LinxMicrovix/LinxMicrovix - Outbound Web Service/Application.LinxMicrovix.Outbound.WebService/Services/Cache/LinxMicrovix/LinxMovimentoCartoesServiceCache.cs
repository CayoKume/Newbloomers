using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxMovimentoCartoesServiceCache : CacheService<LinxMovimentoCartoes>, ICacheService<LinxMovimentoCartoes>, ILinxMovimentoCartoesServiceCache, ICacheBase
    {
        public override string GetKey(LinxMovimentoCartoes entity)
        {
            return $"[{entity.identificador}]|[{entity.cnpj_emp}]|[{entity.cupomfiscal}]|[{entity.cod_autorizacao}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["identificador"]}]|[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["cupomfiscal"]}]|[{dictionaryFields["cod_autorizacao"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
