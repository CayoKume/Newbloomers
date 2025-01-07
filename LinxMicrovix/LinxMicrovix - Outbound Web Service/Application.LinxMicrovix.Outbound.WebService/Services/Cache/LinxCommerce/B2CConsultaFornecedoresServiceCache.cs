using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaFornecedoresServiceCache : CacheService<B2CConsultaFornecedores>, ICacheService<B2CConsultaFornecedores>, IB2CConsultaFornecedoresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaFornecedores entity)
        {
            return $"[{entity.cod_fornecedor}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_fornecedor"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
