namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesia
    {
        public string? id_acoes_promocionais_produtos_cortesia { get; set; }
        public string? id_acoes_promocionais { get; set; }
        public string? codigoproduto { get; set; }
        public string? id_combinacao_produto { get; set; }
        public string? portal { get; set; }
        public string? timestamp { get; set; }

        public LinxAcoesPromocionaisProdutosCortesia()
        {
        }

        public LinxAcoesPromocionaisProdutosCortesia(string? id_acoes_promocionais_produtos_cortesia, string? id_acoes_promocionais, string? codigoproduto, string? id_combinacao_produto, string? portal, string? timestamp)
        {
            this.id_acoes_promocionais_produtos_cortesia = id_acoes_promocionais_produtos_cortesia;
            this.id_acoes_promocionais = id_acoes_promocionais;
            this.codigoproduto = codigoproduto;
            this.id_combinacao_produto = id_combinacao_produto;
            this.portal = portal;
            this.timestamp = timestamp;
        }
    }
}
