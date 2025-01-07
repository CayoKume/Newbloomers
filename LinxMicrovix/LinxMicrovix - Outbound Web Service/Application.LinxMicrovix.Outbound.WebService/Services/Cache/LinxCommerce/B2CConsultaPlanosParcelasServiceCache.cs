using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPlanosParcelasServiceCache : CacheService<B2CConsultaPlanosParcelas>, ICacheService<B2CConsultaPlanosParcelas>, IB2CConsultaPlanosParcelasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPlanosParcelas entity)
        {
            return $"[{entity.id_planos_parcelas}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_planos_parcelas"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
