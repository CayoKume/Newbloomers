using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresServiceCache : CacheService<B2CConsultaLegendasCadastrosAuxiliares>, ICacheService<B2CConsultaLegendasCadastrosAuxiliares>, IB2CConsultaLegendasCadastrosAuxiliaresServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaLegendasCadastrosAuxiliares entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
