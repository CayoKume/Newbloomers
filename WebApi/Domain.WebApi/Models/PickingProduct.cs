namespace Domain.WebApi.Models
{
    public class PickingProduct : Product
    {
        public string urlImg { get; set; }
        public double picked_quantity { get; set; }
        //public string idItem { get; set; }
    }
}
