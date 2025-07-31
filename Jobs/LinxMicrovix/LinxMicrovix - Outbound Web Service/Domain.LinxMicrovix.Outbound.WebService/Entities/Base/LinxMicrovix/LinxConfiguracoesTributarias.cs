namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxConfiguracoesTributarias
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
    }
}
