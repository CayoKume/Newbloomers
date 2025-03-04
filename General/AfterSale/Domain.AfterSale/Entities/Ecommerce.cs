namespace Domain.AfterSale.Entities
{
    public class Ecommerce
    {
        public Int32? id { get; set; }
        public Guid? uuid { get; set; }
        public string? ecommerce_group_id { get; set; }
        public string? hubspot_code { get; set; }
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
        public Messages? messages { get; set; }
    }

    public class Messages
    {
        public Pages? pages { get; set; }
        public Mails? mails { get; set; }
        public Shortcodes? shortcodes { get; set; }
        public string? app_name { get; set; }
        public bool? deny_search_index { get; set; }
        public string? theme { get; set; }
        //public Stylesheet stylesheet { get; set; }
        public string? terms { get; set; }
        public string? limit_value_collect { get; set; }
        public bool? collect_enabled { get; set; }
        public bool? has_ecommerce_integration { get; set; }
        public bool? has_info_by_customer_enabled { get; set; }
        public string? field_order_id_label { get; set; }
        public string? field_order_id_placeholder { get; set; }
        public string? field_product_comment_label { get; set; }
        public string? field_product_comment_placeholder { get; set; }
        public string? field_confirmation_label { get; set; }
        public string? field_confirmation_placeholder { get; set; }
        public string? field_confirmation_type { get; set; }
        public bool? hotjar_enabled { get; set; }
        public string? hotjar_id { get; set; }
        public string? retention_method { get; set; }
        public bool? retention_free_shipping { get; set; }
        public bool? product_comment_required { get; set; }
        public Localization? localization { get; set; }
        public bool? show_quick_selection { get; set; }
        public bool? maintenance_mode { get; set; }
        public Modules? modules { get; set; }
        public string?[] enabled_reverse_types { get; set; }
        public bool? could_be_retained { get; set; }
        public bool? cashback_allow_third_party { get; set; }
        public bool? show_product_images { get; set; }
        public Reason[] reason { get; set; }
    }
}
