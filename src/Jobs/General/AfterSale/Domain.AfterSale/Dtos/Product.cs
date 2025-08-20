namespace Domain.AfterSale.Dtos
{
    public class Product
    {
        public string? id { get; set; }
        public string? reverse_id { get; set; }
        public string? motive_id { get; set; }
        public string? ecommerce_order_product_id { get; set; }
        public string? refund_id { get; set; }
        public string? qty { get; set; }
        public string? requested_qty { get; set; }
        public string? received_qty { get; set; }
        public string? product_received_comment { get; set; }
        public string? comments { get; set; }
        public string? reverse_action { get; set; }
        public string? customer_retention_method_id { get; set; }
        public string? protocol { get; set; }
        public string? product_id { get; set; }
        public string? hash { get; set; }
        public string? name { get; set; }
        public string? sku { get; set; }
        public string? price { get; set; }
        public string? selling_price { get; set; }
        public string? weight { get; set; }
        public string? returned_invoice { get; set; }
        public string? invoice { get; set; }
        public string? order_id { get; set; }
        public Reason reason { get; set; }
    }
}
