namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxMetasVendedoresDia
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_meta { get; set; }
        public string? descricao_meta { get; set; }
        public string? data_inicial_meta { get; set; }
        public string? data_final_meta { get; set; }
        public string? dia { get; set; }
        public string? valor_meta_diaria { get; set; }
        public string? cod_vendedor { get; set; }

        public LinxMetasVendedoresDia()
        {
        }

        public LinxMetasVendedoresDia(string? portal, string? cnpj_emp, string? id_meta, string? descricao_meta, string? data_inicial_meta, string? data_final_meta, string? dia, string? valor_meta_diaria, string? cod_vendedor)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_meta = id_meta;
            this.descricao_meta = descricao_meta;
            this.data_inicial_meta = data_inicial_meta;
            this.data_final_meta = data_final_meta;
            this.dia = dia;
            this.valor_meta_diaria = valor_meta_diaria;
            this.cod_vendedor = cod_vendedor;
        }
    }
}
