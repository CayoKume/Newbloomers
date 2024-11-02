using LinxCommerce.Domain.Entities.Sales.Order;

namespace LinxCommerce.Domain.Entities.Sales.Model
{
    public class Fulfillment
    {
        public string? FulfillmentID { get; set; }
        public string? OrderID { get; set; }
        public string? ExternalID { get; set; }
        public string? FulfillmentNumber { get; set; }
        public string? ExternalFriendlyKey { get; set; }
        public string? Type { get; set; }
        public string? DeliveryAmount { get; set; }
        public string? DiscountAmount { get; set; }
        public string? Total { get; set; }
        public string? FulfillmentStatusID { get; set; }
        public string? GlobalFulfillmentStatus { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public OrderAddress Address { get; set; } = new OrderAddress();
        public DeliveryMethod DeliveryMethod { get; set; } = new DeliveryMethod();
        public Shipment Shipment { get; set; } = new Shipment();
        public OrderInvoice Invoice { get; set; } = new OrderInvoice();
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? DeliveryLocationDescription { get; set; }
        public string? DeliveryLocationID { get; set; }
        public string? IsVirtual { get; set; }
    }
}
