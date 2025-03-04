using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderItem : IEquatable<OrderItem>
    {
        public Int64? OrderItemID { get; set; }
        public Guid? OrderID { get; set; }
        public Int32? ParentItemID { get; set; }
        public Int64? ProductID { get; set; }
        public Int32? SkuID { get; set; }
        public string? SKU { get; set; }
        public string? SellerSKU { get; set; }
        public Int32? WebSiteID { get; set; }
        public Int32? CatalogID { get; set; }
        public Int32? PriceListID { get; set; }
        public Int32? WareHouseID { get; set; }
        public string? WarehouseIntegrationID { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? TaxationAmount { get; set; }
        public decimal? SubtotalAdjustment { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public bool? IsFreeShipping { get; set; }
        public bool? IsDeleted { get; set; }
        public string? Status { get; set; }
        public string? ProductIntegrationID { get; set; }
        public string? SKUIntegrationID { get; set; }
        public Int32? CatalogItemType { get; set; }
        public bool? IsFreeOffer { get; set; }
        public bool? IsGiftWrapping { get; set; }
        public bool? IsService { get; set; }
        public Int32? SpecialType { get; set; }
        public string? BundlePriceType { get; set; }
        public string? BundleKitDiscount { get; set; }
        public decimal? BundleKitDiscountValue { get; set; }
        public Int32? InStockHandlingDays { get; set; }
        public Int32? OutStockHandlingDays { get; set; }
        public string? ProductName { get; set; }
        public string? SkuName { get; set; }
        public bool? IsDeliverable { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Depth { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public Guid? FulfillmentID { get; set; }
        public string? UPC { get; set; }

        public static List<OrderItem?> Compare(List<OrderItem?> orderItemsAPIList, List<OrderItem> orderItemsDboList)
        {
            try
            {
                foreach (var oItemDbo in orderItemsDboList)
                {
                    orderItemsAPIList.Remove(
                        orderItemsAPIList
                            .Where(oItemAPI =>
                                oItemAPI.CatalogID == oItemDbo.CatalogID &&
                                oItemAPI.CatalogItemType == oItemDbo.CatalogItemType &&
                                oItemAPI.DiscountAmount == oItemDbo.DiscountAmount &&
                                oItemAPI.InStockHandlingDays == oItemDbo.InStockHandlingDays &&
                                oItemAPI.IsDeleted == oItemDbo.IsDeleted &&
                                oItemAPI.IsDeliverable == oItemDbo.IsDeliverable &&
                                oItemAPI.IsFreeOffer == oItemDbo.IsFreeOffer &&
                                oItemAPI.IsFreeShipping == oItemDbo.IsFreeShipping &&
                                oItemAPI.IsGiftWrapping == oItemDbo.IsGiftWrapping &&
                                oItemAPI.IsService == oItemDbo.IsService &&
                                oItemAPI.OrderID == oItemDbo.OrderID &&
                                oItemAPI.OrderItemID == oItemDbo.OrderItemID &&
                                oItemAPI.OutStockHandlingDays == oItemDbo.OutStockHandlingDays &&
                                oItemAPI.Price == oItemDbo.Price &&
                                oItemAPI.PriceListID == oItemDbo.PriceListID &&
                                oItemAPI.ProductID == oItemDbo.ProductID &&
                                oItemAPI.Qty == oItemDbo.Qty &&
                                oItemAPI.SkuID == oItemDbo.SkuID &&
                                oItemAPI.SpecialType == oItemDbo.SpecialType &&
                                oItemAPI.Subtotal == oItemDbo.Subtotal &&
                                oItemAPI.SubtotalAdjustment == oItemDbo.SubtotalAdjustment &&
                                oItemAPI.TaxationAmount == oItemDbo.TaxationAmount &&
                                oItemAPI.Total == oItemDbo.Total &&
                                oItemAPI.WareHouseID == oItemDbo.WareHouseID &&
                                oItemAPI.WebSiteID == oItemDbo.WebSiteID
                            ).FirstOrDefault()
                    );
                }

                return orderItemsAPIList;
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

        public bool Equals(OrderItem? other)
        {
            return
                this.CatalogID == other.CatalogID &&
                this.CatalogItemType == other.CatalogItemType &&
                this.DiscountAmount == other.DiscountAmount &&
                this.InStockHandlingDays == other.InStockHandlingDays &&
                this.IsDeleted == other.IsDeleted &&
                this.IsDeliverable == other.IsDeliverable &&
                this.IsFreeOffer == other.IsFreeOffer &&
                this.IsFreeShipping == other.IsFreeShipping &&
                this.IsGiftWrapping == other.IsGiftWrapping &&
                this.IsService == other.IsService &&
                this.OrderID == other.OrderID &&
                this.OrderItemID == other.OrderItemID &&
                this.OutStockHandlingDays == other.OutStockHandlingDays &&
                this.Price == other.Price &&
                this.PriceListID == other.PriceListID &&
                this.ProductID == other.ProductID &&
                this.Qty == other.Qty &&
                this.SkuID == other.SkuID &&
                this.SpecialType == other.SpecialType &&
                this.Subtotal == other.Subtotal &&
                this.SubtotalAdjustment == other.SubtotalAdjustment &&
                this.TaxationAmount == other.TaxationAmount &&
                this.Total == other.Total &&
                this.WareHouseID == other.WareHouseID &&
                this.WebSiteID == other.WebSiteID;
        }
    }
}
