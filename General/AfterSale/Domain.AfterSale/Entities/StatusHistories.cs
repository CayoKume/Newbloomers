namespace Domain.AfterSale.Entities
{
    public class StatusHistories
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? status_id { get; set; }
        public int? user_id { get; set; }
        public int? customer_id { get; set; }
        public DateTime? date { get; set; }
        public string? comments { get; set; }
        public Status status { get; set; }
    }
}
