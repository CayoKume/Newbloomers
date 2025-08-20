using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Refund
    {
        public int? id { get; set; }
        public int? reverse_id { get; set; }
        public int? ecommerce_order_id { get; set; }
        //public int? total_amount_histories_id { get; set; }
        public int? customer_id { get; set; }
        public int? status_id { get; set; }

        public decimal? bonus_amount { get; set; }
        public decimal? bonus_amount_percent { get; set; }
        public decimal? requested_shipping_amount { get; set; }
        public decimal? requested_raw_amount { get; set; }
        public decimal? requested_amount { get; set; }
        public decimal? received_amount { get; set; }
        public decimal? received_raw_amount { get; set; }
        public decimal? total_amount { get; set; }
        public decimal? requested_total_amount { get; set; }

        public bool? should_ask_voucher_code { get; set; }
        public bool? can_edit_wire_transfer { get; set; }
        public bool? has_wire_transfer_account { get; set; }
        public bool? free_shipping { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? last_status_history_date { get; set; }

        public string? type { get; set; }
        public string? action { get; set; }
        public string? shipping_method { get; set; }
        public string? cashback_account { get; set; }
        public string? customer_retention_method_id { get; set; }
        public string? external_order_url { get; set; }
        public string? order_id { get; set; }
        public string? refunded_shipping_type { get; set; }
        public string? voucher_giftcard_id { get; set; }

        [SkipProperty]
        public Customer customer { get; set; }

        [SkipProperty]
        public Status status { get; set; }

        [SkipProperty]
        public StatusHistories status_histories { get; set; }

        [SkipProperty]
        public TotalAmountHistories total_amount_histories { get; set; }

        [SkipProperty]
        public Voucher voucher { get; set; }

        [SkipProperty]
        public Reverse reverse { get; set; }

        [SkipProperty]
        public List<Product> products { get; set; } = new List<Product>();

        [SkipProperty]
        public List<OrderTransactions> order_transactions { get; set; } = new List<OrderTransactions>();

        public Refund() 
        {
            id = 0;
            reverse_id = 0;
            ecommerce_order_id = 0;
            customer_id = 0;
            status_id = 0;

            bonus_amount = 0;
            bonus_amount_percent = 0;
            requested_shipping_amount = 0;
            requested_raw_amount = 0;
            requested_amount = 0;
            received_amount = 0;
            received_raw_amount = 0;
            total_amount = 0;
            requested_total_amount = 0;

            should_ask_voucher_code = false;
            can_edit_wire_transfer = false;
            has_wire_transfer_account = false;
            free_shipping = false;

            created_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            last_status_history_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            type = String.Empty;
            action = String.Empty;
            shipping_method = String.Empty;
            cashback_account = String.Empty;
            customer_retention_method_id = String.Empty;
            external_order_url = String.Empty;
            order_id = String.Empty;
            refunded_shipping_type = String.Empty;
            voucher_giftcard_id = String.Empty;

            customer = new Customer();
            status = new Status();
            status_histories = new StatusHistories();
            total_amount_histories = new TotalAmountHistories();
            voucher = new Voucher();
            reverse = new Reverse();
        }

        public Refund(Dtos.Refund refund)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(refund.id);
            reverse_id = CustomConvertersExtensions.ConvertToInt32Validation(refund.reverse_id);
            ecommerce_order_id = CustomConvertersExtensions.ConvertToInt32Validation(refund.ecommerce_order_id);
            customer_id = CustomConvertersExtensions.ConvertToInt32Validation(refund.customer_id);
            status_id = CustomConvertersExtensions.ConvertToInt32Validation(refund.status_id);

            bonus_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.bonus_amount);
            bonus_amount_percent = CustomConvertersExtensions.ConvertToDecimalValidation(refund.bonus_amount_percent);
            requested_shipping_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.requested_shipping_amount);
            requested_raw_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.requested_raw_amount);
            requested_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.requested_amount);
            received_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.received_amount);
            received_raw_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.received_raw_amount);
            total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.total_amount);
            requested_total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(refund.requested_total_amount);

            should_ask_voucher_code = CustomConvertersExtensions.ConvertToBooleanValidation(refund.should_ask_voucher_code);
            can_edit_wire_transfer = CustomConvertersExtensions.ConvertToBooleanValidation(refund.can_edit_wire_transfer);
            has_wire_transfer_account = CustomConvertersExtensions.ConvertToBooleanValidation(refund.has_wire_transfer_account);
            free_shipping = CustomConvertersExtensions.ConvertToBooleanValidation(refund.free_shipping);

            created_at = CustomConvertersExtensions.ConvertToDateTimeValidation(refund.created_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(refund.updated_at);
            last_status_history_date = CustomConvertersExtensions.ConvertToDateTimeValidation(refund.last_status_history_date);

            type = refund.type;
            action = refund.action;
            shipping_method = refund.shipping_method;
            cashback_account = refund.cashback_account;
            customer_retention_method_id = refund.customer_retention_method_id;
            external_order_url = refund.external_order_url;
            order_id = refund.order_id;
            refunded_shipping_type = refund.refunded_shipping_type;
            voucher_giftcard_id = refund.voucher_giftcard_id;

            customer = refund.customer != null ? new Customer(refund.customer) : new Customer();
            status = refund.status != null ? new Status(refund.status) : new Status();
            status_histories = refund.status_histories != null ? new StatusHistories(refund.status_histories) : new StatusHistories();
            total_amount_histories = refund.total_amount_histories != null ? new TotalAmountHistories(refund.total_amount_histories) : new TotalAmountHistories();
            voucher = refund.voucher != null ? new Voucher(refund.voucher) : new Voucher();
            reverse = refund.reverse != null ? new Reverse(refund.reverse) : new Reverse();

            refund.products?.ForEach(product =>
                    products.Add(new Product(product)
            ));

            refund.order_transactions?.ForEach(ordertransaction =>
                order_transactions.Add(new OrderTransactions(ordertransaction)
            ));
        }
    }
}
