namespace Application.App.ViewModels.CancellationRequest
{
    public class Order : Domain.App.Entities.Order
    {
        private List<Product> _itens = new List<Product>();
        public string requester { get; set; }
        public int reason { get; set; }
        public string obs { get; set; }
        public List<Product> itens { get { return _itens; } set { _itens = value; } }
    }

    public class Product : Domain.App.Entities.Product
    {
        public int picked_quantity_product { get; set; }
    }
}
