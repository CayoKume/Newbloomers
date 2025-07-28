namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxTrocaUnificadaResumoVendasItens
    {
        public string? id_troca_unificada_resumo_vendas_itens { get; set; }
        public string? id_troca_unificada_resumo_vendas { get; set; }
        public string? codigoproduto { get; set; }
        public string? transacao { get; set; }
        public string? serial { get; set; }
        public string? valor_liquido { get; set; }
        public string? data_validade { get; set; }
        public string? venda_referenciada { get; set; }
        public string? token_utilizado { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
    }
}
