using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosDetalhesServiceCache : CacheService<B2CConsultaProdutosDetalhes>, ICacheService<B2CConsultaProdutosDetalhes>, IB2CConsultaProdutosDetalhesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosDetalhes entity)
        {
            return $"[{entity.id_prod_det}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_prod_det"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
