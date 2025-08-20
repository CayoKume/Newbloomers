using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class StatusHistories
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? status_id { get; set; }
        public int? user_id { get; set; }
        public int? customer_id { get; set; }
        public DateTime? date { get; set; }
        public string? comments { get; set; }
        public Status status { get; set; }

        public StatusHistories() 
        {
            id = 0;
            reverse_id = 0;
            status_id = 0;
            user_id = 0;
            customer_id = 0;
            date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            comments = String.Empty;
            status = new Status();
        }

        public StatusHistories(Dtos.StatusHistories statusHistories)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(statusHistories.id);
            reverse_id = CustomConvertersExtensions.ConvertToInt32Validation(statusHistories.reverse_id);
            status_id = CustomConvertersExtensions.ConvertToInt32Validation(statusHistories.status_id);
            user_id = CustomConvertersExtensions.ConvertToInt32Validation(statusHistories.user_id);
            customer_id = CustomConvertersExtensions.ConvertToInt32Validation(statusHistories?.customer_id);
            date = CustomConvertersExtensions.ConvertToDateTimeValidation(statusHistories.date);
            comments = statusHistories.comments;

            status = statusHistories.status != null ? new Status(statusHistories.status) : new Status();
        }
    }
}
