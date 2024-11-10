namespace AfterSale.Domain.Entites.Refunds
{
    public class Refunds
    {
        public int current_page { get; set; }
        public string? FirstOrDefault_page_url { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public string? last_page_url { get; set; }
        public string? next_page_url { get; set; }
        public string? path { get; set; }
        public int per_page { get; set; }
        public string? prev_page_url { get; set; }
        public int to { get; set; }
        public int total { get; set; }
        public bool success { get; set; }
        public Refund[] data { get; set; }
    }

    public class Refund
    {
        public int id { get; set; }
        public string? action { get; set; }
        public string? bonus_amount_percent { get; set; }
        public Customer customer { get; set; }
        public string? order_id { get; set; }
        public int requested_amount { get; set; }
        public int requested_total_amount { get; set; }
        public int reverse_id { get; set; }
        public StatusRefund status { get; set; }
        public string? total_amount { get; set; }
        public string? type { get; set; }
        public string? updated_at { get; set; }
        public string? created_at { get; set; }
    }
}
