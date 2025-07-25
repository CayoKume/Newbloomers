namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoExtensao
    {
        public string? id_movimento_extensao { get; set; }
        public string? id_movimento { get; set; }
        public string? campo_extensao { get; set; }
        public string? valor_extensao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoExtensao() { }

        public LinxMovimentoExtensao(
        string? id_movimento_extensao,
        string? id_movimento,
        string? campo_extensao,
        string? valor_extensao,
        string? timestamp,
        string? portal)
        {
            this.id_movimento_extensao = id_movimento_extensao;
            this.id_movimento = id_movimento;
            this.campo_extensao = campo_extensao;
            this.valor_extensao = valor_extensao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}