using Domain.Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Reverse
    {
        public int? id { get; set; }
        public int? invoice { get; set; }
        public int? customer_id { get; set; }
        public int? status_id { get; set; }
        public int? ecommerce_id { get; set; }
        public int? service_type_change { get; set; }
        public int? service_type_changed { get; set; }
        public int? ecommerce_order_id { get; set; }
        public int? store_id { get; set; }
        public int? courier_contract_id { get; set; }
        public int? brand_id { get; set; }

        public bool? is_store_seller_contract { get; set; }
        public bool? courier_collect { get; set; }
        public bool? must_treat_refund { get; set; }
        public bool? is_generic_courier { get; set; }
        public bool? can_generate_voucher { get; set; }
        public bool? could_cancel { get; set; }
        public bool? can_send_correction_letter { get; set; }
        public bool? is_erased { get; set; }
        public bool? skip_process_step { get; set; }
        public bool? freight_by_customer { get; set; }

        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public DateTime? store_expire_date { get; set; }
        public DateTime? billing_date { get; set; }

        public string? type { get; set; }
        public string? partner_store { get; set; }
        public string? destination_seller_id { get; set; }
        public string? origin_seller_id { get; set; }
        public string? reverse_type_name { get; set; }
        public string? correction_letter_link { get; set; }
        public string? customer_url { get; set; }
        public string? timeline_url { get; set; }
        public string? collect_scheduling_link { get; set; }
        public string? returned_invoice { get; set; }
        public string? locker_reference { get; set; }
        public string? posting_card { get; set; }
        public string? reverse_type { get; set; }
        public string? courier_service_type { get; set; }
        public string? tracking_error { get; set; }
        public string? origin { get; set; }
        public string? external_source { get; set; }
        public string? order_sequence_number { get; set; }
        public string? billing_item_id { get; set; }
        public string? created_by { get; set; }
        public string? dot_id { get; set; }
        public string? order_id { get; set; }
        
        public decimal? refunds_count { get; set; }
        public decimal? total_amount { get; set; }


        [SkipProperty]
        public Ecommerce ecommerce { get; set; }

        [SkipProperty]
        public Customer customer { get; set; }

        [SkipProperty]
        public Status status { get; set; }

        [SkipProperty]
        public Tracking? tracking { get; set; }
        
        [SkipProperty]
        public Destination destination_data { get; set; }

        [SkipProperty]
        public CourierDataEncrypted courier_data_encrypted { get; set; }

        [SkipProperty]
        public List<Product> products { get; set; } = new List<Product>();

        [SkipProperty]
        public List<Refund> refunds { get; set; } = new List<Refund>();

        [SkipProperty]
        public List<StatusHistories> status_histories { get; set; } = new List<StatusHistories>();

        [SkipProperty]
        public List<TrackingHistory> tracking_history { get; set; } = new List<TrackingHistory>();

        [SkipProperty]
        public Dictionary<int?, string> Responses { get; set; } = new Dictionary<int?, string>();

        public Reverse() 
        {
            id = 0;
            invoice = 0;
            customer_id = 0;
            status_id = 0;
            ecommerce_id = 0;
            service_type_change = 0;
            service_type_changed = 0;
            ecommerce_order_id = 0;
            store_id = 0;
            courier_contract_id = 0;
            brand_id = 0;

            is_store_seller_contract = false;
            courier_collect = false;
            must_treat_refund = false;
            is_generic_courier = false;
            can_generate_voucher = false;
            could_cancel = false;
            can_send_correction_letter = false;
            is_erased = false;
            skip_process_step = false;
            freight_by_customer = false;

            created_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            deleted_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            store_expire_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            billing_date = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);

            type = String.Empty;
            partner_store = String.Empty;
            destination_seller_id = String.Empty;
            origin_seller_id = String.Empty;
            reverse_type_name = String.Empty;
            correction_letter_link = String.Empty;
            customer_url = String.Empty;
            timeline_url = String.Empty;
            collect_scheduling_link = String.Empty;
            returned_invoice = String.Empty;
            locker_reference = String.Empty;
            posting_card = String.Empty;
            reverse_type = String.Empty;
            courier_service_type = String.Empty;
            tracking_error = String.Empty;
            origin = String.Empty;
            external_source = String.Empty;
            order_sequence_number = String.Empty;
            billing_item_id = String.Empty;
            created_by = String.Empty;
            dot_id = String.Empty;
            order_id = String.Empty;

            refunds_count = 0;
            total_amount = 0;

            ecommerce = new Ecommerce();
            customer = new Customer();
            status = new Status();
            tracking = new Tracking();
            destination_data = new Destination();
            courier_data_encrypted = new CourierDataEncrypted();
        }

        public Reverse(Domain.AfterSale.Dtos.Reverse reverse)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.id);
            service_type_changed = CustomConvertersExtensions.ConvertToInt32Validation(reverse.service_type_changed);
            ecommerce_order_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.ecommerce_order_id);
            store_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.store_id);
            courier_contract_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.courier_contract_id);
            brand_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.brand_id);
            invoice = CustomConvertersExtensions.ConvertToInt32Validation(reverse.invoice);
            status_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.status_id);
            ecommerce_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.ecommerce_id);
            service_type_change = CustomConvertersExtensions.ConvertToInt32Validation(reverse.service_type_change);
            customer_id = CustomConvertersExtensions.ConvertToInt32Validation(reverse.customer?.id);

            total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(reverse.total_amount);
            refunds_count = CustomConvertersExtensions.ConvertToDecimalValidation(reverse.refunds_count);

            is_store_seller_contract = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.is_store_seller_contract);
            courier_collect = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.courier_collect);
            skip_process_step = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.skip_process_step);
            freight_by_customer = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.freight_by_customer);
            is_erased = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.is_erased);
            must_treat_refund = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.must_treat_refund);
            is_generic_courier = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.is_generic_courier);
            can_generate_voucher = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.can_generate_voucher);
            could_cancel = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.could_cancel);
            can_send_correction_letter = CustomConvertersExtensions.ConvertToBooleanValidation(reverse.can_send_correction_letter);

            store_expire_date = CustomConvertersExtensions.ConvertToDateTimeValidation(reverse.store_expire_date);
            created_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reverse.created_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reverse.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(reverse.deleted_at);
            billing_date = CustomConvertersExtensions.ConvertToDateTimeValidation(reverse.billing_date);

            order_id = reverse.order_id;
            posting_card = reverse.posting_card;
            reverse_type_name = reverse.reverse_type_name;
            reverse_type = reverse.reverse_type;
            courier_service_type = reverse.courier_service_type;
            locker_reference = reverse.locker_reference;
            tracking_error = reverse.tracking_error;
            origin = reverse.origin;
            external_source = reverse.external_source;
            order_sequence_number = reverse.order_sequence_number;
            billing_item_id = reverse.billing_item_id;
            //created_by = reverse.created_by;
            type = reverse.type;
            partner_store = reverse.partner_store;
            destination_seller_id = reverse.destination_seller_id;
            origin_seller_id = reverse.origin_seller_id;
            correction_letter_link = reverse.correction_letter_link;
            customer_url = reverse.customer_url;
            timeline_url = reverse.timeline_url;
            collect_scheduling_link = reverse.collect_scheduling_link;
            returned_invoice = reverse.returned_invoice;
            dot_id = reverse.dot_id;

            ecommerce = reverse.ecommerce != null ? new Ecommerce(reverse.ecommerce) : new Ecommerce();
            customer = reverse.customer != null ? new Customer(reverse.customer) : new Customer();
            status = reverse.status != null ? new Status(reverse.status) : new Status();
            tracking = reverse.tracking != null ? new Tracking(reverse.tracking) : new Tracking();
            destination_data = reverse.destination_data != null ? new Destination(reverse.destination_data) : new Destination();

            reverse.products?.ForEach(product =>
                products.Add(new Product(product)
            ));

            reverse.refunds?.ForEach(refund =>
                refunds.Add(new Refund(refund)
            ));

            reverse.status_histories?.ForEach(status_historie =>
                status_histories.Add(new StatusHistories(status_historie)
            ));

            reverse.tracking_history?.ForEach(trackinghistory =>
                tracking_history.Add(new TrackingHistory(trackinghistory)
            ));
        }

        public Reverse(Domain.AfterSale.Dtos.Data data, string response)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.id);
            service_type_changed = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.service_type_changed);
            ecommerce_order_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.ecommerce_order_id);
            store_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.store_id);
            courier_contract_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.courier_contract_id);
            brand_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.brand_id);
            invoice = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.invoice);
            status_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.status_id);
            ecommerce_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.ecommerce_id);
            service_type_change = CustomConvertersExtensions.ConvertToInt32Validation(data?.reverse?.service_type_change);
            customer_id = CustomConvertersExtensions.ConvertToInt32Validation(data?.customer?.id);
            
            total_amount = CustomConvertersExtensions.ConvertToDecimalValidation(data?.reverse?.total_amount);
            refunds_count = CustomConvertersExtensions.ConvertToDecimalValidation(data?.reverse?.refunds_count);

            is_store_seller_contract = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.is_store_seller_contract);
            courier_collect = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.courier_collect);
            skip_process_step = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.skip_process_step);
            freight_by_customer = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.freight_by_customer);
            is_erased = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.is_erased);
            must_treat_refund = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.must_treat_refund);
            is_generic_courier = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.is_generic_courier);
            can_generate_voucher = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.can_generate_voucher);
            could_cancel = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.could_cancel);
            can_send_correction_letter = CustomConvertersExtensions.ConvertToBooleanValidation(data?.reverse?.can_send_correction_letter);

            store_expire_date = CustomConvertersExtensions.ConvertToDateTimeValidation(data?.reverse?.store_expire_date);
            created_at = CustomConvertersExtensions.ConvertToDateTimeValidation(data?.reverse?.created_at);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(data?.reverse?.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(data?.reverse?.deleted_at);
            billing_date = CustomConvertersExtensions.ConvertToDateTimeValidation(data?.reverse?.billing_date);

            order_id = data?.ecommerce_order;
            posting_card = data?.reverse?.posting_card;
            reverse_type_name = data?.reverse?.reverse_type_name;
            reverse_type = data?.reverse?.reverse_type;
            courier_service_type = data?.reverse?.courier_service_type;
            locker_reference = data?.reverse?.locker_reference;
            tracking_error = data?.reverse?.tracking_error;
            origin = data?.reverse?.origin;
            external_source = data?.reverse?.external_source;
            order_sequence_number = data?.reverse?.order_sequence_number;
            billing_item_id = data?.reverse?.billing_item_id;
            //created_by = data?.reverse?.created_by;
            type = data?.reverse?.type;
            partner_store = data?.reverse?.partner_store;
            destination_seller_id = data?.reverse?.destination_seller_id;
            origin_seller_id = data?.reverse?.origin_seller_id;
            correction_letter_link = data?.reverse?.correction_letter_link;
            customer_url = data?.reverse?.customer_url;
            timeline_url = data?.reverse?.timeline_url;
            collect_scheduling_link = data?.reverse?.collect_scheduling_link;
            returned_invoice = data?.reverse?.returned_invoice;
            dot_id = data?.reverse?.dot_id;

            ecommerce = data?.reverse?.ecommerce != null ? new Ecommerce(data?.reverse?.ecommerce) : new Ecommerce();
            customer = data?.customer != null ? new Customer(data?.customer) : new Customer();
            status = data?.reverse?.status != null ? new Status(data?.reverse?.status) : new Status();
            tracking = data?.reverse?.tracking != null ? new Tracking(data?.reverse?.tracking) : new Tracking();
            destination_data = data?.reverse?.destination_data != null ? new Destination(data?.reverse?.destination_data) : new Destination();

            data?.reverse?.products?.ForEach(product =>
                products.Add(new Product(product)
            ));

            data?.reverse?.refunds?.ForEach(refund =>
                refunds.Add(new Refund(refund)
            ));

            data?.reverse?.status_histories?.ForEach(status_historie =>
                status_histories.Add(new StatusHistories(status_historie)
            ));

            data?.tracking_history?.ForEach(trackinghistory =>
                tracking_history.Add(new TrackingHistory(trackinghistory)
            ));
        }
    }
}
