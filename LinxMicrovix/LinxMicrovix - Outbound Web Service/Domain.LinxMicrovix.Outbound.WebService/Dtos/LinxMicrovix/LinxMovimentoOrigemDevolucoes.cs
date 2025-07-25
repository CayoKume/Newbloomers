namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoOrigemDevolucoes
    {
        public string? id_movimento_origem_devolucao { get; set; }
        public string? id_movimento { get; set; }
        public string? id_origem_devolucao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoOrigemDevolucoes()
        {
        }

        public LinxMovimentoOrigemDevolucoes(
            string? id_movimento_origem_devolucao,
            string? id_movimento,
            string? id_origem_devolucao,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_origem_devolucao = id_movimento_origem_devolucao;
            this.id_movimento = id_movimento;
            this.id_origem_devolucao = id_origem_devolucao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}