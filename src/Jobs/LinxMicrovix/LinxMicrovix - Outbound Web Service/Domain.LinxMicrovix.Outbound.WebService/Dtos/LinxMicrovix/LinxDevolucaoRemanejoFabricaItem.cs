namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaItem
    {
        public string? id_devolucao_remanejo_fabrica_item { get; set; }
        public string? id_devolucao_remanejo_fabrica { get; set; }
        public string? codigoproduto { get; set; }
        public string? codigo_produto_franqueadora { get; set; }
        public string? quantidade { get; set; }
        public string? codebar { get; set; }
        public string? serial { get; set; }
        public string? timestamp { get; set; }

        public LinxDevolucaoRemanejoFabricaItem()
        {
        }

        public LinxDevolucaoRemanejoFabricaItem(string? id_devolucao_remanejo_fabrica_item, string? id_devolucao_remanejo_fabrica, string? codigoproduto, string? codigo_produto_franqueadora, string? quantidade, string? codebar, string? serial, string? timestamp)
        {
            this.id_devolucao_remanejo_fabrica_item = id_devolucao_remanejo_fabrica_item;
            this.id_devolucao_remanejo_fabrica = id_devolucao_remanejo_fabrica;
            this.codigoproduto = codigoproduto;
            this.codigo_produto_franqueadora = codigo_produto_franqueadora;
            this.quantidade = quantidade;
            this.codebar = codebar;
            this.serial = serial;
            this.timestamp = timestamp;
        }
    }
}
