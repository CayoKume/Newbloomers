namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosTabelasPrecos
    {
        public string? cod_produto { get; set; }
        public string? portal { get; set; }
        public string? cnpj_emp { get; set; }
        public string? id_tabela { get; set; }
        public string? precovenda { get; set; }
        public string? timestamp { get; set; }
    }
}
