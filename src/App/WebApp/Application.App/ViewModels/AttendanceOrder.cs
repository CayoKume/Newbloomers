namespace Application.WebApp.ViewModels.Attendance
{
    public class Order : Domain.WebApp.Entities.Order
    {
        private List<Product> _itens = new List<Product>();

        public string? buttonText { get; set; }
        public string? buttonClass { get; set; }
        public string? contacted { get; set; }

        public List<Product> itens { get { return _itens; } set { _itens = value; } }
    }

    public class Product : Domain.WebApp.Entities.Product
    {
        public int picked_quantity_product { get; set; }
    }
}
