using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosDimensoesServiceCache : CacheService<B2CConsultaProdutosDimensoes>, ICacheService<B2CConsultaProdutosDimensoes>, IB2CConsultaProdutosDimensoesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosDimensoes entity)
        {
            return $"[{entity.codigoproduto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigoproduto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
