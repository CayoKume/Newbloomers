using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPaymentMethod
    {
        public string? OrderPaymentMethodID { get; set; }
        public string? OrderID { get; set; }
        public string? PaymentNumber { get; set; }
        public string? PaymentMethodID { get; set; }
        public string? TransactionID { get; set; }
        public string? ReconciliationNumber { get; set; }
        public string? Status { get; set; }
        public string? IntegrationID { get; set; }
        public string? Amount { get; set; }
        public string? AmountNoInterest { get; set; }
        public string? InterestValue { get; set; }
        public string? PaidAmount { get; set; }
        public string? RefundAmount { get; set; }
        public string? Installments { get; set; }
        public string? InstallmentAmount { get; set; }
        public string? TaxAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? CaptureDate { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public DateTime? PaymentCancelledDate { get; set; }

        [SkipProperty]
        public OrderPaymentInfo PaymentInfo { get; set; } = new OrderPaymentInfo();
    }
}
