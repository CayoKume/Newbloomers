namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMetasVendedores
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_meta { get; set; }
        public string? descricao_meta { get; set; }
        public string? data_inicial_meta { get; set; }
        public string? data_final_meta { get; set; }
        public string? valor_meta_loja { get; set; }
        public string? valor_meta_vendedor { get; set; }
        public string? cod_vendedor { get; set; }
        public string? timestamp { get; set; }

        public LinxMetasVendedores()
        {
        }

        public LinxMetasVendedores(string? portal, string? cnpj_emp, string? id_meta, string? descricao_meta, string? data_inicial_meta, string? data_final_meta, string? valor_meta_loja, string? valor_meta_vendedor, string? cod_vendedor, string? timestamp)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_meta = id_meta;
            this.descricao_meta = descricao_meta;
            this.data_inicial_meta = data_inicial_meta;
            this.data_final_meta = data_final_meta;
            this.valor_meta_loja = valor_meta_loja;
            this.valor_meta_vendedor = valor_meta_vendedor;
            this.cod_vendedor = cod_vendedor;
            this.timestamp = timestamp;
        }
    }
}
