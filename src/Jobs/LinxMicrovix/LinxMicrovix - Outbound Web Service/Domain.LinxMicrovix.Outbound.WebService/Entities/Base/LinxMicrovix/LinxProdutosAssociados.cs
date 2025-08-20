namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxProdutosAssociados
    {
        public string? codigoproduto_associado { get; set; }
        public string? portal { get; set; }
        public string? codigoproduto_origem { get; set; }
        public string? coeficiente_desconto { get; set; }
        public string? timestamp { get; set; }
        public string? qtde_item { get; set; }
        public string? item_obrigatorio { get; set; }
    }
}
