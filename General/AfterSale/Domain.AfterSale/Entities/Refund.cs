namespace Domain.AfterSale.Entities
{
    public class Refund
    {
        public int? id { get; set; }
        public string? type { get; set; }
        public string? action { get; set; }
        public decimal? bonus_amount { get; set; }
        public decimal? bonus_amount_percent { get; set; }
        public decimal? requested_amount { get; set; }
        public decimal? requested_total_amount { get; set; }
        public decimal? received_amount { get; set; }
        public decimal? received_raw_amount { get; set; }
        public decimal? total_amount { get; set; }
        public string? free_shipping { get; set; }
        public string? cashback_account { get; set; }
        public bool? should_ask_voucher_code { get; set; }
        public string? order_payment_methods { get; set; }
        public bool? can_edit_wire_transfer { get; set; }
        public bool? has_wire_transfer_account { get; set; }
        public string? customer_retention_method_id { get; set; }
        public string? external_order_url { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public Customer customer { get; set; } 
        public Status status { get; set; } 
        public StatusHistories status_histories { get; set; } 
        public TotalAmountHistories total_amount_histories { get; set; } 
        public Voucher voucher { get; set; } 
        public Reverse reverse { get; set; } 
        public List<Product> products { get; set; } 
    }
}
