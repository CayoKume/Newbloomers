using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderShipment
    {
        public string OrderShipmentID { get; set; }
        public string OrderID { get; set; }
        public string DeliveryMethodID { get; set; }
        public string ShipmentNumber { get; set; }
        public string ShipmentStatus { get; set; }
        public string AssignUserId { get; set; }
        public string AssignUserName { get; set; }
        public string DockID { get; set; }

        [SkipProperty]
        public List<OrderPackage> Packages { get; set; }
    }
}
