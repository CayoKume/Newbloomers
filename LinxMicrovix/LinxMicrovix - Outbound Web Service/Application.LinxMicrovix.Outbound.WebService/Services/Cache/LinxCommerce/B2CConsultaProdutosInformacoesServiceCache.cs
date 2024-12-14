using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesServiceCache : CacheService<B2CConsultaProdutosInformacoes>, ICacheService<B2CConsultaProdutosInformacoes>, IB2CConsultaProdutosInformacoesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosInformacoes entity)
        {
            return $"[{entity.id_produtos_informacoes}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_produtos_informacoes"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
