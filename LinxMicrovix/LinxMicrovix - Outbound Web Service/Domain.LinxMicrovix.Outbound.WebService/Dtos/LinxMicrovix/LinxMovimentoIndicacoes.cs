namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoIndicacoes
    {
        public string? identificador { get; private set; }
        public string? cod_cliente { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoIndicacoes() { }

        public LinxMovimentoIndicacoes(
            string? identificador,
            string? cod_cliente,
            string? timestamp
        )
        {
            this.identificador = this.identificador;
            this.cod_cliente =this.cod_cliente;
            this.timestamp = this.timestamp;
        }
    }
}