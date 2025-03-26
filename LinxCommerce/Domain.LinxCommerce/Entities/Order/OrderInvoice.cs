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

        public OrderInvoice() { }

        public OrderInvoice(OrderInvoice orderInvoice, Guid? orderID)
        {
            this.OrderInvoiceID = orderInvoice.OrderInvoiceID;
            this.Code = orderInvoice.Code;
            this.Url = orderInvoice.Url;
            this.FulfillmentID = orderInvoice.FulfillmentID;
            this.IsIssued = orderInvoice.IsIssued;
            this.Series = orderInvoice.Series;
            this.Number = orderInvoice.Number;
            this.CFOP = orderInvoice.CFOP;
            this.XML = orderInvoice.XML;
            this.InvoicePdf = orderInvoice.InvoicePdf;
            this.Observation = orderInvoice.Observation;
            this.Operation = orderInvoice.Operation;
            this.ProcessedAt = orderInvoice.ProcessedAt;
            this.UpdatedAt = orderInvoice.UpdatedAt;
            this.IssuedAt = orderInvoice.IssuedAt;
            this.CreatedAt = orderInvoice.CreatedAt;
            this.OrderID = orderID;
        }
    }
}
