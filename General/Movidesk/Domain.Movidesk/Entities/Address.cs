namespace Domain.Movidesk.Entities
{
    public class Address
    {
        public Int32? id { get; set; }
        public string? addressType { get; set; }
        public string? country { get; set; }
        public string? postalCode { get; set; }
        public string? state { get; set; }
        public string? district { get; set; }
        public string? city { get; set; }
        public string? street { get; set; }
        public string? number { get; set; }
        public string? complement { get; set; }
        public string? reference { get; set; }
        public bool? isDefault { get; set; }
        public Int32? countryId { get; set; }
    }
}
