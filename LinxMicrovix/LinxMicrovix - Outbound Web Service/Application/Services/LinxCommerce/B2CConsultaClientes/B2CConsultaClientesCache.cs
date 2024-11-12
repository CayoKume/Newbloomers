using Bloomers.Core.Auditoria.Infrastructure.Cache;
using IntegrationsCore.Application.Services.Cache;
using LinxMicrovix_Outbound_Web_Service.Domain.Entites.LinxCommerce;

namespace LinxMicrovix_Outbound_Web_Service.Application.Services.LinxCommerce
{
    public class B2CConsultaClientesCache : CacheService<B2CConsultaClientes>, ICacheService<B2CConsultaClientes>, IB2CConsultaClientesCache, ICacheXmlUtilActions
    {
        public override string GetKey(B2CConsultaClientes entity)
        {
            return $"""[{entity.doc_cliente}]""-""[{entity.timestamp}]""";
        }
        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"""[{dictionaryFields["doc_cliente"]}]""-""[{dictionaryFields["timestamp"]}]""";
        }
    }
}
