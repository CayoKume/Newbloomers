namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAcoesPromocionais
    {
        public string? codigo_acao_promocional { get; set; }
        public string? nome_acao_promocional { get; set; }
        public string? vigencia_inicio { get; set; }
        public string? vigencia_fim { get; set; }
        public string? observacao { get; set; }
        public string? ativo { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxAcoesPromocionais() { }

        public LinxAcoesPromocionais(string? codigo_acao_promocional, string? nome_acao_promocional, string? vigencia_inicio, string? vigencia_fim, string? observacao, string? ativo, string? timestamp, string? portal)
        {
            this.codigo_acao_promocional = codigo_acao_promocional;
            this.nome_acao_promocional = nome_acao_promocional;
            this.vigencia_inicio = vigencia_inicio;
            this.vigencia_fim = vigencia_fim;
            this.observacao = observacao;
            this.ativo = ativo;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}