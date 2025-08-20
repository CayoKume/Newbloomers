namespace Domain.AfterSale.Dtos
{
    public class Reverse
    {
        public string? id { get; set; }
        public string? reverse_type { get; set; }
        public string? courier_collect { get; set; }
        public string? courier_service_type { get; set; }
        public string? service_type_changed { get; set; }
        public string? ecommerce_order_id { get; set; }
        public string? store_id { get; set; }
        public string? courier_contract_id { get; set; }
        public string? brand_id { get; set; }
        public string? total_amount { get; set; }
        public string? invoice { get; set; }
        public string? posting_card { get; set; }
        public string? is_store_seller_contract { get; set; }
        public string? locker_reference { get; set; }
        public string? store_expire_date { get; set; }
        public string? skip_process_step { get; set; }
        public string? freight_by_customer { get; set; }
        public string? tracking_error { get; set; }
        public string? origin { get; set; }
        public string? external_source { get; set; }
        public string? order_sequence_number { get; set; }
        public string? billing_item_id { get; set; }
        //public string? created_by { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? deleted_at { get; set; }
        public string? status_id { get; set; }
        public string? type { get; set; }
        public string? ecommerce_id { get; set; }
        public string? partner_store { get; set; }
        public string? destination_seller_id { get; set; }
        public string? origin_seller_id { get; set; }
        public string? is_erased { get; set; }
        public string? service_type_change { get; set; }
        public string? billing_date { get; set; }
        public string? must_treat_refund { get; set; }
        public string? reverse_type_name { get; set; }
        public string? is_generic_courier { get; set; }
        public string? can_generate_voucher { get; set; }
        public string? could_cancel { get; set; }
        public string? can_send_correction_letter { get; set; }
        public string? correction_letter_link { get; set; }
        public string? customer_url { get; set; }
        public string? timeline_url { get; set; }
        public string? collect_scheduling_link { get; set; }
        public string? returned_invoice { get; set; }
        public string? dot_id { get; set; }
        public string? order_id { get; set; }
        public string? refunds_count { get; set; }
        public string? customer_id { get; set; }

        public Ecommerce ecommerce { get; set; }
        public Customer customer { get; set; }
        public Status status { get; set; }
        public Tracking tracking { get; set; }
        public Destination destination_data { get; set; }
        public CourierDataEncrypted courier_data_encrypted { get; set; }
        public List<Product> products { get; set; }
        public List<Refund> refunds { get; set; }
        public List<StatusHistories> status_histories { get; set; }
        public List<TrackingHistory> tracking_history { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Reverse reverse { get; set; }
        public Customer customer { get; set; }
        public string? ecommerce_order { get; set; }
        public List<TrackingHistory> tracking_history { get; set; }
    }
}
