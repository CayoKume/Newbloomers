namespace Domain.AfterSale.Dtos
{
    public class ResponseReverses
    {
        public int? current_page { get; set; }
        public string? first_page_url { get; set; }
        public string? from { get; set; }
        public int? last_page { get; set; }
        public string? last_page_url { get; set; }
        public string? next_page_url { get; set; }
        public string? path { get; set; }
        public string? per_page { get; set; }
        public string? prev_page_url { get; set; }
        public string? to { get; set; }
        public int? total { get; set; }
        public bool success { get; set; }
        public List<Reverse> data { get; set; }
    }
}
