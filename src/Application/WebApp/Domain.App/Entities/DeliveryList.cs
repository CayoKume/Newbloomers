namespace Domain.WebApp.Entities
{
    public class DeliveryList
    {
        public Guid uniqueidentifier { get; set; }
        public string? doc_company { get; set; }
        public string? name { get; set; }
        public string? carrier { get; set; }
        public DateTime printedAt { get; set; }
        public DateTime colletedAt { get; set; }
    }
}
