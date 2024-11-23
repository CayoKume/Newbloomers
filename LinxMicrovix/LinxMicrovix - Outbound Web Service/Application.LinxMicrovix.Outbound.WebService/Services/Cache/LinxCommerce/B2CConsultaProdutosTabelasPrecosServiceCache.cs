using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Application.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosTabelasPrecosServiceCache : CacheService<B2CConsultaProdutosTabelasPrecos>, ICacheService<B2CConsultaProdutosTabelasPrecos>, IB2CConsultaProdutosTabelasPrecosServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosTabelasPrecos entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
