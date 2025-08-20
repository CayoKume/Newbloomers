using Domain.LinxMicrovix.Outbound.WebService.CustomValidations;

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoOrdemServicoExterna
    {
        public string? id_movimento_ordem_servico_externa { get; private set; }
        public string? identificador { get; private set; }
        public string? codigo_ordem_servico { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoOrdemServicoExterna() { }

        public LinxMovimentoOrdemServicoExterna(
            string? id_movimento_ordem_servico_externa,
            string? identificador,
            string? codigo_ordem_servico,
            string? timestamp
        )
        {
            this.id_movimento_ordem_servico_externa = id_movimento_ordem_servico_externa;
            this.identificador = identificador;
            this.codigo_ordem_servico = codigo_ordem_servico;
            this.timestamp = timestamp;
        }
    }
}