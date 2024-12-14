using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaSetoresServiceCache : CacheService<B2CConsultaSetores>, ICacheService<B2CConsultaSetores>, IB2CConsultaSetoresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaSetores entity)
        {
            return $"[{entity.codigo_setor}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_setor"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
