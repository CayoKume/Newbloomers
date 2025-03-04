namespace Domain.AfterSale.Entities
{
    public class EcommerceOrder
    {
        public int? id { get; set; }
        public int? customer_id { get; set; }
        public DateTime? deleted_at { get; set; }
        public int? ecommerce_id { get; set; }
        public string? invoice_number { get; set; }
        public bool? is_marketplace { get; set; }
        public bool? is_online { get; set; }
        public string? marketplace_name { get; set; }
        public string? order_id { get; set; }
        public DateTime? ordered_at { get; set; }
        public string?[] payment_methods { get; set; }
        public decimal? shipping_value { get; set; }
        public DateTime? updated_at { get; set; }
        public decimal? value { get; set; }
    }
}
