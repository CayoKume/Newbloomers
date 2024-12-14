using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Services;
using Application.IntegrationsCore.Interfaces;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaProdutosCamposAdicionaisDetalhesServiceCache : CacheService<B2CConsultaProdutosCamposAdicionaisDetalhes>, ICacheService<B2CConsultaProdutosCamposAdicionaisDetalhes>, IB2CConsultaProdutosCamposAdicionaisDetalhesServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaProdutosCamposAdicionaisDetalhes entity)
        {
            return $"[{entity.id_campo_detalhe}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["id_campo_detalhe"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
