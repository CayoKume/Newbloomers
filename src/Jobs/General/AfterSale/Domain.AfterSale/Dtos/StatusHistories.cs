namespace Domain.AfterSale.Dtos
{
    public class StatusHistories
    {
        public string? id { get; set; }
        public string? reverse_id { get; set; }
        public string? status_id { get; set; }
        public string? user_id { get; set; }
        public string? customer_id { get; set; }
        public string? date { get; set; }
        public string? comments { get; set; }
        public Status status { get; set; }
    }
}
