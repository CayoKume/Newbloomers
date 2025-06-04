namespace Domain.AfterSale.Entities
{
    public class TrackingHistory
    {
        public int? id { get; set; }
        public int? tracking_id { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public DateTime? status_updated_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
