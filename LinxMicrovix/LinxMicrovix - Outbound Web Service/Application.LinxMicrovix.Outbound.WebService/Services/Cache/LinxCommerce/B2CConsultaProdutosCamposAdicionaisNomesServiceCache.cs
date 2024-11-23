using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisNomesServiceCache : CacheService<B2CConsultaProdutosCamposAdicionaisNomes>, ICacheService<B2CConsultaProdutosCamposAdicionaisNomes>, IB2CConsultaProdutosCamposAdicionaisNomesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCamposAdicionaisNomes entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
