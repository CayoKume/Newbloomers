using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class Order
    {
        public class Root
        {
            public string? OrderID { get; set; }
            public string? OrderNumber { get; set; }
            public string? MarketPlaceBrand { get; set; }
            public string? OriginalOrderID { get; set; }
            public int? WebSiteID { get; set; }
            public string? WebSiteIntegrationID { get; set; }
            public int? CustomerID { get; set; }
            public string? ShopperTicketID { get; set; }
            public decimal? ItemsQty { get; set; }
            public int? ItemsCount { get; set; }
            public decimal? TaxAmount { get; set; }
            public decimal? DeliveryAmount { get; set; }
            public decimal? DiscountAmount { get; set; }
            public decimal? PaymentTaxAmount { get; set; }
            public decimal? SubTotal { get; set; }
            public decimal? Total { get; set; }
            public decimal? TotalDue { get; set; }
            public decimal? TotalPaid { get; set; }
            public decimal? TotalRefunded { get; set; }
            public DateTime? PaymentDate { get; set; }
            public string? PaymentStatus { get; set; }
            public DateTime? ShipmentDate { get; set; }
            public string? ShipmentStatus { get; set; }
            public string? GlobalStatus { get; set; }
            public string? DeliveryPostalCode { get; set; }
            public string? CreatedChannel { get; set; }
            public int? TrafficSourceID { get; set; }
            public int? OrderStatusID { get; set; }
            public DateTime? CreatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public string? ModifiedBy { get; set; }
            public string? Remarks { get; set; }
            public decimal? SellerCommissionAmount { get; set; }
            public decimal? CommissionAmount { get; set; }
            public string? OrderGroupID { get; set; }
            public string? OrderGroupNumber { get; set; }
            public bool? HasConflicts { get; set; }
            public DateTime? AcquiredDate { get; set; }
            public bool? HasHubOrderWithoutShipmentConflict { get; set; }
            public string? CustomerType { get; set; }
            public DateTime? CancelledDate { get; set; }
            public string? WebSiteName { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerEmail { get; set; }
            public string? CustomerGender { get; set; }
            public DateTime? CustomerBirthDate { get; set; }
            public string? CustomerPhone { get; set; }
            public string? CustomerCPF { get; set; }
            public string? CustomerCNPJ { get; set; }
            public string? CustomerTradingName { get; set; }
            public string? CustomerSiteTaxPayer { get; set; }

            [SkipProperty]
            public List<OrderItem> Items { get; set; }

            [SkipProperty]
            public List<OrderTag> Tags { get; set; }
            
            [SkipProperty]
            public List<OrderAddress> Addresses { get; set; }
            
            [SkipProperty]
            public List<OrderPaymentMethod> PaymentMethods { get; set; }
            
            [SkipProperty]
            public List<OrderDeliveryMethod> DeliveryMethods { get; set; }
            
            [SkipProperty]
            public List<OrderDiscount> Discounts { get; set; }
            
            [SkipProperty]
            public List<OrderShipment> Shipments { get; set; }
            
            [SkipProperty]
            public OrderInvoice OrderInvoice { get; set; }

            [SkipProperty]
            public Dictionary<int, string> Responses { get; set; } = new Dictionary<int, string>();
        }
    }
}
