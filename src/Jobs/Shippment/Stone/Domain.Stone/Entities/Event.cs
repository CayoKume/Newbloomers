using Domain.Core.Extensions;

namespace Domain.Stone.Entities
{
    public class Event
    {
        public Guid eventId { get; set; }
        public Guid orderId { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public string modifiedBy { get; set; }
        public string trackingCode { get; set; }
        public string carrierName { get; set; }
        public string carrierService { get; set; }
        public string description { get; set; }

        public Event() { }

        public Event(Dtos.Event @event, string orderId)
        {
            this.orderId = CustomConvertersExtensions.ConvertToGuidValidation(orderId);
            this.eventId = CustomConvertersExtensions.ConvertToGuidValidation(@event.id);
            this.status = @event.status;
            this.createdAt = CustomConvertersExtensions.ConvertToDateTimeValidation(@event.createdAt);
            this.modifiedBy = @event.modifiedBy;
            this.trackingCode = @event.trackingCode;
            this.carrierName = @event.carrier?.name;
            this.carrierService = @event.carrier?.service;
            this.description = @event.description;
        }
    }
}
