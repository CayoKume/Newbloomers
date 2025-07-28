namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxConfiguracoesTributarias
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? desc_config_tributaria { get; set; }
        public string? sigla_config_tributaria { get; set; }
        public string? timestamp { get; set; }
        public string? ativa { get; set; }
        public string? uf { get; set; }
        public string? sistema_tributacao { get; set; }
        public string? tipo_atividade { get; set; }
        public string? id_origem_mercadoria { get; set; }
        public string? utiliza_uso_consumo { get; set; }
        public string? id_classificacao_cest_produto { get; set; }
        public string? codigo_ws { get; set; }

        public LinxConfiguracoesTributarias()
        {
        }

        public LinxConfiguracoesTributarias(string? portal, string? cnpj_emp, string? id_config_tributaria, string? desc_config_tributaria, string? sigla_config_tributaria, string? timestamp, string? ativa, string? uf, string? sistema_tributacao, string? tipo_atividade, string? id_origem_mercadoria, string? utiliza_uso_consumo, string? id_classificacao_cest_produto, string? codigo_ws)
        {
            this.portal = portal;
            this.cnpj_emp = cnpj_emp;
            this.id_config_tributaria = id_config_tributaria;
            this.desc_config_tributaria = desc_config_tributaria;
            this.sigla_config_tributaria = sigla_config_tributaria;
            this.timestamp = timestamp;
            this.ativa = ativa;
            this.uf = uf;
            this.sistema_tributacao = sistema_tributacao;
            this.tipo_atividade = tipo_atividade;
            this.id_origem_mercadoria = id_origem_mercadoria;
            this.utiliza_uso_consumo = utiliza_uso_consumo;
            this.id_classificacao_cest_produto = id_classificacao_cest_produto;
            this.codigo_ws = codigo_ws;
        }
    }
}
