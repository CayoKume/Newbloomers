namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaPedidosStatus
    {
        public string? id_status { get; set; }
        public string? id_pedido { get; set; }
        public string? data_hora { get; set; }
        public string? anotacao { get; set; }
        public string? timestamp { get; set; }
        public string? portal { get; set; }
    }
}
