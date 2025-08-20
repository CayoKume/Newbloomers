namespace Domain.AfterSale.Entities
{
    public class OrderTransactions
    {
        public Int32? id { get; set; }
        public Int32? refund_id { get; set; }
        public Int32? ecommerce_order_id { get; set; }
        public Int32? transaction_id { get; set; }
        public string? acquirer { get; set; }
        public string? nsu { get; set; }
        public string? tid { get; set; }
        public decimal? total_amount { get; set; }
        public string? merchant_name { get; set; }
        public DateTime? date { get; set; }
    }
}
