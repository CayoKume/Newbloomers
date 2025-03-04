namespace Domain.AfterSale.Entities
{
    public class Refunds
    {
        public int? id { get; set; }
        public string? action { get; set; }
        public string? bonus_amount_percent { get; set; }
        public string? order_id { get; set; }
        public decimal? requested_amount { get; set; }
        public decimal? requested_total_amount { get; set; }
        public int? reverse_id { get; set; }
        public decimal? total_amount { get; set; }
        public string? type { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? created_at { get; set; }
        public Customer customer { get; set; }
        public Status status { get; set; }
    }
}
