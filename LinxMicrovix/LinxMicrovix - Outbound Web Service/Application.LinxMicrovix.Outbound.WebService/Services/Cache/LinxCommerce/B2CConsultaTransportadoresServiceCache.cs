using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaTransportadoresServiceCache : CacheService<B2CConsultaTransportadores>, ICacheService<B2CConsultaTransportadores>, IB2CConsultaTransportadoresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaTransportadores entity)
        {
            return $"[{entity.cod_transportador}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_transportador"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
