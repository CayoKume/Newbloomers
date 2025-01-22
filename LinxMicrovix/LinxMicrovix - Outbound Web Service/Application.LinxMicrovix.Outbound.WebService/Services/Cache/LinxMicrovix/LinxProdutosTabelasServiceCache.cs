using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxProdutosTabelasServiceCache : CacheService<LinxProdutosTabelas>, ICacheService<LinxProdutosTabelas>, ILinxProdutosTabelasServiceCache, ICacheBase
    {
        public override string GetKey(LinxProdutosTabelas entity)
        {
            return $"[{entity.cnpj_emp}]|[{entity.id_tabela}]|[{entity.tipo_tabela}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["id_tabela"]}]|[{dictionaryFields["tipo_tabela"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
