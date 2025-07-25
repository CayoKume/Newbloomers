namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesia
    {
        public string? codigo_acao_promocional { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxAcoesPromocionaisProdutosCortesia() { }

        public LinxAcoesPromocionaisProdutosCortesia(string? codigo_acao_promocional, string? codigoproduto, string? quantidade, string? timestamp, string? portal)
        {
            this.codigo_acao_promocional = codigo_acao_promocional;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}