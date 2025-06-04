namespace Domain.AfterSale.Entities
{
    public class Address
    {
        public int? id { get; set; }
        public string? zip_code { get; set; }
        public string? address { get; set; }
        public string? complement { get; set; }
        public string? number { get; set; }
        public string? neighborhood { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? lat { get; set; }
        public string? @long { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
