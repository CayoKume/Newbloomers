using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;
using Domain.LinxCommerce.Entities.SalesRepresentative;

namespace Domain.LinxCommerce.Entities.Order
{
    public class Order
    {
        public class Root
        {
            public Guid? OrderID { get; set; }
            public string? OrderNumber { get; set; }
            public string? MarketPlaceBrand { get; set; }
            public Guid? OriginalOrderID { get; set; }
            public int? WebSiteID { get; set; }
            public string? WebSiteIntegrationID { get; set; }
            public int? CustomerID { get; set; }
            public Guid? ShopperTicketID { get; set; }
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
            public Guid? OrderGroupID { get; set; }
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
            public List<OrderItem> Items { get; set; } = new List<OrderItem>();

            [SkipProperty]
            public List<OrderTag> Tags { get; set; } = new List<OrderTag>();
            
            [SkipProperty]
            public List<OrderAddress> Addresses { get; set; } = new List<OrderAddress>();
            
            [SkipProperty]
            public List<OrderPaymentMethod> PaymentMethods { get; set; } = new List<OrderPaymentMethod>();
            
            [SkipProperty]
            public List<OrderDeliveryMethod> DeliveryMethods { get; set; } = new List<OrderDeliveryMethod>();
            
            [SkipProperty]
            public List<OrderDiscount> Discounts { get; set; } = new List<OrderDiscount>();

            [SkipProperty]
            public List<OrderShipment> Shipments { get; set; } = new List<OrderShipment>();
            
            [SkipProperty]
            public OrderInvoice OrderInvoice { get; set; }

            [SkipProperty]
            public Dictionary<int, string> Responses { get; set; } = new Dictionary<int, string>();

            public static void Compare(List<Order.Root?> ordersAPIList, List<Order.Root> ordersDboList)
            {
                if (ordersDboList.Count() > 0)
                {
                    foreach (var oDbo in ordersDboList)
                    {
                        try
                        {
                            var oAPI = ordersAPIList
                                        .Where(oAPI =>
                                            oAPI.OrderID == oDbo.OrderID
                                        ).FirstOrDefault();

                            ordersAPIList.Remove(
                                ordersAPIList
                                    .Where(oAPI =>
                                        oAPI.OrderID == oDbo.OrderID &&
                                        oAPI.OrderNumber == oDbo.OrderNumber &&
                                        oAPI.MarketPlaceBrand == oDbo.MarketPlaceBrand &&
                                        oAPI.OriginalOrderID == oDbo.OriginalOrderID &&
                                        oAPI.WebSiteID == oDbo.WebSiteID &&
                                        oAPI.WebSiteIntegrationID == oDbo.WebSiteIntegrationID &&
                                        oAPI.CustomerID == oDbo.CustomerID &&
                                        oAPI.ShopperTicketID == oDbo.ShopperTicketID &&
                                        oAPI.ItemsQty == oDbo.ItemsQty &&
                                        oAPI.ItemsCount == oDbo.ItemsCount &&
                                        oAPI.TaxAmount == oDbo.TaxAmount &&
                                        oAPI.DeliveryAmount == oDbo.DeliveryAmount &&
                                        oAPI.DiscountAmount == oDbo.DiscountAmount &&
                                        oAPI.PaymentTaxAmount == oDbo.PaymentTaxAmount &&
                                        oAPI.SubTotal == oDbo.SubTotal &&
                                        oAPI.Total == oDbo.Total &&
                                        oAPI.TotalDue == oDbo.TotalDue &&
                                        oAPI.TotalPaid == oDbo.TotalPaid &&
                                        oAPI.TotalRefunded == oDbo.TotalRefunded &&
                                        oAPI.PaymentDate == oDbo.PaymentDate &&
                                        oAPI.PaymentStatus == oDbo.PaymentStatus &&
                                        oAPI.ShipmentDate == oDbo.ShipmentDate &&
                                        oAPI.ShipmentStatus == oDbo.ShipmentStatus &&
                                        oAPI.GlobalStatus == oDbo.GlobalStatus &&
                                        oAPI.DeliveryPostalCode == oDbo.DeliveryPostalCode &&
                                        oAPI.CreatedChannel == oDbo.CreatedChannel &&
                                        oAPI.TrafficSourceID == oDbo.TrafficSourceID &&
                                        oAPI.OrderStatusID == oDbo.OrderStatusID &&
                                        oAPI.CreatedDate == oDbo.CreatedDate &&
                                        oAPI.CreatedBy == oDbo.CreatedBy &&
                                        oAPI.ModifiedDate == oDbo.ModifiedDate &&
                                        oAPI.ModifiedBy == oDbo.ModifiedBy &&
                                        oAPI.Remarks == oDbo.Remarks &&
                                        oAPI.SellerCommissionAmount == oDbo.SellerCommissionAmount &&
                                        oAPI.CommissionAmount == oDbo.CommissionAmount &&
                                        oAPI.OrderGroupID == oDbo.OrderGroupID &&
                                        oAPI.OrderGroupNumber == oDbo.OrderGroupNumber &&
                                        oAPI.HasConflicts == oDbo.HasConflicts &&
                                        oAPI.AcquiredDate == oDbo.AcquiredDate &&
                                        oAPI.HasHubOrderWithoutShipmentConflict == oDbo.HasHubOrderWithoutShipmentConflict &&
                                        oAPI.CustomerType == oDbo.CustomerType &&
                                        oAPI.CancelledDate == oDbo.CancelledDate &&
                                        oAPI.WebSiteName == oDbo.WebSiteName &&
                                        oAPI.CustomerName == oDbo.CustomerName &&
                                        oAPI.CustomerEmail == oDbo.CustomerEmail &&
                                        oAPI.CustomerGender == oDbo.CustomerGender &&
                                        oAPI.CustomerBirthDate == oDbo.CustomerBirthDate &&
                                        oAPI.CustomerPhone == oDbo.CustomerPhone &&
                                        oAPI.CustomerPhone == oDbo.CustomerPhone &&
                                        oAPI.CustomerCPF == oDbo.CustomerCPF &&
                                        oAPI.CustomerCNPJ == oDbo.CustomerCNPJ &&
                                        oAPI.CustomerTradingName == oDbo.CustomerTradingName &&
                                        oAPI.CustomerSiteTaxPayer == oDbo.CustomerSiteTaxPayer &&

                                        oAPI.OrderInvoice == oDbo.OrderInvoice &&

                                        oAPI.Addresses.All(x => oDbo.Addresses.Contains(x)) &&
                                    ).FirstOrDefault()
                            );

                            if (sAPI.Addresses.Count() > 0 && sDbo.Addresses.Count() > 0)
                                sAPI.Addresses = SalesRepresentativeAddress.Compare(sAPI.Addresses, sDbo.Addresses);

                            if (sAPI.Portfolio != null && sDbo.Portfolio != null)
                                sAPI.Portfolio.Customers = SalesRepresentativeCustomerRelation.Compare(sAPI.Portfolio.Customers, sDbo.Portfolio.Customers);

                            sDbo.Addresses.AddRange(sAPI.Addresses);
                            sDbo.Portfolio.Customers.AddRange(sAPI.Portfolio.Customers);
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
                }
            }
        }
    }
}
