namespace Domain.AfterSale.Entities
{
    public class TotalAmountHistories
    {
        public Int32 id { get; set; }
        public decimal? total_amount { get; set; }
        public DateTime? date { get; set; }
        public User user { get; set; }
        public Type type { get; set; }
    }
}
