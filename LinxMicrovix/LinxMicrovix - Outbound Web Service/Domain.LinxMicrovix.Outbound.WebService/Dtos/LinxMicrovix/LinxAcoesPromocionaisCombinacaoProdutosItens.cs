namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAcoesPromocionaisCombinacaoProdutosItens
    {
        public string? id_acoes_promocionais_combinacao_produtos_itens { get; set; }
        public string? id_combinacao_produto { get; set; }
        public string? codigoproduto { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }

        public LinxAcoesPromocionaisCombinacaoProdutosItens()
        {
        }

        public LinxAcoesPromocionaisCombinacaoProdutosItens(string? id_acoes_promocionais_combinacao_produtos_itens, string? id_combinacao_produto, string? codigoproduto, string? portal, string? timestamp)
        {
            this.id_acoes_promocionais_combinacao_produtos_itens = id_acoes_promocionais_combinacao_produtos_itens;
            this.id_combinacao_produto = id_combinacao_produto;
            this.codigoproduto = codigoproduto;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}
