namespace Domain.Stone.Entities
{
    public class Event
    {
        public Guid? id { get; set; }
        public DateTime? createdAt { get; set; }
        public string? status { get; set; }
        public Carrier? carrier { get; set; }
        public string? trackingCode { get; set; }
        public string? carrierReferencekey { get; set; }
        public int carrierMetadata { get; set; }
    }
}
