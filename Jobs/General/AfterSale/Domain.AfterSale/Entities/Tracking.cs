using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Entities
{
    public class Tracking
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? courier_contract_id { get; set; }
        public string? authorization_code { get; set; }
        public string? tracking_code { get; set; }
        public decimal? shipping_amount { get; set; }
        public decimal? package_amount { get; set; }
        public string? courier_name { get; set; }
        public string? tracking_url { get; set; }
        public DateTime? expire_date { get; set; }
        public DateTime? collect_date { get; set; }
        public DateTime? requested_collect_date { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public DateTime? status_updated_at { get; set; }
        public bool? is_change_collect_to_post { get; set; }
        public string? type { get; set; }
        public string? qr_code { get; set; }
        public string? service_type { get; set; }
        public string? cte { get; set; }
        public string? delivery_deadline { get; set; }
        public string? extra_fields { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }

        [NotMapped]
        [SkipProperty]
        public Reverse reverse { get; set; }
    }
}
