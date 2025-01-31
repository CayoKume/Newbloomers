using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderItem
    {
        [Key]
        [Column(TypeName = "int")]
        public int? OrderItemID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? OrderID { get; set; }

        [Column(TypeName = "int")]
        public int? ParentItemID { get; set; }

        [Column(TypeName = "int")]
        public int? ProductID { get; set; }

        [Column(TypeName = "int")]
        public int? SkuID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? SKU { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? SellerSKU { get; set; }

        [Column(TypeName = "int")]
        public int? WebSiteID { get; set; }

        [Column(TypeName = "int")]
        public int? CatalogID { get; set; }

        [Column(TypeName = "int")]
        public int? PriceListID { get; set; }

        [Column(TypeName = "int")]
        public int? WareHouseID { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? WarehouseIntegrationID { get; set; }

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

        public string? BundlePriceType { get; set; }


        public string? BundleKitDiscount { get; set; }


        public decimal? BundleKitDiscountValue { get; set; }


        public int? InStockHandlingDays { get; set; }


        public int? OutStockHandlingDays { get; set; }


        public string? ProductName { get; set; }


        public string? SkuName { get; set; }


        public bool? IsDeliverable { get; set; }


        public decimal? Weight { get; set; }


        public decimal? Depth { get; set; }


        public decimal? Height { get; set; }


        public decimal? Width { get; set; }


        public string? FulfillmentID { get; set; }


        public string? UPC { get; set; }
    }
}
