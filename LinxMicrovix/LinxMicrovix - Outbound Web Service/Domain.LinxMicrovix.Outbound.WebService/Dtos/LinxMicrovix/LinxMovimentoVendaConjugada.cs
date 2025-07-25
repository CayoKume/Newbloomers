namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoVendaConjugada
    {
        public string? identificador_produto { get; private set; }
        public string? identificador_servico { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoVendaConjugada() { }

        public LinxMovimentoVendaConjugada(
            string? identificador_produto,
            string? identificador_servico,
            string? timestamp
        )
        {
            this.identificador_produto = identificador_produto;
            this.identificador_servico = identificador_servico;
            this.timestamp = timestamp;
        }
    }
}