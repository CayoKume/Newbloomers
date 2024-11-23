using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosStatusServiceCache : CacheService<B2CConsultaProdutosStatus>, ICacheService<B2CConsultaProdutosStatus>, IB2CConsultaProdutosStatusServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosStatus entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
