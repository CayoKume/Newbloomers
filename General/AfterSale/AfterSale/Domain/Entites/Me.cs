namespace AfterSale.Domain.Entites.Me
{
    public class Me
    {
        public bool success { get; set; }
        public Ecommerce ecommerce { get; set; }
    }

    public class Ecommerce
    {
        public int id { get; set; }
        public string? uuid { get; set; }
        public string? company_name { get; set; }
        public string? trade_name { get; set; }
        public string? display_name { get; set; }
        public string? url { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? document { get; set; }
        public int address_id { get; set; }
        public bool maintenance_mode_global { get; set; }
        public Messages messages { get; set; }
    }

    public class Messages
    {
        public Pages pages { get; set; }
        public Mails mails { get; set; }
        public Shortcodes shortcodes { get; set; }
        public string? app_name { get; set; }
        public bool deny_search_index { get; set; }
        public string? theme { get; set; }
        public Stylesheet stylesheet { get; set; }
        public string? terms { get; set; }
        public string? limit_value_collect { get; set; }
        public bool collect_enabled { get; set; }
        public bool has_ecommerce_integration { get; set; }
        public bool has_info_by_customer_enabled { get; set; }
        public string? field_order_id_label { get; set; }
        public string? field_order_id_placeholder { get; set; }
        public string? field_product_comment_label { get; set; }
        public string? field_product_comment_placeholder { get; set; }
        public string? field_confirmation_label { get; set; }
        public string? field_confirmation_placeholder { get; set; }
        public string? field_confirmation_type { get; set; }
        public bool hotjar_enabled { get; set; }
        public string? hotjar_id { get; set; }
        public string? retention_method { get; set; }
        public bool retention_free_shipping { get; set; }
        public bool product_comment_required { get; set; }
        public Localization localization { get; set; }
        public bool show_quick_selection { get; set; }
        public bool maintenance_mode { get; set; }
        public Modules modules { get; set; }
        public string?[] enabled_reverse_types { get; set; }
        public bool could_be_retained { get; set; }
        public bool cashback_allow_third_party { get; set; }
        public bool show_product_images { get; set; }
        public Reason[] reason { get; set; }
    }

    public class Pages
    {
        public Introduction introduction { get; set; }
        public SelectSource select_source { get; set; }
        public Order order { get; set; }
        public Products products { get; set; }
        public OptionalCommentary optional_commentary { get; set; }
        public Shipping shipping { get; set; }
        public Resume resume { get; set; }
        public Finish finish { get; set; }
        public Customer customer { get; set; }
        public CustomerProducts customer_products { get; set; }
        public Seller seller { get; set; }
        public EmailByCustomer email_by_customer { get; set; }
    }

    public class Mails
    {
        public string? greeting { get; set; }
        public string? footer { get; set; }
        public Reverse reverse { get; set; }
        public Refund refund { get; set; }
        public Partials partials { get; set; }
    }

    public class Shortcodes
    {
        public string? app_name { get; set; }
        public string? ecommerce_name { get; set; }
        public string? ecommerce_phone { get; set; }
        public string? ecommerce_url { get; set; }
        public string? ecommerce_logo_url { get; set; }
        public string? ecommerce_logo_email_url { get; set; }
        public string? ecommerce_display_name { get; set; }
    }

    public class Stylesheet
    {
        public string? description { get; set; }
    }

    public class Localization
    {
        public string? language { get; set; }
        public string? timezone { get; set; }
        public string? currency { get; set; }
    }

    public class Modules
    {
        public string?[] app { get; set; }
        public string?[] care { get; set; }
        public string?[] logistic { get; set; }
        public string?[] loyalty { get; set; }
        public string?[] money { get; set; }
        public string?[] omnichannel { get; set; }
        public string?[] retention { get; set; }
        public string?[] whitelabel { get; set; }
    }

    public class Reason
    {
        public int id { get; set; }
        public int ecommerce_id { get; set; }
        public string? description { get; set; }
        public string? reason_category_id { get; set; }
        public string? action { get; set; }
        public bool should_approve { get; set; }
        public string? upload_image { get; set; }
        public bool show_product_grid { get; set; }
        public string? ord { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? deleted_at { get; set; }
    }

    public class Introduction
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class SelectSource
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Order
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Products
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class OptionalCommentary
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Shipping
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Resume
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Finish
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Customer
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class CustomerProducts
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Seller
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class EmailByCustomer
    {
        public string? title { get; set; }
        public string? description { get; set; }
    }

    public class Reverse
    {
        public Send4CodeGenerated send4_code_generated { get; set; }
        public CorreioCodeGenerated correio_code_generated { get; set; }
        public CourierCollectCodeGenerated courier_collect_code_generated { get; set; }
        public CorreioCodeExpiring correio_code_expiring { get; set; }
        public CorreioCollectChangeToPost correio_collect_change_to_post { get; set; }
        public CorreioTrackingPosted correio_tracking_posted { get; set; }
        public CorreioTrackingDelivered correio_tracking_delivered { get; set; }
        public EcommerceStoreReverse ecommerce_store_reverse { get; set; }
        public ProductsReceived products_received { get; set; }
        public ReverseRefused reverse_refused { get; set; }
        public ReverseCanceled reverse_canceled { get; set; }
        public AwaitingWithoutProcess awaiting_without_process { get; set; }
    }

    public class Send4CodeGenerated
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CorreioCodeGenerated
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CourierCollectCodeGenerated
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CorreioCodeExpiring
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CorreioCollectChangeToPost
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CorreioTrackingPosted
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class CorreioTrackingDelivered
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class EcommerceStoreReverse
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class ProductsReceived
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class ReverseRefused
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class ReverseCanceled
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class AwaitingWithoutProcess
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class Refund
    {
        public Approved approved { get; set; }
        public PaidRefund paid_refund { get; set; }
        public PaidWireTransfer paid_wire_transfer { get; set; }
        public PaidProduct paid_product { get; set; }
        public PaidVoucher paid_voucher { get; set; }
        public PaidCredit paid_credit { get; set; }
        public AskWireTransferData ask_wire_transfer_data { get; set; }
        public PaidHardRetention paid_hard_retention { get; set; }
    }

    public class Approved
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidRefund
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidWireTransfer
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidProduct
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidVoucher
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidCredit
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class AskWireTransferData
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class PaidHardRetention
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }

    public class Partials
    {
        public string? partially_received_warning { get; set; }
    }
}
