using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaCodigoRastreioServiceCache : CacheService<B2CConsultaCodigoRastreio>, ICacheService<B2CConsultaCodigoRastreio>, IB2CConsultaCodigoRastreioServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaCodigoRastreio entity)
        {
            return $"[{entity.id_pedido}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
