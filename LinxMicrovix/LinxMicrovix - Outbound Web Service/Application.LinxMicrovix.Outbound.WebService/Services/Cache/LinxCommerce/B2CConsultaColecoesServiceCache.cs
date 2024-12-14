using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaColecoesServiceCache : CacheService<B2CConsultaColecoes>, ICacheService<B2CConsultaColecoes>, IB2CConsultaColecoesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaColecoes entity)
        {
            return $"[{entity.codigo_colecao}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_colecao"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
