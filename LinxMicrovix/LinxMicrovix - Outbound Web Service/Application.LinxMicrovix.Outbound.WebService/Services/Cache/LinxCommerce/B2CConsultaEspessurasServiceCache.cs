using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaEspessurasServiceCache : CacheService<B2CConsultaEspessuras>, ICacheService<B2CConsultaEspessuras>, IB2CConsultaEspessurasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaEspessuras entity)
        {
            return $"[{entity.codigo_espessura}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_espessura"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
