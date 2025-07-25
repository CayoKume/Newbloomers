namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAntecipacoesFinanceirasPlanos
    {
        public string? id_antecipacao { get; set; }
        public string? id_plano { get; set; }
        public string? valor_plano { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxAntecipacoesFinanceirasPlanos() { }

        public LinxAntecipacoesFinanceirasPlanos(string? id_antecipacao, string? id_plano, string? valor_plano, string? timestamp, string? portal)
        {
            this.id_antecipacao = id_antecipacao;
            this.id_plano = id_plano;
            this.valor_plano = valor_plano;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}