namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPackage
    {
        public Guid? OrderPackageID { get; set; }
        public Guid? OrderShipmentID { get; set; }
        public Int32? DeliveryMethodID { get; set; }
        public string? PackageNumber { get; set; }
        public string? TrackingNumber { get; set; }
        public string? TrackingNumberUrl { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string? ShippedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public string? PackageType { get; set; }
        public string? Source { get; set; }
        public decimal? InsuranceAmount { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
    }
}
