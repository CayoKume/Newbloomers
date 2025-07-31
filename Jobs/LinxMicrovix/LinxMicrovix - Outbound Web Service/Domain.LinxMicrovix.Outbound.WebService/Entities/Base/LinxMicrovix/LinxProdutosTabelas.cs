namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosTabelas
    {
        public string? id_tabela { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? nome_tabela { get; set; }
        public string? ativa { get; set; }
        public string? timestamp { get; set; }
        public string? tipo_tabela { get; set; }
        public string? codigo_integracao_ws { get; set; }
    }
}
