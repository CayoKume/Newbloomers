using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaImagensServiceCache : CacheService<B2CConsultaImagens>, ICacheService<B2CConsultaImagens>, IB2CConsultaImagensServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaImagens entity)
        {
            return $"[{entity.id_imagem}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_imagem"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
