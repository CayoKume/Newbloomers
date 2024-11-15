namespace Domain.LinxCommerce.Entities.Sales.Order
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
        public string? PaymentDate { get; set; }
        public OrderPaymentInfo PaymentInfo { get; set; } = new OrderPaymentInfo();
        public List<OrderPaymentMethodProperty> Properties { get; set; } = new List<OrderPaymentMethodProperty>();
        public string? CaptureDate { get; set; }
        public string? AcquiredDate { get; set; }
        public string? PaymentCancelledDate { get; set; }
    }
}
