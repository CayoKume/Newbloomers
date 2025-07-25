namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxLojas
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

        public LinxLojas() { }

        public LinxLojas(string? empresa, string? nome_emp, string? cnpj_emp, string? end_unidade,
                         string? complemento_end_unidade, string? nr_rua_unidade, string? bairro_unidade,
                         string? cep_unidade, string? cidade_unidade, string? uf_unidade, string? email_unidade,
                         string? timestamp, string? data_criacao, string? centro_distribuicao, string? portal)
        {
            this.empresa = empresa;
            this.nome_emp = nome_emp;
            this.cnpj_emp = cnpj_emp;
            this.end_unidade = end_unidade;
            this.complemento_end_unidade = complemento_end_unidade;
            this.nr_rua_unidade = nr_rua_unidade;
            this.bairro_unidade = bairro_unidade;
            this.cep_unidade = cep_unidade;
            this.cidade_unidade = cidade_unidade;
            this.uf_unidade = uf_unidade;
            this.email_unidade = email_unidade;
            this.timestamp = timestamp;
            this.data_criacao = data_criacao;
            this.centro_distribuicao = centro_distribuicao;
            this.portal = portal;
        }

    }
}