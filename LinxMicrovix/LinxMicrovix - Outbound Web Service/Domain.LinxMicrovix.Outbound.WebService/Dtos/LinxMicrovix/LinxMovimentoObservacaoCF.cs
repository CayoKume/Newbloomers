namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoObservacaoCF
    {
        public string? id_movimento_observacao_cf { get; set; }
        public string? id_movimento { get; set; }
        public string? observacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoObservacaoCF()
        {
        }

        public LinxMovimentoObservacaoCF(
            string? id_movimento_observacao_cf,
            string? id_movimento,
            string? observacao,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_observacao_cf = id_movimento_observacao_cf;
            this.id_movimento = id_movimento;
            this.observacao = observacao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}