namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeMaxDiscount
    {
        public string? Type { get; set; }
        public decimal? Amount { get; set; }
        public int? SalesRepresentativeCustomerRelationID { get; set; }
        public int? SalesRepresentativeID { get; set; }
    }
}
