namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPaymentInfo
    {
        public string? Identifier { get; set; }
        public string? Alias { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Int32? Month { get; set; }
        public Int32? Year { get; set; }
        public string? Holder { get; set; }
        public string? NumberHint { get; set; }
        public string? SecurityCodeHint { get; set; }
        public string? TransactionNumber { get; set; }
        public string? AuthorizationCode { get; set; }
        public string? ReceiptCode { get; set; }
        public string? ReconciliationNumber { get; set; }
        public string? ConfirmationNumber { get; set; }
        public Int32? PaymentType { get; set; }
        public string? Provider { get; set; }
        public string? ProviderDocumentNumber { get; set; }
        public string? PixQRCode { get; set; }
        public string? PixKey { get; set; }
        public Int32? OrderPaymentMethodID { get; set; }
    }
}
