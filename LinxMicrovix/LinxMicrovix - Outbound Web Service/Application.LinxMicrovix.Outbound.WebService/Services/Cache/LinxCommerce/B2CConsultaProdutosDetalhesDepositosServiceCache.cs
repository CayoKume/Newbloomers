using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesDepositosServiceCache : CacheService<B2CConsultaProdutosDetalhesDepositos>, ICacheService<B2CConsultaProdutosDetalhesDepositos>, IB2CConsultaProdutosDetalhesDepositosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosDetalhesDepositos entity)
        {
            return $"[{entity.id_deposito}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_deposito"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
