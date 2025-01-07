using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaClientesContatosServiceCache : CacheService<B2CConsultaClientesContatos>, ICacheService<B2CConsultaClientesContatos>, IB2CConsultaClientesContatosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaClientesContatos entity)
        {
            return $"[{entity.id_clientes_contatos}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_clientes_contatos"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
