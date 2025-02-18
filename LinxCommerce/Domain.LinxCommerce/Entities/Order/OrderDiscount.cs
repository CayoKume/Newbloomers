namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderDiscount
    {
        public decimal? Amount { get; set; }
        public Int32? DiscountID { get; set; }
        public string? Message { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public Guid? OrderID { get; set; }
    }
}
