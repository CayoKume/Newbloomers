using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeShippingRegion
    {
        public int? SalesRepresentativeID { get; set; }
        public string? SelectedMode { get; set; }
        public int? ShippingRegionID { get; set; }
        public List<int>? PointOfSalesList { get; set; }

        [SkipProperty]
        public string? PointOfSales { get; set; }
    }
}
