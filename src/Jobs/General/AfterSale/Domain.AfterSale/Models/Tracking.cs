using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Tracking
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? courier_contract_id { get; set; }
        
        public decimal? shipping_amount { get; set; }
        public decimal? package_amount { get; set; }

        public bool? is_change_collect_to_post { get; set; }

        public string? type { get; set; }
        public string? qr_code { get; set; }
        public string? service_type { get; set; }
        public string? cte { get; set; }
        public string? delivery_deadline { get; set; }
        public string? extra_fields { get; set; }
        public string? authorization_code { get; set; }
        public string? tracking_code { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? courier_name { get; set; }
        public string? tracking_url { get; set; }

        public DateTime? expire_date { get; set; }
        public DateTime? collect_date { get; set; }
        public DateTime? requested_collect_date { get; set; }
        public DateTime? status_updated_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }

        [SkipProperty]
        public Reverse reverse { get; set; }

        public Tracking() 
        {
            id = 0;
            reverse_id = 0;
            courier_contract_id = 0;

            shipping_amount = 0;
            package_amount = 0;

            is_change_collect_to_post = false;

            type = String.Empty;
            qr_code = String.Empty;
            service_type = String.Empty;
            cte = String.Empty;
            delivery_deadline = String.Empty;
            extra_fields = String.Empty;
            authorization_code = String.Empty;
            tracking_code = String.Empty;
            status = String.Empty;
            message = String.Empty;
            courier_name = String.Empty;
            tracking_url = String.Empty;

            expire_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            collect_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            requested_collect_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            status_updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            deleted_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public Tracking(Dtos.Tracking tracking)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(tracking.id);
            reverse_id = CustomConvertersExtensions.ConvertToInt32Validation(tracking.reverse_id);
            courier_contract_id = CustomConvertersExtensions.ConvertToInt32Validation(tracking.courier_contract_id);

            shipping_amount = CustomConvertersExtensions.ConvertToDecimalValidation(tracking.shipping_amount);
            package_amount = CustomConvertersExtensions.ConvertToDecimalValidation(tracking?.package_amount);

            is_change_collect_to_post = CustomConvertersExtensions.ConvertToBooleanValidation(tracking.is_change_collect_to_post);

            expire_date = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking.expire_date);
            collect_date = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking.collect_date);
            requested_collect_date = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking?.requested_collect_date);
            status_updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking.status_updated_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(tracking?.deleted_at);

            type = tracking.type;
            qr_code = tracking.qr_code;
            service_type = tracking.service_type;
            cte = tracking.cte;
            delivery_deadline = tracking.delivery_deadline;
            extra_fields = tracking.extra_fields;
            authorization_code = tracking.authorization_code;
            tracking_code = tracking.tracking_code;
            status = tracking.status;
            message = tracking.message;
            courier_name = tracking.courier_name;
            tracking_url = tracking.tracking_url;
        }
    }
}
