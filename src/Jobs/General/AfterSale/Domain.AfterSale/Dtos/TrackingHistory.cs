namespace Domain.AfterSale.Dtos
{
    public class TrackingHistory
    {
        public string? id { get; set; }
        public string? tracking_id { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? status_updated_at { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? deleted_at { get; set; }
    }
}
