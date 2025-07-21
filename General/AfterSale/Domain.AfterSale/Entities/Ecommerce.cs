using Domain.IntegrationsCore.Extensions;
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

        [SkipProperty]
        [NotMapped]
        public Dictionary<Guid?, string> Responses { get; set; } = new Dictionary<Guid?, string>();

        [SkipProperty]
        public Address address { get; set; }

        [SkipProperty]
        public List<Reason> reasons { get; set; }

        public Ecommerce() { }

        public Ecommerce(Ecommerce ecommerce, string json)
        {
            id = ecommerce.id;
            uuid = ecommerce.uuid;
            ecommerce_group_id = ecommerce.ecommerce_group_id;
            company_name = ecommerce.company_name;
            trade_name = ecommerce.trade_name;
            display_name = ecommerce.display_name;
            url = ecommerce.url;
            is_active = ecommerce.is_active;
            phone = ecommerce.phone;
            email = ecommerce.email;
            document = ecommerce.document;
            address_id = ecommerce.address_id;
            maintenance_mode_global = ecommerce.maintenance_mode_global;
            last_order_report_date = ecommerce.last_order_report_date;
            is_test = ecommerce.is_test;
            segment = ecommerce.segment;
            oauth_client_id = ecommerce.oauth_client_id;
            provider_id = ecommerce.provider_id;
            registration_origin = ecommerce.registration_origin;
            brand_id = ecommerce.brand_id;
            app_name = ecommerce.app_name;
            address = ecommerce.address;
            reasons = ecommerce.reasons;

            Responses.Add(ecommerce.uuid, json);
        }
    }
}
