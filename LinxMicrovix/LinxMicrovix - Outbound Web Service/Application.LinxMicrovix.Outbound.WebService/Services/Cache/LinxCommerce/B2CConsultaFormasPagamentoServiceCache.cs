using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.LinxMicrovix.Outbound.WebService.Entities.Cache.LinxCommerce
{
    public class B2CConsultaFormasPagamentoServiceCache : CacheService<B2CConsultaFormasPagamento>, ICacheService<B2CConsultaFormasPagamento>, IB2CConsultaFormasPagamentoServiceCache, ICacheBase
    {
        public override string GetKey(B2CConsultaFormasPagamento entity)
        {
            return $"[{entity.cod_forma_pgto}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cod_forma_pgto"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
