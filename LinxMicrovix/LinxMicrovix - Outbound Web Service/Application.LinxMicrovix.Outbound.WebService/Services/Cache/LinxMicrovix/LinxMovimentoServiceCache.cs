using Application.IntegrationsCore.Interfaces;
using Application.IntegrationsCore.Services;
using Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Application.LinxMicrovix.Outbound.WebService.Services.Cache.LinxMicrovix
{
    public class LinxMovimentoServiceCache : CacheService<LinxMovimento>, ICacheService<LinxMovimento>, ILinxMovimentoServiceCache, ICacheBase
    {
        public override string GetKey(LinxMovimento entity)
        {
            return $"[{entity.cnpj_emp}]|[{entity.documento}]|[{entity.chave_nf}]|[{entity.data_documento}]|[{entity.codigo_cliente}]|[{entity.cod_produto}]|[{entity.cancelado}]|[{entity.excluido}]|[{entity.transacao_pedido_venda}]|[{entity.ordem}]|[{entity.timestamp}]";
        }

        public override string GetKeyInDictionary(IDictionary<string, string> dictionaryFields)
        {
            return $"[{dictionaryFields["cnpj_emp"]}]|[{dictionaryFields["documento"]}]|[{dictionaryFields["chave_nf"]}]|[{dictionaryFields["data_documento"]}]|[{dictionaryFields["codigo_cliente"]}]|[{dictionaryFields["cod_produto"]}]|[{dictionaryFields["cancelado"]}]|[{dictionaryFields["excluido"]}]|[{dictionaryFields["transacao_pedido_venda"]}]|[{dictionaryFields["ordem"]}]|[{dictionaryFields["timestamp"]}]";
        }
    }
}
