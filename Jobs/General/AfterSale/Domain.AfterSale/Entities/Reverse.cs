using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.AfterSale.Entities
{
    public class Reverse
    {
        public int? id { get; set; }
        public string? reverse_type { get; set; }
        public bool? courier_collect { get; set; }
        public string? courier_service_type { get; set; }
        public string? service_type_changed { get; set; }
        public int? ecommerce_order_id { get; set; }
        public int? store_id { get; set; }
        public int? courier_contract_id { get; set; }
        public int? brand_id { get; set; }
        public decimal? total_amount { get; set; }
        public int? invoice { get; set; }
        public string? posting_card { get; set; }
        public bool? is_store_seller_contract { get; set; }
        public string? locker_reference { get; set; }
        public DateTime? store_expire_date { get; set; }
        public bool? skip_process_step { get; set; }
        public bool? freight_by_customer { get; set; }
        public string? tracking_error { get; set; }
        public string? origin { get; set; }
        public string? external_source { get; set; }
        public string? order_sequence_number { get; set; }
        public string? billing_item_id { get; set; }
        public string? created_by { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public int? status_id { get; set; }
        public string? type { get; set; }
        public int? ecommerce_id { get; set; }
        public string? partner_store { get; set; }
        public string? destination_seller_id { get; set; }
        public string? origin_seller_id { get; set; }
        public bool? is_erased { get; set; }
        public int? service_type_change { get; set; }
        public DateTime? billing_date { get; set; }
        public bool? must_treat_refund { get; set; }
        public string? reverse_type_name { get; set; }
        public bool? is_generic_courier { get; set; }
        public bool? can_generate_voucher { get; set; }
        public bool? could_cancel { get; set; }
        public bool? can_send_correction_letter { get; set; }
        public string? correction_letter_link { get; set; }
        public string? customer_url { get; set; }
        public string? timeline_url { get; set; }
        public string? collect_scheduling_link { get; set; }
        public string? returned_invoice { get; set; }

        public string? dot_id { get; set; }
        public string? order_id { get; set; }
        
        public decimal? refunds_count { get; set; }

        public int? customer_id { get; set; }

        [SkipProperty]
        public Ecommerce ecommerce { get; set; }

        [SkipProperty]
        public Customer customer { get; set; }

        [SkipProperty]
        public Status status { get; set; }

        [SkipProperty]
        public Tracking? tracking { get; set; }
        
        [NotMapped]
        [SkipProperty]
        public Destination destination_data { get; set; }

        [SkipProperty]
        public List<Product> products { get; set; }

        [SkipProperty]
        public List<Refund> refunds { get; set; }

        [SkipProperty]
        public List<StatusHistories> status_histories { get; set; }

        [SkipProperty]
        public List<TrackingHistory> tracking_history { get; set; }

        /// <summary>
        /// property created to be used on get reverse by id step on method GetReverses can't be mapped by dapper, can't be mapped by migrations
        /// </summary>
        [NotMapped]
        [SkipProperty]
        public string token { get; set; } = string.Empty;

        public Reverse() { }

        public Reverse(Reverse reverse, string token)
        {
            id = reverse.id;
            reverse_type = reverse.reverse_type;
            courier_collect = reverse.courier_collect;
            courier_service_type = reverse.courier_service_type;
            service_type_changed = reverse.service_type_changed;
            ecommerce_order_id = reverse.ecommerce_order_id;
            store_id = reverse.store_id;
            courier_contract_id = reverse.courier_contract_id;
            brand_id = reverse.brand_id;
            total_amount = reverse.total_amount;
            invoice = reverse.invoice;
            posting_card = reverse.posting_card;
            is_store_seller_contract = reverse.is_store_seller_contract;
            locker_reference = reverse.locker_reference;
            store_expire_date = reverse.store_expire_date;
            skip_process_step = reverse.skip_process_step;
            freight_by_customer = reverse.freight_by_customer;
            tracking_error = reverse.tracking_error;
            origin = reverse.origin;
            external_source = reverse.external_source;
            order_sequence_number = reverse.order_sequence_number;
            billing_item_id = reverse.billing_item_id;
            created_by = reverse.created_by;
            created_at = reverse.created_at;
            updated_at = reverse.updated_at;
            deleted_at = reverse.deleted_at;
            status_id = reverse.status_id;
            type = reverse.type;
            ecommerce_id = reverse.ecommerce_id;
            partner_store = reverse.partner_store;
            destination_seller_id = reverse.destination_seller_id;
            origin_seller_id = reverse.origin_seller_id;
            is_erased = reverse.is_erased;
            service_type_change = reverse.service_type_change;
            billing_date = reverse.billing_date;
            must_treat_refund = reverse.must_treat_refund;
            reverse_type_name = reverse.reverse_type_name;
            is_generic_courier = reverse.is_generic_courier;
            can_generate_voucher = reverse.can_generate_voucher;
            could_cancel = reverse.could_cancel;
            can_send_correction_letter = reverse.can_send_correction_letter;
            correction_letter_link = reverse.correction_letter_link;
            customer_url = reverse.customer_url;
            timeline_url = reverse.timeline_url;
            collect_scheduling_link = reverse.collect_scheduling_link;
            returned_invoice = reverse.returned_invoice;
            dot_id = reverse.dot_id;
            order_id = reverse.order_id;
            refunds_count = reverse.refunds_count;
            customer_id = reverse.customer_id;
            ecommerce = reverse.ecommerce;
            customer = reverse.customer;
            status = reverse.status;
            tracking = reverse.tracking;
            destination_data = reverse.destination_data;
            products = reverse.products;
            refunds = reverse.refunds;
            status_histories = reverse.status_histories;
            tracking_history = reverse.tracking_history;
            this.token = token;
        }
    }

    public class Root
    {
        public bool? success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Reverse reverse { get; set; }
        public Customer customer { get; set; }
        public string? ecommerce_order { get; set; }
        public List<TrackingHistory> tracking_history { get; set; }

        [SkipProperty]
        [NotMapped]
        public Dictionary<int?, string> Responses { get; set; } = new Dictionary<int?, string>();

        public Data() { }

        public Data(Data completeReverse, string json)
        {
            reverse = completeReverse.reverse;
            customer = completeReverse.customer;
            ecommerce_order = completeReverse.ecommerce_order;
            tracking_history = completeReverse.tracking_history;

            Responses.Add(completeReverse.reverse.id, json);
        }
    }

    public class ResponseReverses
    {
        public int? current_page { get; set; }
        public string? first_page_url { get; set; }
        public int? from { get; set; }
        public int? last_page { get; set; }
        public string? last_page_url { get; set; }
        public string? next_page_url { get; set; }
        public string? path { get; set; }
        public int? per_page { get; set; }
        public string? prev_page_url { get; set; }
        public int? to { get; set; }
        public int? total { get; set; }
        public bool? success { get; set; }
        public List<Reverse> data { get; set; }
    }
}
