namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaEmpresas
    {
        public string? empresa { get; set; }
        public string? nome_emp { get; set; }
        public string? cnpj_emp { get; set; }
        public string? end_unidade { get; set; }
        public string? complemento_end_unidade { get; set; }
        public string? nr_rua_unidade { get; set; }
        public string? bairro_unidade { get; set; }
        public string? cep_unidade { get; set; }
        public string? cidade_unidade { get; set; }
        public string? uf_unidade { get; set; }
        public string? email_unidade { get; set; }
        public string? timestamp { get; set; }
        public string? data_criacao { get; set; }
        public string? centro_distribuicao { get; set; }
        public string? portal { get; set; }
    }
}
