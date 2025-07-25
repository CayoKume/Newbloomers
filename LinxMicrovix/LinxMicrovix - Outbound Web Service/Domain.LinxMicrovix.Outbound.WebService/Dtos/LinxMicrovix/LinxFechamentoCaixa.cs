namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxFechamentoCaixa
    {
        public string? id_fechamento_caixa { get; set; }
        public string? empresa { get; set; }
        public string? data_fechamento { get; set; }
        public string? valor_total_vendas { get; set; }
        public string? valor_total_recebimentos { get; set; }
        public string? valor_total_sangrias { get; set; }
        public string? valor_total_suprimentos { get; set; }
        public string? valor_total_despesas { get; set; }
        public string? valor_total_receitas { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxFechamentoCaixa() { }

        public LinxFechamentoCaixa(string? id_fechamento_caixa, string? empresa, string? data_fechamento, string? valor_total_vendas, string? valor_total_recebimentos, string? valor_total_sangrias, string? valor_total_suprimentos, string? valor_total_despesas, string? valor_total_receitas, string? timestamp, string? portal)
        {
            this.id_fechamento_caixa = id_fechamento_caixa;
            this.empresa = empresa;
            this.data_fechamento = data_fechamento;
            this.valor_total_vendas = valor_total_vendas;
            this.valor_total_recebimentos = valor_total_recebimentos;
            this.valor_total_sangrias = valor_total_sangrias;
            this.valor_total_suprimentos = valor_total_suprimentos;
            this.valor_total_despesas = valor_total_despesas;
            this.valor_total_receitas = valor_total_receitas;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}