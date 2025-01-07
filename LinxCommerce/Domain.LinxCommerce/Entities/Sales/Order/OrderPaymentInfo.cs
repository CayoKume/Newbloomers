namespace Domain.LinxCommerce.Entities.Sales.Order
{
    public class OrderPaymentInfo
    {
        public string? Identifier { get; set; }
        public string? Alias { get; set; }
        public string? PaymentDate { get; set; }
        public string? ExpirationDate { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
        public string? Holder { get; set; }
        public string? NumberHint { get; set; }
        public string? SecurityCodeHint { get; set; }
        public string? TransactionNumber { get; set; }
        public string? AuthorizationCode { get; set; }
        public string? ReceiptCode { get; set; }
        public string? ReconciliationNumber { get; set; }
        public string? ConfirmationNumber { get; set; }
        public string? PaymentType { get; set; }
        public string? Provider { get; set; }
        public string? ProviderDocumentNumber { get; set; }
        public string? PixQRCode { get; set; }
        public string? PixKey { get; set; }

        public string? OrderID { get; set; }
        public string? OrderPaymentMethodID { get; set; }
        public string? PaymentMethodID { get; set; }
        public string? TransactionID { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
