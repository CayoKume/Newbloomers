namespace Domain.Stone.Entities
{
    public class Item
    {
        public string? code { get; set; }
        public string? description { get; set; }
        public decimal? quantity { get; set; }
        public decimal? unitPrice { get; set; }
        public decimal? weight { get; set; }
        public decimal? height { get; set; }
        public decimal? width { get; set; }
        public decimal? depth { get; set; }
    }
}
