namespace Domain.AfterSale.Entities
{
    public class ReverseSimplified
    {
        public int? id { get; set; }
        public string? reverse_type { get; set; }
        public string? reverse_type_name { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? order_id { get; set; }
        public decimal? total_amount { get; set; }
        public string? returned_invoice { get; set; }
        public decimal? refunds_count { get; set; }
        public Customer customer { get; set; }
        public Status status { get; set; }
        public Tracking tracking { get; set; }
    }

    public class GetReverses
    {
        public int? current_page { get; set; }
        public string? first_page_url { get; set; }
        public int? from { get; set; }
        public int? last_page { get; set; }
        public string? last_page_url { get; set; }
        public string? next_page_url { get; set; }
        public string? path { get; set; }
        public int? per_page { get; set; }
        public string? prev_page_url { get; set; }
        public int? to { get; set; }
        public int? total { get; set; }
        public bool? success { get; set; }
        public List<ReverseSimplified> data { get; set; }
    }
}
