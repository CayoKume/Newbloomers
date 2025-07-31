namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxMovimentoOrdemServicoExterna
    {
        public string? id_movimento_ordem_servico_externa { get; set; }
        public string? identificador { get; set; }
        public string? codigo_ordem_servico { get; set; }
        public string? timestamp { get; set; }
    }
}
