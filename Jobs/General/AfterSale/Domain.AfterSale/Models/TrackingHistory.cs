using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class TrackingHistory
    {
        public int? id { get; set; }
        public int? tracking_id { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public DateTime? status_updated_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }

        public TrackingHistory() 
        {
            id = 0;
            tracking_id = 0;
            status = String.Empty;
            message = String.Empty;
            status_updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            created_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            deleted_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public TrackingHistory(Domain.AfterSale.Dtos.TrackingHistory trackingHistory)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(trackingHistory.id);
            tracking_id = CustomConvertersExtensions.ConvertToInt32Validation(trackingHistory?.tracking_id);

            status = trackingHistory?.status;
            message = trackingHistory?.message;

            status_updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(trackingHistory.status_updated_at);
            created_at = CustomConvertersExtensions.ConvertToDateTimeValidation(trackingHistory.created_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(trackingHistory.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(trackingHistory.deleted_at);
        }
    }
}
