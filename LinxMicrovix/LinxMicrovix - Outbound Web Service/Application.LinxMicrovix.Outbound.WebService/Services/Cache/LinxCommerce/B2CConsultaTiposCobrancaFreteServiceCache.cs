using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteServiceCache : CacheService<B2CConsultaTiposCobrancaFrete>, ICacheService<B2CConsultaTiposCobrancaFrete>, IB2CConsultaTiposCobrancaFreteServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaTiposCobrancaFrete entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
