namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxAntecipacoesFinanceiras
    {
        public string? id_antecipacao { get; set; }
        public string? empresa { get; set; }
        public string? data_antecipacao { get; set; }
        public string? valor_antecipado { get; set; }
        public string? taxa_antecipacao { get; set; }
        public string? valor_liquido { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxAntecipacoesFinanceiras() { }

        public LinxAntecipacoesFinanceiras(string? id_antecipacao, string? empresa, string? data_antecipacao, string? valor_antecipado, string? taxa_antecipacao, string? valor_liquido, string? timestamp, string? portal)
        {
            this.id_antecipacao = id_antecipacao;
            this.empresa = empresa;
            this.data_antecipacao = data_antecipacao;
            this.valor_antecipado = valor_antecipado;
            this.taxa_antecipacao = taxa_antecipacao;
            this.valor_liquido = valor_liquido;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}