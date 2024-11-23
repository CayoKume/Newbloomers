using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosPromocaoServiceCache : CacheService<B2CConsultaProdutosPromocao>, ICacheService<B2CConsultaProdutosPromocao>, IB2CConsultaProdutosPromocaoServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosPromocao entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
