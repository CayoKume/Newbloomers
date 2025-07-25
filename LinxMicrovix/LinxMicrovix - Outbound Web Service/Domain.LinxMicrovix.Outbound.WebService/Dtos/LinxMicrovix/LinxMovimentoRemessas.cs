namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessas
    {
        public string? id_movimento_remessa { get; set; }
        public string? id_movimento { get; set; }
        public string? id_remessa { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoRemessas()
        {
        }

        public LinxMovimentoRemessas(
            string? id_movimento_remessa,
            string? id_movimento,
            string? id_remessa,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_remessa = id_movimento_remessa;
            this.id_movimento = id_movimento;
            this.id_remessa = id_remessa;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}