using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesEnderecosEntregaServiceCache : CacheService<B2CConsultaClientesEnderecosEntrega>, ICacheService<B2CConsultaClientesEnderecosEntrega>, IB2CConsultaClientesEnderecosEntregaServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesEnderecosEntrega entity)
        {
            return $"[{entity.id_endereco_entrega}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_endereco_entrega"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
