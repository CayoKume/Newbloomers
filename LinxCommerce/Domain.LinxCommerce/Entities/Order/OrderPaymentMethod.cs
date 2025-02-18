using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPaymentMethod
    {
        public Int32? OrderPaymentMethodID { get; set; }
        public Guid? OrderID { get; set; }
        public string? PaymentNumber { get; set; }
        public Int32? PaymentMethodID { get; set; }
        public Guid? TransactionID { get; set; }
        public string? ReconciliationNumber { get; set; }
        public string? Status { get; set; }
        public string? IntegrationID { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountNoInterest { get; set; }
        public decimal? InterestValue { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RefundAmount { get; set; }
        public Int32? Installments { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? CaptureDate { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public DateTime? PaymentCancelledDate { get; set; }

        [SkipProperty]
        public OrderPaymentInfo PaymentInfo { get; set; } = new OrderPaymentInfo();
    }
}
