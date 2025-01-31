namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderDiscount
    {
        public int? DiscountID { get; set; }
        public string? Reference { get; set; }
        public decimal? Amount { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
    }
}
