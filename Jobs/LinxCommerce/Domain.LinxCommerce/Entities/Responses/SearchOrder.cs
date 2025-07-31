using Domain.Core.Extensions;
using Domain.LinxCommerce.Entities.Order;
using Domain.LinxCommerce.Entities.Parameters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.LinxCommerce.Entities.Responses
{
    public class SearchOrder
    {
        public class Root
        {
            public Page Page { get; set; }
            public List<Result> Result { get; set; }

            //public static void BuildRecordKey(List<Result> result)
            //{
            //    result.ForEach(s =>
            //        s.RecordKey = $"[{s.OrderID}]|[{s.ModifiedDate}]"
            //    );
            //}
        }

        public class Result
        {
            public DateTime? AcquiredDate { get; set; }
            public DateTime? CancelledDate { get; set; }
            public DateTime? CreatedDate { get; set; }
            public int? CustomerID { get; set; }
            public decimal? DeliveryAmount { get; set; }
            public decimal? DiscountAmount { get; set; }
            public string? GlobalStatus { get; set; }
            public bool? HasConflicts { get; set; }
            public int? ItemsCount { get; set; }
            public decimal? ItemsQty { get; set; }
            public string? MarketPlaceBrand { get; set; }
            public DateTime? ModifiedDate { get; set; }
            public Guid? OrderID { get; set; }
            public string? OrderNumber { get; set; }
            public int? OrderStatusID { get; set; }
            public DateTime? PaymentDate { get; set; }
            public string? PaymentStatus { get; set; }
            public DateTime? ShipmentDate { get; set; }
            public string? ShipmentStatus { get; set; }
            public decimal? SubTotal { get; set; }
            public decimal? TaxAmount { get; set; }
            public decimal? Total { get; set; }
            public decimal? TotalDue { get; set; }
            public decimal? TotalPaid { get; set; }
            public decimal? TotalRefunded { get; set; }
            public int? TrafficSourceID { get; set; }
            public int? WebSiteID { get; set; }

            public List<OrderItem> Items { get; set; }

            public List<OrderTag> Tags { get; set; }

            public List<OrderAddress> Addresses { get; set; }

            public List<OrderPaymentMethod> PaymentMethods { get; set; }

            public List<OrderDeliveryMethod> DeliveryMethods { get; set; }

            public List<OrderDiscount> Discounts { get; set; }

            public List<OrderShipment> Shipments { get; set; }

            public OrderInvoice OrderInvoice { get; set; }
        }
    }
}
