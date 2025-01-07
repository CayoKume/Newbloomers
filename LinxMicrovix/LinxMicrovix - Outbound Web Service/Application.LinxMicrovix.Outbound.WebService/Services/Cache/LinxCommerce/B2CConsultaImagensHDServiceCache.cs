using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaImagensHDServiceCache : CacheService<B2CConsultaImagensHD>, ICacheService<B2CConsultaImagensHD>, IB2CConsultaImagensHDServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaImagensHD entity)
        {
            return $"[{entity.identificador_imagem}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["identificador_imagem"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
