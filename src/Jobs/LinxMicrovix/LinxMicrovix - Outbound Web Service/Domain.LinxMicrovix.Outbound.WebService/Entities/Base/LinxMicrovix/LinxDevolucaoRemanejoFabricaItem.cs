namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxMicrovix
{
    public abstract class LinxDevolucaoRemanejoFabricaItem
    {
        public string? id_devolucao_remanejo_fabrica_item { get; set; }
        public string? id_devolucao_remanejo_fabrica { get; set; }
        public string? codigoproduto { get; set; }
        public string? codigo_produto_franqueadora { get; set; }
        public string? quantidade { get; set; }
        public string? codebar { get; set; }
        public string? serial { get; set; }
        public string? timestamp { get; set; }
    }
}
