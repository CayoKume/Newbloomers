namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaPedidosItens
    {
        public string? id_pedido_item { get; set; }
        public string? id_pedido { get; set; }
        public string? codigoproduto { get; set; }
        public string? quantidade { get; set; }
        public string? vl_unitario { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
