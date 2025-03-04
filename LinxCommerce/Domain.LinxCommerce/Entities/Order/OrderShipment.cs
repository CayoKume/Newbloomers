using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderShipment : IEquatable<OrderShipment>
    {
        public Guid? OrderShipmentID { get; set; }
        public Guid? OrderID { get; set; }
        public Int32? DeliveryMethodID { get; set; }
        public string? ShipmentNumber { get; set; }
        public string? ShipmentStatus { get; set; }
        public Int32? AssignUserId { get; set; }
        public string? AssignUserName { get; set; }
        public Int32? DockID { get; set; }

        [SkipProperty]
        public List<OrderPackage> Packages { get; set; } = new List<OrderPackage>();

        public static List<OrderShipment?> Compare(List<OrderShipment?> orderShipmentAPIList, List<OrderShipment> orderShipmentDboList)
        {
            try
            {
                foreach (var oShipmentDbo in orderShipmentDboList)
                {
                    orderShipmentAPIList.Remove(
                        orderShipmentAPIList
                            .Where(oShipmentAPI =>
                                oShipmentAPI.OrderShipmentID == oShipmentDbo.OrderShipmentID &&
                                oShipmentAPI.OrderID == oShipmentDbo.OrderID &&
                                oShipmentAPI.DeliveryMethodID == oShipmentDbo.DeliveryMethodID &&
                                oShipmentAPI.ShipmentNumber == oShipmentDbo.ShipmentNumber &&
                                oShipmentAPI.ShipmentStatus == oShipmentDbo.ShipmentStatus &&
                                oShipmentAPI.AssignUserId == oShipmentDbo.AssignUserId &&
                                oShipmentAPI.AssignUserName == oShipmentDbo.AssignUserName &&
                                oShipmentAPI.DockID == oShipmentDbo.DockID &&
                                oShipmentAPI.Packages.All(x => oShipmentDbo.Packages.Contains(x))
                            ).FirstOrDefault()
                    );

                    var orderPackageAPIList = orderShipmentAPIList
                        .Where(X => X.OrderID == oShipmentDbo.OrderID)
                        .First()
                        .Packages;

                    orderShipmentAPIList
                        .Where(X => X.OrderID == oShipmentDbo.OrderID)
                        .First()
                        .Packages = OrderPackage.Compare(orderPackageAPIList, oShipmentDbo.Packages);
                }

                return orderShipmentAPIList;
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


        public bool Equals(OrderShipment? other)
        {
            return
                this.OrderShipmentID.Equals(other.OrderShipmentID) &&
                this.OrderID.Equals(other.OrderID) &&
                this.DeliveryMethodID.Equals(other.DeliveryMethodID) &&
                this.ShipmentNumber == other.ShipmentNumber &&
                this.ShipmentStatus == other.ShipmentStatus &&
                this.AssignUserId.Equals(other.AssignUserId) &&
                this.AssignUserName == other.AssignUserName &&
                this.DockID.Equals(other.DockID) &&
                this.Packages.All(x => other.Packages.Contains(x));
        }
    }
}
