namespace Domain.AfterSale.Dtos
{
    public class OrderTransactions
    {
        public string? id { get; set; }
        public string? refund_id { get; set; }
        public string? ecommerce_order_id { get; set; }
        public string? transaction_id { get; set; }
        public string? acquirer { get; set; }
        public string? nsu { get; set; }
        public string? tid { get; set; }
        public string? total_amount { get; set; }
        public string? merchant_name { get; set; }
        public string? date { get; set; }
    }
}
