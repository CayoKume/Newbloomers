namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoAcoesPromocionais
    {
        public string? id_movimento_acao_promocional { get; set; }
        public string? id_movimento { get; set; }
        public string? codigo_acao_promocional { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoAcoesPromocionais() { }

        public LinxMovimentoAcoesPromocionais(string? id_movimento_acao_promocional, string? id_movimento, string? codigo_acao_promocional, string? timestamp, string? portal)
        {
            this.id_movimento_acao_promocional = id_movimento_acao_promocional;
            this.id_movimento = id_movimento;
            this.codigo_acao_promocional = codigo_acao_promocional;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}