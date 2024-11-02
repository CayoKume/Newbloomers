using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LinxCommerce.Domain.Entities.Sales.Order;
using LinxCommerce.Domain.Entities.Sales.Model;

namespace LinxCommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        [Column(TypeName = "varchar(60)")]
        public string? OrderID { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? OrderNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? MarketPlaceBrand { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? OriginalOrderID { get; set; }

        [Column(TypeName = "int")]
        public Int32 WebSiteID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? WebSiteIntegrationID { get; set; }

        [Column(TypeName = "int")]
        public Int32 CustomerID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? ShopperTicketID { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ItemsQty { get; set; }

        [Column(TypeName = "int")]
        public Int32 ItemsCount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TaxAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal DeliveryAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PaymentTaxAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalDue { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPaid { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalRefunded { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? PaymentDate { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? PaymentStatus { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? ShipmentDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? ShipmentStatus { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? GlobalStatus { get; set; }

        [Column(TypeName = "varchar(9)")]
        public string? DeliveryPostalCode { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CreatedChannel { get; set; }

        [Column(TypeName = "int")]
        public Int32 TrafficSourceID { get; set; }

        [Column(TypeName = "int")]
        public Int32 OrderStatusID { get; set; }


        public List<OrderItem> Items { get; set; } = new List<OrderItem>();


        public List<Tag> Tags { get; set; } = new List<Tag>();


        public List<Property> Properties { get; set; } = new List<Property>();


        public List<OrderAddress> Addresses { get; set; } = new List<OrderAddress>();


        public List<OrderPaymentMethod> PaymentMethods { get; set; } = new List<OrderPaymentMethod>();


        public List<DeliveryMethod> DeliveryMethods { get; set; } = new List<DeliveryMethod>();


        public List<Discount> Discounts { get; set; } = new List<Discount>();


        public List<Shipment> Shipments { get; set; } = new List<Shipment>();


        public List<Fulfillment> Fulfillments { get; set; } = new List<Fulfillment>();

        [Column(TypeName = "varchar(40)")]
        public string? CreatedDate { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CreatedBy { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? ModifiedDate { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? ModifiedBy { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? Remarks { get; set; }


        public Seller Seller { get; set; } = new Seller();

        [Column(TypeName = "decimal(10,2)")]
        public decimal SellerCommissionAmount { get; set; }


        public OrderSalesRepresentative SalesRepresentative { get; set; } = new OrderSalesRepresentative();

        [Column(TypeName = "decimal(10,2)")]
        public decimal CommissionAmount { get; set; }


        public OrderType OrderType { get; set; } = new OrderType();


        public OrderInvoice OrderInvoice { get; set; } = new OrderInvoice();

        [Column(TypeName = "varchar(60)")]
        public string? OrderGroupID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? OrderGroupNumber { get; set; }

        [Column(TypeName = "bit")]
        public bool HasConflicts { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? AcquiredDate { get; set; }


        public ExternalInfo ExternalInfo { get; set; } = new ExternalInfo();

        [Column(TypeName = "bit")]
        public bool HasHubOrderWithoutShipmentConflict { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerType { get; set; }


        public MultiSiteTenant MultiSiteTenant { get; set; } = new MultiSiteTenant();

        [Column(TypeName = "varchar(40)")]
        public string? CancelledDate { get; set; }


        public OrderWishlist Wishlist { get; set; } = new OrderWishlist();

        [Column(TypeName = "varchar(60)")]
        public string? WebSiteName { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerName { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerEmail { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerGender { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string? CustomerBirthDate { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerPhone { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string? CustomerCPF { get; set; }

        [Column(TypeName = "varchar(14)")]
        public string? CustomerCNPJ { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerTradingName { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? CustomerSiteTaxPayer { get; set; }


        public OrderPos Pos { get; set; }
    }
}
