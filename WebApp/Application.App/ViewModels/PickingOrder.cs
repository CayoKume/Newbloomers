namespace Application.App.ViewModels.Picking
{
    public class Order : Domain.App.Entities.Order
    {
        private List<Product> _itens = new List<Product>();

        public string? buttonText { get; set; }
        public bool buttonClass { get; set; }

        public string? buttonPrintedText { get; set; }
        public bool buttonPrintedClass { get; set; }

        public DateTime? retorno { get; set; }

        public List<Product> itens { get { return _itens; } set { _itens = value; } }
    }

    public class OrderToPrint : Domain.App.Entities.Order
    {
        private List<ProductToPrint> _itens = new List<ProductToPrint>();

        public string number { get; set; }
        public string? obs { get; set; }
        public string? seller { get; set; }
        public string? amount { get; set; }
        public string? present { get; set; }

        public List<ProductToPrint> itens { get { return _itens; } set { _itens = value; } }
    }

    public class Product : Domain.App.Entities.Product
    {
        public string urlImg { get; set; }
        public double picked_quantity { get; set; }
    }

    public class ProductToPrint : Domain.App.Entities.Product
    {
        public string idItem { get; set; }
    }
}
