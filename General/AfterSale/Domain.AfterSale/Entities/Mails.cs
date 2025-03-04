namespace Domain.AfterSale.Entities
{
    public class Mails
    {
        public string? greeting { get; set; }
        public string? footer { get; set; }
        public _Reverse reverse { get; set; }
        public _Refund refund { get; set; }
        public Partials partials { get; set; }
    }

    public class _Reverse
    {
        public SubjectContent send4_code_generated { get; set; }
        public SubjectContent correio_code_generated { get; set; }
        public SubjectContent courier_collect_code_generated { get; set; }
        public SubjectContent correio_code_expiring { get; set; }
        public SubjectContent correio_collect_change_to_post { get; set; }
        public SubjectContent correio_tracking_posted { get; set; }
        public SubjectContent correio_tracking_delivered { get; set; }
        public SubjectContent ecommerce_store_reverse { get; set; }
        public SubjectContent products_received { get; set; }
        public SubjectContent reverse_refused { get; set; }
        public SubjectContent reverse_canceled { get; set; }
        public SubjectContent awaiting_without_process { get; set; }
    }

    public class _Refund
    {
        public SubjectContent approved { get; set; }
        public SubjectContent paid_refund { get; set; }
        public SubjectContent paid_wire_transfer { get; set; }
        public SubjectContent paid_product { get; set; }
        public SubjectContent paid_voucher { get; set; }
        public SubjectContent paid_credit { get; set; }
        public SubjectContent ask_wire_transfer_data { get; set; }
        public SubjectContent paid_hard_retention { get; set; }
    }

    public class Partials
    {
        public string? partially_received_warning { get; set; }
    }

    public class SubjectContent
    {
        public string? subject { get; set; }
        public string? content { get; set; }
    }
}
