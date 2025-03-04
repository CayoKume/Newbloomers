using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;
using Domain.LinxCommerce.Entities.Responses;
using Domain.LinxCommerce.Entities.SalesRepresentative;
using System.Collections.Generic;

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
            public Dictionary<string, string> Responses { get; set; } = new Dictionary<string, string>();

            public static void Compare(List<SearchOrder.Result?> ordersAPIList, List<Domain.LinxCommerce.Entities.Order.Order.Root> ordersDboList)
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
                                        oAPI.WebSiteID == oDbo.WebSiteID &&
                                        oAPI.CustomerID == oDbo.CustomerID &&
                                        oAPI.ItemsQty == oDbo.ItemsQty &&
                                        oAPI.ItemsCount == oDbo.ItemsCount &&
                                        oAPI.TaxAmount == oDbo.TaxAmount &&
                                        oAPI.DeliveryAmount == oDbo.DeliveryAmount &&
                                        oAPI.DiscountAmount == oDbo.DiscountAmount &&
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
                                        oAPI.TrafficSourceID == oDbo.TrafficSourceID &&
                                        oAPI.OrderStatusID == oDbo.OrderStatusID &&
                                        oAPI.CreatedDate == oDbo.CreatedDate &&
                                        oAPI.HasConflicts == oDbo.HasConflicts &&
                                        oAPI.AcquiredDate == oDbo.AcquiredDate &&
                                        oAPI.CancelledDate == oDbo.CancelledDate &&
                                        oAPI.OrderInvoice == oDbo.OrderInvoice &&

                                        oAPI.Items.All(x => oDbo.Items.Contains(x)) &&
                                        oAPI.Addresses.All(x => oDbo.Addresses.Contains(x)) &&
                                        oAPI.DeliveryMethods.All(x => oDbo.DeliveryMethods.Contains(x)) &&
                                        oAPI.PaymentMethods.All(x => oDbo.PaymentMethods.Contains(x))

                                    ).FirstOrDefault()
                            );

                            if (oAPI.Items.Count() > 0 && oDbo.Items.Count() > 0)
                                oAPI.Items = OrderItem.Compare(oAPI.Items, oDbo.Items);

                            if (oAPI.Addresses.Count() > 0 && oDbo.Addresses.Count() > 0)
                                oAPI.Addresses = OrderAddress.Compare(oAPI.Addresses, oDbo.Addresses);

                            if (oAPI.DeliveryMethods.Count() > 0 && oDbo.DeliveryMethods.Count() > 0)
                                oAPI.DeliveryMethods = OrderDeliveryMethod.Compare(oAPI.DeliveryMethods, oDbo.DeliveryMethods);

                            if (oAPI.PaymentMethods.Count() > 0 && oDbo.PaymentMethods.Count() > 0)
                                oAPI.PaymentMethods = OrderPaymentMethod.Compare(oAPI.PaymentMethods, oDbo.PaymentMethods);

                            oDbo.Items.AddRange(oAPI.Items);
                            oDbo.Addresses.AddRange(oAPI.Addresses);
                            oDbo.DeliveryMethods.AddRange(oAPI.DeliveryMethods);
                            oDbo.PaymentMethods.AddRange(oAPI.PaymentMethods);
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
