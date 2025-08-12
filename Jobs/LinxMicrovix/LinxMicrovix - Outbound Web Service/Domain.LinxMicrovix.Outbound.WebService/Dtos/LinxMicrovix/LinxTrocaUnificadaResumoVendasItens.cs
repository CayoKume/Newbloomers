

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasItens
    {
        public string? id_troca_unificada_resumo_vendas_itens { get; private set; }
        public string? id_troca_unificada_resumo_vendas { get; private set; }
        public string? codigoproduto { get; private set; }
        public string? transacao { get; private set; }
        public string? serial { get; private set; }
        public string? valor_liquido { get; private set; }
        public string? data_validade { get; private set; }
        public string? venda_referenciada { get; private set; }
        public string? token_utilizado { get; private set; }
        public string? quantidade { get; private set; }
        public string? timestamp { get; private set; }

        public LinxTrocaUnificadaResumoVendasItens() { }

        public LinxTrocaUnificadaResumoVendasItens(
            string? id_troca_unificada_resumo_vendas_itens,
            string? id_troca_unificada_resumo_vendas,
            string? codigoproduto,
            string? transacao,
            string? serial,
            string? valor_liquido,
            string? data_validade,
            string? venda_referenciada,
            string? token_utilizado,
            string? quantidade,
            string? timestamp
        )
        {
            this.id_troca_unificada_resumo_vendas_itens = id_troca_unificada_resumo_vendas_itens;
            this.id_troca_unificada_resumo_vendas = id_troca_unificada_resumo_vendas;
            this.codigoproduto = codigoproduto;
            this.transacao = transacao;
            this.serial = serial;
            this.valor_liquido = valor_liquido;
            this.data_validade = data_validade;
            this.venda_referenciada = venda_referenciada;
            this.token_utilizado = token_utilizado;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
        }
    }
}