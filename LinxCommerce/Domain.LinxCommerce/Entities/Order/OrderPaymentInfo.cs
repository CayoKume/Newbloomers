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

        public static bool operator ==(OrderPaymentInfo a, OrderPaymentInfo b)
        {
            if (a is not null && b is not null)
                return
                    a.Alias == b.Alias &&
                    a.ExpirationDate == b.ExpirationDate &&
                    a.Holder == b.Holder &&
                    a.Identifier == b.Identifier &&
                    a.Month == b.Month &&
                    a.NumberHint == b.NumberHint &&
                    a.PaymentDate == b.PaymentDate &&
                    a.PaymentType == b.PaymentType &&
                    a.Provider == b.Provider &&
                    a.ReconciliationNumber == b.ReconciliationNumber &&
                    a.SecurityCodeHint == b.SecurityCodeHint &&
                    a.TransactionNumber == b.TransactionNumber &&
                    a.Year == b.Year;

            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(OrderPaymentInfo a, OrderPaymentInfo b)
        {
            return !(a == b);
        }
    }
}
