using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosPalavrasChavePesquisaServiceCache : CacheService<B2CConsultaProdutosPalavrasChavePesquisa>, ICacheService<B2CConsultaProdutosPalavrasChavePesquisa>, IB2CConsultaProdutosPalavrasChavePesquisaServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosPalavrasChavePesquisa entity)
        {
            throw new NotImplementedException();
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            throw new NotImplementedException();
        }
    }
}
