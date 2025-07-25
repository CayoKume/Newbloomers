namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoPlanos
    {
        public string? id_movimento_plano { get; set; }
        public string? id_movimento { get; set; }
        public string? id_plano { get; set; }
        public string? valor_plano { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoPlanos()
        {
        }

        public LinxMovimentoPlanos(
            string? id_movimento_plano,
            string? id_movimento,
            string? id_plano,
            string? valor_plano,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_plano = id_movimento_plano;
            this.id_movimento = id_movimento;
            this.id_plano = id_plano;
            this.valor_plano = valor_plano;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}