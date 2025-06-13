namespace Domain.Stone.Entities
{
    public class CarrierMetadata
    {
        public string? type { get; set; }
        public string? status { get; set; }
        public string? description { get; set; }
        public DateTime? createdAt { get; set; }
        public Place? place { get; set; }
    }
}
