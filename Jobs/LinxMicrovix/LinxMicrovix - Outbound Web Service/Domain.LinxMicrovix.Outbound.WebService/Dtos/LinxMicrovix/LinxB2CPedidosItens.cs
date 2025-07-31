namespace Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix
{
    public class LinxB2CPedidosItens
    {
        public string? id_pedido_item { get; set; }
        public string? id_pedido { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? vl_unitario { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }

        public LinxB2CPedidosItens()
        {
        }

        public LinxB2CPedidosItens(string? id_pedido_item, string? id_pedido, string? codigoproduto, string? quantidade, string? vl_unitario, string? timestamp, string? portal)
        {
            this.id_pedido_item = id_pedido_item;
            this.id_pedido = id_pedido;
            this.codigoproduto = codigoproduto;
            this.quantidade = quantidade;
            this.vl_unitario = vl_unitario;
            this.timestamp = timestamp;
            this.portal = portal;
        }
    }
}
