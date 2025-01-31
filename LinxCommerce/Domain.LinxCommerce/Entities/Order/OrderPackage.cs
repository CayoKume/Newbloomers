namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPackage
    {
        public string OrderPackageID { get; set; }
        public string OrderShipmentID { get; set; }
        public string DeliveryMethodID { get; set; }
        public string PackageNumber { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingNumberUrl { get; set; }
        public string ShippedDate { get; set; }
        public string ShippedBy { get; set; }
        public string IsDeleted { get; set; }
        public string PackageType { get; set; }
        public string Source { get; set; }
        public string InsuranceAmount { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Weight { get; set; }
    }
}
