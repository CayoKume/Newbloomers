namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoCartoes
    {
        public string? id_movimento_cartao { get; set; }
        public string? id_movimento { get; set; }
        public string? id_cartao { get; set; }
        public string? valor_cartao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoCartoes() { }

        public LinxMovimentoCartoes(string? id_movimento_cartao, string? id_movimento, string? id_cartao, string? valor_cartao, string? timestamp, string? portal)
        {
            this.id_movimento_cartao = id_movimento_cartao;
            this.id_movimento = id_movimento;
            this.id_cartao = id_cartao;
            this.valor_cartao = valor_cartao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}