namespace Domain.AfterSale.Dtos
{
    public class Voucher
    {
        public string? redemption_code { get; set; }
        public string? giftcard_id { get; set; }
        public string? expiring_date { get; set; }
    }
}
