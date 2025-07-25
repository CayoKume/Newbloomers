namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExterna
    {
        public string? id_movimento_ordem_servico_externa { get; set; }
        public string? id_movimento { get; set; }
        public string? id_ordem_servico_externa { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxMovimentoOrdemServicoExterna()
        {
        }

        public LinxMovimentoOrdemServicoExterna(
            string? id_movimento_ordem_servico_externa,
            string? id_movimento,
            string? id_ordem_servico_externa,
            string? timestamp,
            string? portal)
        {
            this.id_movimento_ordem_servico_externa = id_movimento_ordem_servico_externa;
            this.id_movimento = id_movimento;
            this.id_ordem_servico_externa = id_ordem_servico_externa;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}