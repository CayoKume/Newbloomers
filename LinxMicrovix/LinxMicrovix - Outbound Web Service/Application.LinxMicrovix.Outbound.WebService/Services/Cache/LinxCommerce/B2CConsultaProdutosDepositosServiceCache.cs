using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosDepositosServiceCache : CacheService<B2CConsultaProdutosDepositos>, ICacheService<B2CConsultaProdutosDepositos>, IB2CConsultaProdutosDepositosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosDepositos entity)
        {
            return $"[{entity.id_deposito}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_deposito"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
