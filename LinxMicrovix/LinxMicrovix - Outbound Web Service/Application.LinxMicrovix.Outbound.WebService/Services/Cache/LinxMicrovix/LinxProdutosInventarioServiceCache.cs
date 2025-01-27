using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxProdutosInventarioServiceCache : CacheService<LinxProdutosInventario>, ICacheService<LinxProdutosInventario>, ILinxProdutosInventarioServiceCache, ICacheBase
    {
        public override string GetKey(LinxProdutosInventario entity)
        {
            return $"[{entity.cnpj_emp}]|[{entity.cod_produto}]|[{entity.cod_deposito}]|[{entity.quantidade}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["cod_deposito"]}]|[{dictionaryFields["quantidade"]}]";
        }
    }
}
