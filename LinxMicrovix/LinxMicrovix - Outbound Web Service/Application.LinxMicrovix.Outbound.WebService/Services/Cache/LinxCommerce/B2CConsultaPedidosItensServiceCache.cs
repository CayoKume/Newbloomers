using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPedidosItensServiceCache : CacheService<B2CConsultaPedidosItens>, ICacheService<B2CConsultaPedidosItens>, IB2CConsultaPedidosItensServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPedidosItens entity)
        {
            return $"[{entity.id_pedido_item}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_pedido_item"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
