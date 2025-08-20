namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMovimentoCamposAdicionais
    {
        public string? id_ordservprod { get; set; }
        public string? transacao { get; set; }
        public string? paciente { get; set; }
        public string? codigo_gerencial { get; set; }
        public string? timestamp { get; set; }

        public LinxMovimentoCamposAdicionais()
        {
        }

        public LinxMovimentoCamposAdicionais(string? id_ordservprod, string? transacao, string? paciente, string? codigo_gerencial, string? timestamp)
        {
            this.id_ordservprod = id_ordservprod;
            this.transacao = transacao;
            this.paciente = paciente;
            this.codigo_gerencial = codigo_gerencial;
            this.timestamp = timestamp;
        }
    }
}
