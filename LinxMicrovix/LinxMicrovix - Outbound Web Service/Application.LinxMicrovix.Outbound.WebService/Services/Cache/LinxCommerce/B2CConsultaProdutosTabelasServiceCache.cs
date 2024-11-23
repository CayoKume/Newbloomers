using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosTabelasServiceCache : CacheService<B2CConsultaProdutosTabelas>, ICacheService<B2CConsultaProdutosTabelas>, IB2CConsultaProdutosTabelasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosTabelas entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
