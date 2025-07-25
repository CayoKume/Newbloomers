namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLancContabil
    {
        public string? id_lanc_contabil { get; set; }
        public string? empresa { get; set; }
        public string? data_lancamento { get; set; }
        public string? valor_lancamento { get; set; }
        public string? tipo_lancamento { get; set; }
        public string? historico { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxLancContabil() { }

        public LinxLancContabil(string? id_lanc_contabil, string? empresa, string? data_lancamento, string? valor_lancamento,
                                string? tipo_lancamento, string? historico, string? timestamp, string? portal)
        {
            this.id_lanc_contabil = id_lanc_contabil;
            this.empresa = empresa;
            this.data_lancamento = data_lancamento;
            this.valor_lancamento = valor_lancamento;
            this.tipo_lancamento = tipo_lancamento;
            this.historico = historico;
            this.timestamp = timestamp;
            this.portal = portal;
        }

    }
}