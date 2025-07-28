namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosDetalhes
    {
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? cod_produto { get; set; }
        public string? cod_barra { get; set; }
        public string? quantidade { get; set; }
        public string? preco_custo { get; set; }
        public string? preco_venda { get; set; }
        public string? custo_medio { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? desc_config_tributaria { get; set; }
        public string? despesas1 { get; set; }
        public string? qtde_minima { get; set; }
        public string? qtde_maxima { get; set; }
        public string? ipi { get; set; }
        public string? timestamp { get; set; }
        public string? empresa { get; set; }
    }
}
