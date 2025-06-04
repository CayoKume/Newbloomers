namespace Domain.AfterSale.Entities
{
    public class TotalAmountHistories
    {
        public Int32 id { get; set; }
        public decimal? total_amount { get; set; }
        public DateTime? date { get; set; }
        public Int32 refund_id { get; set; }

        public Type type { get; set; }
        public Refund Refund { get; set; }
    }
}
