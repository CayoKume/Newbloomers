namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeShippingRegion
    {
        public string? SelectedMode { get; set; }
        public int? ShippingRegionID { get; set; }
        public int? SalesRepresentativeID { get; set; }
        public List<int>? PointOfSalesList { get; set; }
    }
}
