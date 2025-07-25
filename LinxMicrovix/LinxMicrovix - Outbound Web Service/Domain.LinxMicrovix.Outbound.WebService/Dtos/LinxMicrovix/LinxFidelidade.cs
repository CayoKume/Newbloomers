namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFidelidade
    {
        public string? id_fidelidade { get; set; }
        public string? cod_cliente_fornec { get; set; }
        public string? pontos_acumulados { get; set; }
        public string? pontos_utilizados { get; set; }
        public string? pontos_disponiveis { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxFidelidade() { }

        public LinxFidelidade(string? id_fidelidade, string? cod_cliente_fornec, string? pontos_acumulados, string? pontos_utilizados, string? pontos_disponiveis, string? timestamp, string? portal)
        {
            this.id_fidelidade = id_fidelidade;
            this.cod_cliente_fornec = cod_cliente_fornec;
            this.pontos_acumulados = pontos_acumulados;
            this.pontos_utilizados = pontos_utilizados;
            this.pontos_disponiveis = pontos_disponiveis;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}