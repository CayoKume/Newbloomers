namespace Domain.LinxMicrovix.Outbound.WebService.Entities.Base.LinxCommerce
{
    public abstract class B2CConsultaPedidosIdentificador
    {
        public string? portal { get; set; }
        public string? empresa { get; set; }
        public string? identificador { get; set; }
        public string? id_venda { get; set; }
        public string? order_id { get; set; }
        public string? id_cliente { get; set; }
        public string? valor_frete { get; set; }
        public string? data_origem { get; set; }
        public string? timestamp { get; set; }
    }
}
