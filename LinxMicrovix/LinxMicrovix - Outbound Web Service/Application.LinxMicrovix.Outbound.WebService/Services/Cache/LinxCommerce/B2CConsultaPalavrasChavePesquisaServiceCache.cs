using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaPalavrasChavePesquisaServiceCache : CacheService<B2CConsultaPalavrasChavePesquisa>, ICacheService<B2CConsultaPalavrasChavePesquisa>, IB2CConsultaPalavrasChavePesquisaServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaPalavrasChavePesquisa entity)
        {
            return $"[{entity.id_b2c_palavras_chave_pesquisa}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_b2c_palavras_chave_pesquisa"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
