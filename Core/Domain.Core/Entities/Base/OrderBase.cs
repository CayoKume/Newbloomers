namespace Domain.Core.Entities.Base
{
    public abstract class OrderBase
    {
        public string? number { get; set; }
        public string? cfop { get; set; }
        public int volumes { get; set; }
        private List<ProductBase> _itens = new List<ProductBase>();

        public ClientBase? client { get; set; }
        public CompanyBase? company { get; set; }
        public ShippingCompanyBase? shippingCompany { get; set; }
        public InvoiceBase? invoice { get; set; }
        public List<ProductBase> itens { get { return _itens; } set { _itens = value; } }
    }
}
