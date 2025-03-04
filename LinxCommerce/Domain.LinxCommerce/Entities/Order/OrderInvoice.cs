namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderInvoice
    {
        public Guid? OrderInvoiceID { get; set; }
        public string? Code { get; set; }
        public string? Url { get; set; }
        public Guid? FulfillmentID { get; set; }
        public bool? IsIssued { get; set; }
        public string? Series { get; set; }
        public string? Number { get; set; }
        public string? CFOP { get; set; }
        public string? XML { get; set; }
        public string? InvoicePdf { get; set; }
        public string? Observation { get; set; }
        public string? Operation { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? IssuedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Guid? OrderID { get; set; }

        public static bool operator ==(OrderInvoice a, OrderInvoice b)
        {
            if (a is not null && b is not null)
                return 
                    a.OrderInvoiceID == b.OrderInvoiceID && 
                    a.Code == b.Code && 
                    a.Url == b.Url && 
                    a.FulfillmentID == b.FulfillmentID && 
                    a.IsIssued == b.IsIssued && 
                    a.Series == b.Series && 
                    a.Number == b.Number && 
                    a.CFOP == b.CFOP && 
                    a.XML == b.XML && 
                    a.Observation == b.Observation && 
                    a.Operation == b.Operation && 
                    a.ProcessedAt == b.ProcessedAt && 
                    a.IssuedAt == b.IssuedAt && 
                    a.CreatedAt == b.CreatedAt;

            else if (a is null && b is null)
                return true;

            return false;
        }

        public static bool operator !=(OrderInvoice a, OrderInvoice b)
        {
            return !(a == b);
        }
    }
}
