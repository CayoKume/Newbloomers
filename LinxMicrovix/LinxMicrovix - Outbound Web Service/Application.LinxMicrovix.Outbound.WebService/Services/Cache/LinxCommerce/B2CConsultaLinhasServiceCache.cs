using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaLinhasServiceCache : CacheService<B2CConsultaLinhas>, ICacheService<B2CConsultaLinhas>, IB2CConsultaLinhasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaLinhas entity)
        {
            return $"[{entity.codigo_linha}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_linha"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
