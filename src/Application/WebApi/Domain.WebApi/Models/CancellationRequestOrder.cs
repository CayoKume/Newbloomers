namespace Domain.WebApi.Models
{
    public class CancellationRequestOrder : Order
    {
        private List<CancellationRequestProduct> _itens = new List<CancellationRequestProduct>();

        public string requester { get; set; }
        public int reason { get; set; }
        public string obs { get; set; }

        public List<CancellationRequestProduct> itens { get { return _itens; } set { _itens = value; } }
    }
}
