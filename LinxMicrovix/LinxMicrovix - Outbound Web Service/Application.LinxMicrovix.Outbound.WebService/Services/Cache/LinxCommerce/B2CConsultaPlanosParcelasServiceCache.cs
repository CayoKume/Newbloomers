using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPlanosParcelasServiceCache : CacheService<B2CConsultaPlanosParcelas>, ICacheService<B2CConsultaPlanosParcelas>, IB2CConsultaPlanosParcelasServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPlanosParcelas entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
