using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaEmpresasServiceCache : CacheService<B2CConsultaEmpresas>, ICacheService<B2CConsultaEmpresas>, IB2CConsultaEmpresasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaEmpresas entity)
        {
            return $"[{entity.empresa}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["empresa"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
