using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaGrade2ServiceCache : CacheService<B2CConsultaGrade2>, ICacheService<B2CConsultaGrade2>, IB2CConsultaGrade2ServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaGrade2 entity)
        {
            return $"[{entity.codigo_grade2}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["codigo_grade2"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
