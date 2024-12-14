using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosFlagsServiceCache : CacheService<B2CConsultaProdutosFlags>, ICacheService<B2CConsultaProdutosFlags>, IB2CConsultaProdutosFlagsServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosFlags entity)
        {
            return $"[{entity.id_b2c_flags_produtos}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_b2c_flags_produtos"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
