namespace Domain.AfterSale.Entities
{
    public class Product
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? motive_id { get; set; }
        public int? ecommerce_order_product_id { get; set; }
        public int? refund_id { get; set; }
        public int? qty { get; set; }
        public int? requested_qty { get; set; }
        public int? received_qty { get; set; }
        public int? product_received_comment { get; set; }
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
        public int? order_id { get; set; }
        public string?[] image_url { get; set; }
        public Reason reason { get; set; }
        public List<Image> images { get; set; }
        public string?[] refund_product_requests { get; set; }
    }
}
