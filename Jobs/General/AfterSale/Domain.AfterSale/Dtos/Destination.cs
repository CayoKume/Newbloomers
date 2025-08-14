namespace Domain.AfterSale.Dtos
{
    public class Destination
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public string? type_id { get; set; }
        public string? seller_id { get; set; }
        public string? updated_at { get; set; }
        public string? seller_info { get; set; }
        public string? return_to_seller { get; set; }
        public string? was_manually_changed { get; set; }
        public string? label { get; set; }
        public Address? address { get; set; }
    }
}
