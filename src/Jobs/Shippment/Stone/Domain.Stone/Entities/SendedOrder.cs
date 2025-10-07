using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Stone.Entities
{
    public class SendedOrder
    {
        public DateTime? lastupdateon { get; set; }
        public string? orderNumber { get; set; }
        public Guid? id { get; set; }
        public DateTime? createdAt { get; set; }
        public int? eta { get; set; }
        public int? slaWorkingDays { get; set; }
        public string? service { get; set; }
        public Int64? expiresAt { get; set; }
        public Guid? deliveryRequestId { get; set; }
        public decimal? cost { get; set; }
        public string? classification { get; set; }

        [SkipProperty]
        [NotMapped]
        public Error err { get; set; } = new Error();

        [SkipProperty]
        [NotMapped]
        public Dictionary<string?, string> Responses { get; set; } = new Dictionary<string?, string>();

        public SendedOrder(Domain.Stone.Dtos.SendedOrderResponse sendedOrder, string orderNumber, string request)
        {
            this.lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.orderNumber = orderNumber;
            this.id = sendedOrder.id;
            this.createdAt = sendedOrder.createdAt;
            this.eta = sendedOrder.eta;
            this.slaWorkingDays = sendedOrder.slaWorkingDays;
            this.service = sendedOrder.service;
            this.expiresAt = sendedOrder.expiresAt;
            this.deliveryRequestId = sendedOrder.deliveryRequestId;
            this.cost = sendedOrder.cost;
            this.classification = sendedOrder.classification;
            this.Responses.Add(orderNumber, request);
        }

        public SendedOrder(string orderNumber, string request, string message, string error)
        {
            this.lastupdateon = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            this.orderNumber = orderNumber;
            this.id = null;
            this.createdAt = null;
            this.eta = null;
            this.slaWorkingDays = null;
            this.service = null;
            this.expiresAt = null;
            this.deliveryRequestId = null;
            this.cost = null;
            this.classification = null;
            this.Responses.Add(orderNumber, request);
            this.err = System.String.IsNullOrEmpty(message) && System.String.IsNullOrEmpty(error) ? new Error() : new Error(orderNumber, message, error);
        }
    }
}
