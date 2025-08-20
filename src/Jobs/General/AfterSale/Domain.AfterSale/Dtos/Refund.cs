namespace Domain.AfterSale.Dtos
{
    public class Refund
    {
        public string? id { get; set; }
        public string? type { get; set; }
        public string? action { get; set; }
        public string? bonus_amount { get; set; }
        public string? bonus_amount_percent { get; set; }
        public string? requested_shipping_amount { get; set; }
        public string? shipping_method { get; set; }
        public string? requested_raw_amount { get; set; }
        public string? requested_amount { get; set; }
        public string? received_amount { get; set; }
        public string? received_raw_amount { get; set; }
        public string? total_amount { get; set; }
        public string? free_shipping { get; set; }
        public string? created_at { get; set; }
        public string? updated_at { get; set; }
        public string? cashback_account { get; set; }
        public string? should_ask_voucher_code { get; set; }
        public string? requested_total_amount { get; set; }
        public string? can_edit_wire_transfer { get; set; }
        public string? has_wire_transfer_account { get; set; }
        public string? customer_retention_method_id { get; set; }
        public string? external_order_url { get; set; }
        public string? reverse_id { get; set; }
        public string? order_id { get; set; }
        public string? ecommerce_order_id { get; set; }
        public string? last_status_history_date { get; set; }
        public string? refunded_shipping_type { get; set; }

        public string? voucher_giftcard_id { get; set; }
        //public string total_amount_histories_id { get; set; }
        public string customer_id { get; set; }
        public string status_id { get; set; }

        public Customer customer { get; set; }
        public Status status { get; set; }
        public StatusHistories status_histories { get; set; }
        public TotalAmountHistories total_amount_histories { get; set; }
        public Voucher voucher { get; set; }
        public Reverse reverse { get; set; }
        public List<Product> products { get; set; }
        public List<OrderTransactions> order_transactions { get; set; }
    }
}
