namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosDetalhesSimplificado
    {
        public string? cod_produto { get; set; }
        public string? empresa { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? quantidade { get; set; }
        public string? id_config_tributaria { get; set; }
        public string? timestamp { get; set; }
    }
}
