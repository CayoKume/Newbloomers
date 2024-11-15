using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.LinxCommerce.Entities.Sales.Order
{
    public class OrderItem
    {
        [Key]
        [Column(TypeName = "int")]
        public Int32? OrderItemID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? OrderID { get; set; }

        [Column(TypeName = "int")]
        public Int32? ParentItemID { get; set; }

        [Column(TypeName = "int")]
        public Int32? ProductID { get; set; }

        [Column(TypeName = "int")]
        public Int32? SkuID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? SKU { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? SellerSKU { get; set; }

        [Column(TypeName = "int")]
        public Int32? WebSiteID { get; set; }

        [Column(TypeName = "int")]
        public Int32? CatalogID { get; set; }

        [Column(TypeName = "int")]
        public Int32? PriceListID { get; set; }

        [Column(TypeName = "int")]
        public Int32? WareHouseID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? WarehouseIntegrationID { get; set; }


        public List<OrderItemWarehouse> Warehouses { get; set; } = new List<OrderItemWarehouse>();


        public decimal? Qty { get; set; }


        public decimal? Price { get; set; }


        public decimal? DiscountAmount { get; set; }


        public decimal? TaxationAmount { get; set; }


        public decimal? Subtotal { get; set; }


        public decimal? Total { get; set; }


        public bool? IsFreeShipping { get; set; }


        public bool? IsDeleted { get; set; }


        public string? Status { get; set; }


        public string? ProductIntegrationID { get; set; }


        public string? SKUIntegrationID { get; set; }


        public string? CatalogItemType { get; set; }


        public bool? IsFreeOffer { get; set; }


        public bool? IsGiftWrapping { get; set; }


        public bool? IsService { get; set; }


        public string? SpecialType { get; set; }


        public List<OrderItemProperty> Properties { get; set; } = new List<OrderItemProperty>();


        public List<OrderItemFormData> FormData { get; set; } = new List<OrderItemFormData>();


        public string? BundlePriceType { get; set; }


        public string? BundleKitDiscount { get; set; }


        public decimal? BundleKitDiscountValue { get; set; }


        public Int32? InStockHandlingDays { get; set; }


        public Int32? OutStockHandlingDays { get; set; }


        public string? ProductName { get; set; }


        public string? SkuName { get; set; }


        public bool? IsDeliverable { get; set; }


        public List<OrderItemSerial> SerialKey { get; set; } = new List<OrderItemSerial>();


        public decimal? Weight { get; set; }


        public decimal? Depth { get; set; }


        public decimal? Height { get; set; }


        public decimal? Width { get; set; }


        public OrderItemExternalInfo ExternalInfo { get; set; } = new OrderItemExternalInfo();


        public string? FulfillmentID { get; set; }


        public string? UPC { get; set; }
    }
}
