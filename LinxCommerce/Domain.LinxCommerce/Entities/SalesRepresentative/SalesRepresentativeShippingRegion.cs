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

        public static bool operator ==(SalesRepresentativeShippingRegion a, SalesRepresentativeShippingRegion b)
        {
            if (a is not null && b is not null)
                return a.SelectedMode == b.SelectedMode && a.ShippingRegionID.Equals(b.ShippingRegionID) && a.PointOfSalesList.Count() > 0 ? String.Join(", ", a.PointOfSalesList) == b.PointOfSales : b.PointOfSales == null;
            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(SalesRepresentativeShippingRegion a, SalesRepresentativeShippingRegion b)
        {
            return !(a == b);
        }
    }
}
