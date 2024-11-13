namespace LinxCommerce.Domain.Entities.Sales.SalesRepresentative
{
    public class SalesRepresentativeShippingRegion
    {
        public string? SelectedMode { get; set; }
        public int ShippingRegionID { get; set; }
        public List<int> PointOfSalesList { get; set; } //list int
    }
}
