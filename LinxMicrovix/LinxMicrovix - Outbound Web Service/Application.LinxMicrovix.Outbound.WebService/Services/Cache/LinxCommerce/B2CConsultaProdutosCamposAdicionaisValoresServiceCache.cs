using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisValoresServiceCache : CacheService<B2CConsultaProdutosCamposAdicionaisValores>, ICacheService<B2CConsultaProdutosCamposAdicionaisValores>, IB2CConsultaProdutosCamposAdicionaisValoresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCamposAdicionaisValores entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
