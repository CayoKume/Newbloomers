namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItem
    {
        public string? id_devolucao_remanejo_fabrica_item { get; set; }
        public string? id_devolucao_remanejo_fabrica { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxDevolucaoRemanejoFabricaItem() { }

        public LinxDevolucaoRemanejoFabricaItem(string? id_devolucao_remanejo_fabrica_item, string? id_devolucao_remanejo_fabrica, string? codigoproduto, string? quantidade, string? timestamp, string? portal)
        {
            this.id_devolucao_remanejo_fabrica_item = id_devolucao_remanejo_fabrica_item;
            this.id_devolucao_remanejo_fabrica = id_devolucao_remanejo_fabrica;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}