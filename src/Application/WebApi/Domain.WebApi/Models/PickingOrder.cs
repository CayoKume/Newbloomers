namespace Domain.WebApi.Models
{
    public class PickingOrder : Order
    {
        public string? obs { get; set; }
        public string? seller { get; set; }
        public string? present { get; set; }
        public string? amount { get; set; }
        public DateTime? retorno { get; set; }
    }
}
