namespace Domain.LinxCommerce.Entities.Order
{
    public class Order
    {
        class Root
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
            public string? PaymentDate { get; set; }
            public string? PaymentStatus { get; set; }
            public string? ShipmentDate { get; set; }
            public string? ShipmentStatus { get; set; }
            public string? GlobalStatus { get; set; }
            public string? DeliveryPostalCode { get; set; }
            public string? CreatedChannel { get; set; }
            public int? TrafficSourceID { get; set; }
            public int? OrderStatusID { get; set; }
            public List<OrderItem> Items { get; set; }
            public List<OrderTag> Tags { get; set; }
            public List<OrderAddress> Addresses { get; set; }
            public List<OrderPaymentMethod> PaymentMethods { get; set; }
            public List<OrderDeliveryMethod> DeliveryMethods { get; set; }
            public List<OrderDiscount> Discounts { get; set; }
            public List<OrderShipment> Shipments { get; set; }
            public string? CreatedDate { get; set; }
            public string? CreatedBy { get; set; }
            public string? ModifiedDate { get; set; }
            public string? ModifiedBy { get; set; }
            public string? Remarks { get; set; }
            public decimal? SellerCommissionAmount { get; set; }
            public decimal? CommissionAmount { get; set; }
            public OrderInvoice OrderInvoice { get; set; }
            public string? OrderGroupID { get; set; }
            public string? OrderGroupNumber { get; set; }
            public bool? HasConflicts { get; set; }
            public string? AcquiredDate { get; set; }
            public bool? HasHubOrderWithoutShipmentConflict { get; set; }
            public string? CustomerType { get; set; }
            public string? CancelledDate { get; set; }
            public string? WebSiteName { get; set; }
            public string? CustomerName { get; set; }
            public string? CustomerEmail { get; set; }
            public string? CustomerGender { get; set; }
            public string? CustomerBirthDate { get; set; }
            public string? CustomerPhone { get; set; }
            public string? CustomerCPF { get; set; }
            public string? CustomerCNPJ { get; set; }
            public string? CustomerTradingName { get; set; }
            public string? CustomerSiteTaxPayer { get; set; }
        }
    }
}
