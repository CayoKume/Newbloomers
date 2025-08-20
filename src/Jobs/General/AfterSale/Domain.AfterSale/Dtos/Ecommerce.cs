namespace Domain.AfterSale.Dtos
{
    public class Ecommerce
    {
        public string? id { get; set; }
        public string? uuid { get; set; }
        public string? ecommerce_group_id { get; set; }
        public string? company_name { get; set; }
        public string? trade_name { get; set; }
        public string? display_name { get; set; }
        public string? url { get; set; }
        public string? is_active { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? document { get; set; }
        public string? address_id { get; set; }
        public string? maintenance_mode_global { get; set; }
        public string? last_order_report_date { get; set; }
        public string? is_test { get; set; }
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
