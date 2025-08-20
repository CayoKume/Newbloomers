namespace Domain.Stone.Entities
{
    public class Order
    {
        public Guid? id { get; set; }
        public DateTime? createdAt { get; set; }
        public bool? acceptedAgreements { get; set; }
        public string? referenceKey { get; set; }
        public Guid? quoteI { get; set; }
        public string? status { get; set; }
        public string? trackingCode { get; set; }
        public decimal? totalCost { get; set; }
        public decimal? totalETA { get; set; }
        public string? tagUrl { get; set; }
        public bool? wasTagGenerated { get; set; }
        public DateTime? deadlineDate { get; set; }

        public Customer? customer { get; set; }
        public Sender? sender { get; set; }
        public Carrier? carrier { get; set; }
        public DeliveryAddress? deliveryAddress { get; set; }
        public PickupAddress? pickupAddress { get; set; }
        public Metric? metrics { get; set; }
        public PaymentOption? paymentOption { get; set; }
        public Owner? owner { get; set; }
        public List<Item>? items { get; set; }
        public List<Event>? events { get; set; }
    }
}
