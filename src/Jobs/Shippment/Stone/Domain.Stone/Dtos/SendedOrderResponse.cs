namespace Domain.Stone.Dtos
{
    public class SendedOrderResponse
    {
        public Guid id { get; set; }
        public DateTime createdAt { get; set; }
        public int eta { get; set; }
        public int slaWorkingDays { get; set; }
        public string service { get; set; }
        public Int64 expiresAt { get; set; }
        public Int64 quoteExpirationDate { get; set; }
        public Guid deliveryRequestId { get; set; }
        public decimal cost { get; set; }
        public Int64 totalETA { get; set; }
        public decimal totalCost { get; set; }
        public string classification { get; set; }
    }
}
