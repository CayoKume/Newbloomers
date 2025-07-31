namespace Domain.Stone.Entities
{
    public class DeliveryOptions
    {
        public Guid? id { get; set; }
        public DateTime createdAt { get; set; }
        public Int32? eta { get; set; }
        public Carrier? carrier { get; set; }
        public string? name { get; set; }
        public string? service { get; set; }
        public DateTime? expiresAt { get; set; }
        public DeliveryAddress? deliveryAddress { get; set; }
        public PickupAddress? pickupAddress { get; set; }
        public Guid? deliveryRequestId { get; set; }
        public decimal? cost { get; set; }
        public string? classification { get; set; }
    }
}
