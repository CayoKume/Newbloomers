namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoRemessasAcertos
    {
        public string? id_movimento_remessa_acerto { get; set; }
        public string? id_movimento { get; set; }
        public string? id_remessa_acerto { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoRemessasAcertos()
        {
        }

        public LinxMovimentoRemessasAcertos(
            string? id_movimento_remessa_acerto,
            string? id_movimento,
            string? id_remessa_acerto,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_remessa_acerto = id_movimento_remessa_acerto;
            this.id_movimento = id_movimento;
            this.id_remessa_acerto = id_remessa_acerto;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}