using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosPlanosServiceCache : CacheService<B2CConsultaPedidosPlanos>, ICacheService<B2CConsultaPedidosPlanos>, IB2CConsultaPedidosPlanosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidosPlanos entity)
        {
            return $"[{entity.id_pedido_planos}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido_planos"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
