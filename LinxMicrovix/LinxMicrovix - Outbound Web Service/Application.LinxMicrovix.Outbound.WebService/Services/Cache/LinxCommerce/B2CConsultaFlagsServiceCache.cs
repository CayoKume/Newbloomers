using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaFlagsServiceCache : CacheService<B2CConsultaFlags>, ICacheService<B2CConsultaFlags>, IB2CConsultaFlagsServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaFlags entity)
        {
            return $"[{entity.id_b2c_flags}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_b2c_flags"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
