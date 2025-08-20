namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxComissoesVendedores
    {
        public string? vendedor { get; set; }
        public string? empresa { get; set; }
        public string? data_origem { get; set; }
        public string? valor_base { get; set; }
        public string? valor_comissao { get; set; }
        public string? cancelado { get; set; }
        public string? disponivel { get; set; }
        public string? timestamp { get; set; }

        public LinxComissoesVendedores()
        {
        }

        public LinxComissoesVendedores(string? vendedor, string? empresa, string? data_origem, string? valor_base, string? valor_comissao, string? cancelado, string? disponivel, string? timestamp)
        {
            this.vendedor = vendedor;
            this.empresa = empresa;
            this.data_origem = data_origem;
            this.valor_base = valor_base;
            this.valor_comissao = valor_comissao;
            this.cancelado = cancelado;
            this.disponivel = disponivel;
            this.timestamp = timestamp;
        }
    }
}
