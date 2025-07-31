namespace Domain.AfterSale.Entities
{
    public class Voucher
    {
        public string? redemption_code { get; set; }
        public string? giftcard_id { get; set; }
        public DateTime? expiring_date { get; set; }
    }
}
