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
            this.status = CustomConvertersExtensions.StringLengthValidation(@event.status, 60);
            this.createdAt = CustomConvertersExtensions.ConvertToDateTimeValidation(@event.createdAt);
            this.modifiedBy = CustomConvertersExtensions.StringLengthValidation(@event.modifiedBy, 60);
            this.trackingCode = CustomConvertersExtensions.StringLengthValidation(@event.trackingCode, 60);
            this.carrierName = CustomConvertersExtensions.StringLengthValidation(@event.carrier?.name, 60);
            this.carrierService = CustomConvertersExtensions.StringLengthValidation(@event.carrier?.service, 60);
            this.description = CustomConvertersExtensions.StringLengthValidation(@event.description, 300);
        }
    }
}
