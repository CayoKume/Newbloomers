namespace Domain.AfterSale.Entities
{
    public class Destination
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public Int32? type_id { get; set; }
        public Int32? seller_id { get; set; }
        public DateTime? updated_at { get; set; }
        public string? seller_info { get; set; }
        public bool? return_to_seller { get; set; }
        public bool? was_manually_changed { get; set; }
        public string? label { get; set; }
        public Address? address { get; set; }
    }
}
