namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoObservacoes
    {
        public string? id_movimento_observacao { get; set; }
        public string? id_movimento { get; set; }
        public string? observacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoObservacoes()
        {
        }

        public LinxMovimentoObservacoes(
            string? id_movimento_observacao,
            string? id_movimento,
            string? observacao,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_observacao = id_movimento_observacao;
            this.id_movimento = id_movimento;
            this.observacao = observacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}