using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPackage : IEquatable<OrderPackage>
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

        public static List<OrderPackage?> Compare(List<OrderPackage?> orderPackageAPIList, List<OrderPackage> orderPackageDboList)
        {
            try
            {
                foreach (var oPackageDbo in orderPackageDboList)
                {
                    orderPackageAPIList.Remove(
                        orderPackageAPIList
                            .Where(oPackageAPI =>
                                oPackageAPI.OrderPackageID == oPackageDbo.OrderPackageID &&
                                oPackageAPI.OrderShipmentID == oPackageDbo.OrderShipmentID &&
                                oPackageAPI.DeliveryMethodID == oPackageDbo.DeliveryMethodID &&
                                oPackageAPI.PackageNumber == oPackageDbo.PackageNumber &&
                                oPackageAPI.TrackingNumber == oPackageDbo.TrackingNumber &&
                                oPackageAPI.TrackingNumberUrl == oPackageDbo.TrackingNumberUrl &&
                                oPackageAPI.ShippedDate == oPackageDbo.ShippedDate &&
                                oPackageAPI.ShippedBy == oPackageDbo.ShippedBy &&
                                oPackageAPI.IsDeleted == oPackageDbo.IsDeleted &&
                                oPackageAPI.PackageType == oPackageDbo.PackageType &&
                                oPackageAPI.Source == oPackageDbo.Source &&
                                oPackageAPI.InsuranceAmount == oPackageDbo.InsuranceAmount &&
                                oPackageAPI.Weight == oPackageDbo.Weight &&
                                oPackageAPI.Length == oPackageDbo.Length &&
                                oPackageAPI.Height == oPackageDbo.Height &&
                                oPackageAPI.Width == oPackageDbo.Width
                            ).FirstOrDefault()
                    );
                }

                return orderPackageAPIList;
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.Compare,
                    error: EnumError.Compare,
                    level: EnumMessageLevel.Error,
                    message: $"Error when comparing two lists of records",
                    exceptionMessage: ex.Message
                );
            }
        }

        public bool Equals(OrderPackage? other)
        {
             return
                 this.OrderPackageID.Equals(other.OrderPackageID) &&
                 this.OrderShipmentID.Equals(other.OrderShipmentID) &&
                 this.DeliveryMethodID.Equals(other.DeliveryMethodID) &&
                 this.PackageNumber == other.PackageNumber &&
                 this.TrackingNumber == other.TrackingNumber &&
                 this.TrackingNumberUrl == other.TrackingNumberUrl &&
                 this.ShippedDate.Equals(other.ShippedDate) &&
                 this.ShippedBy == other.ShippedBy &&
                 this.IsDeleted.Equals(other.IsDeleted) &&
                 this.PackageType == other.PackageType &&
                 this.Source == other.Source &&
                 this.InsuranceAmount == other.InsuranceAmount &&
                 this.Weight == other.Weight &&
                 this.Length == other.Length &&
                 this.Height == other.Height &&
                 this.Width == other.Width;
        }
    }
}
