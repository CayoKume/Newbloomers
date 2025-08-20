

namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoObservacaoCF
    {
        public string? identificador { get; private set; }
        public string? documento_cliente { get; private set; }
        public string? timestamp { get; private set; }

        public LinxMovimentoObservacaoCF() { }

        public LinxMovimentoObservacaoCF(
            string? identificador,
            string? documento_cliente,
            string? timestamp
        )
        {
            this.identificador = this.identificador;
            this.documento_cliente = this.documento_cliente;
            this.timestamp = this.timestamp;
        }
    }
}