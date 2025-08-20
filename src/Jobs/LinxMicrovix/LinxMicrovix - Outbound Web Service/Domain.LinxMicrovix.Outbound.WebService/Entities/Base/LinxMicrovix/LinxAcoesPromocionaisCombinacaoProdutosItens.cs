namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxAcoesPromocionaisCombinacaoProdutosItens
    {
        public string? id_acoes_promocionais_combinacao_produtos_itens { get; set; }
        public string? id_combinacao_produto { get; set; }
        public string? codigoproduto { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }
    }
}
