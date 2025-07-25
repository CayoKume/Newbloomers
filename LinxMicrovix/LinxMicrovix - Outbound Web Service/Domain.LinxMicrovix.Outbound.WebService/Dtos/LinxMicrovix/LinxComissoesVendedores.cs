namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxComissoesVendedores
    {
        public string? id_comissao { get; set; }
        public string? cod_vendedor { get; set; }
        public string? data_inicial { get; set; }
        public string? data_final { get; set; }
        public string? valor_comissao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxComissoesVendedores() { }

        public LinxComissoesVendedores(string? id_comissao, string? cod_vendedor, string? data_inicial, string? data_final, string? valor_comissao, string? timestamp, string? portal)
        {
            this.id_comissao = id_comissao;
            this.cod_vendedor = cod_vendedor;
            this.data_inicial = data_inicial;
            this.data_final = data_final;
            this.valor_comissao = valor_comissao;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}