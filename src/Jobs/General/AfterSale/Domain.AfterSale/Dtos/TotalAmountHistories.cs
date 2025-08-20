namespace Domain.AfterSale.Dtos
{
    public class TotalAmountHistories
    {
        public string id { get; set; }
        public string? total_amount { get; set; }
        public string? date { get; set; }
        public string refund_id { get; set; }

        public Type type { get; set; }
        public Refund Refund { get; set; }
    }
}
