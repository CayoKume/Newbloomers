using Domain.AfterSale.Entites.CourierAttributes;

namespace Domain.AfterSale.Entities
{
    public class ReverseComplete
    {
        public string? returned_invoice { get; set; }
        public string? service_type_changed { get; set; }
        public string? type { get; set; }
        public string? tracking_error { get; set; }
        public string? origin { get; set; }
        public string? external_source { get; set; }
        public string? created_by { get; set; }
        public string? locker_reference { get; set; }
        public string? partner_store { get; set; }
        public string? origin_seller_id { get; set; }
        public string? dot_id { get; set; }
        public string? order_id { get; set; }
        public string? billing_item_id { get; set; }
        public string? order_sequence_number { get; set; }
        public string? reverse_type { get; set; }
        public string? reverse_type_name { get; set; }
        public string? total_amount { get; set; }

        public int? service_type_change { get; set; }

        public int? courier_contract_id { get; set; }
        public string? courier_service_type { get; set; }
        public bool? courier_collect { get; set; }
        public CourierData courier_data { get; set; }

        public int? id { get; set; }
        public int? invoice { get; set; }
        public int? status_id { get; set; }
        public int? store_id { get; set; }
        public int? brand_id { get; set; }
        public int? ecommerce_order_id { get; set; }
        public int? ecommerce_id { get; set; }
        public string? destination_seller_id { get; set; }

        public bool? skip_process_step { get; set; }
        public bool? is_erased { get; set; }
        public bool? can_generate_voucher { get; set; }
        public bool? could_cancel { get; set; }
        public bool? freight_by_customer { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? store_expire_date { get; set; }

        public Tracking? tracking { get; set; }
        public EcommerceOrder ecommerce_order { get; set; }
        public List<Product> products { get; set; }
        public List<Refunds> refunds { get; set; }
        public Status status { get; set; }
        public List<StatusHistories> status_histories { get; set; }
    }

    public class Root
    {
        public bool? success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public ReverseComplete reverse { get; set; }
        public CustomerComplete customer { get; set; }
        public string? ecommerce_order { get; set; }
        public List<TrackingHistory> tracking_history { get; set; }
    }
}
