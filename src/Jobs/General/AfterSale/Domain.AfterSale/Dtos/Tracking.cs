using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Dtos
{
    public class Tracking
    {
        public string? id { get; set; }
        public string? reverse_id { get; set; }
        public string? courier_contract_id { get; set; }
        public string? authorization_code { get; set; }
        public string? tracking_code { get; set; }
        public string? shipping_amount { get; set; }
        public string? package_amount { get; set; }
        public string? courier_name { get; set; }
        public string? tracking_url { get; set; }
        public string? expire_date { get; set; }
        public string? collect_date { get; set; }
        public string? requested_collect_date { get; set; }
        public string? status { get; set; }
        public string? message { get; set; }
        public string? status_updated_at { get; set; }
        public string? is_change_collect_to_post { get; set; }
        public string? type { get; set; }
        public string? qr_code { get; set; }
        public string? service_type { get; set; }
        public string? cte { get; set; }
        public string? delivery_deadline { get; set; }
        public string? extra_fields { get; set; }
        public string? updated_at { get; set; }
        public string? deleted_at { get; set; }

        public Reverse reverse { get; set; }
    }
}
