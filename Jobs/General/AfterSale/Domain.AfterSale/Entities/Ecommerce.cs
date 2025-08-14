using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Entities
{
    public class Ecommerce
    {
        public Int32? id { get; set; }
        public Guid? uuid { get; set; }
        public Int32? ecommerce_group_id { get; set; }
        public string? company_name { get; set; }
        public string? trade_name { get; set; }
        public string? display_name { get; set; }
        public string? url { get; set; }
        public bool? is_active { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? document { get; set; }
        public Int32? address_id { get; set; }
        public bool? maintenance_mode_global { get; set; }
        public DateTime? last_order_report_date { get; set; }
        public bool? is_test { get; set; }
        public string? segment { get; set; }
        public string? oauth_client_id { get; set; }
        public string? provider_id { get; set; }
        public string? registration_origin { get; set; }
        public string? brand_id { get; set; }
        public string? app_name { get; set; }

        public Address address { get; set; }

        public List<Reason> reasons { get; set; }
    }
}
