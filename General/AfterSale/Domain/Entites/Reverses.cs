namespace AfterSale.Domain.Entites.Reverses
{
    public class Reverses
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
        public Reverse[] data { get; set; }
    }

    public class Reverse
    {
        public int id { get; set; }
        public string? reverse_type { get; set; }
        public string? reverse_type_name { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? order_id { get; set; }
        public string? total_amount { get; set; }
        public string? returned_invoice { get; set; }
        public Customer customer { get; set; }
        public StatusReverse status { get; set; }
        public Tracking tracking { get; set; }
        public int refunds_count { get; set; }
    }

    public class StatusReverse
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }

    public class Tracking
    {
        public string? authorization_code { get; set; }
        public string? shipping_amount { get; set; }
    }
}
