using Domain.Core.Extensions;

namespace Domain.AfterSale.Entities
{
    public class Customer
    {
        public int? id { get; set; }
        public int? address_id { get; set; }
        public string? contact_email { get; set; }
        public string? document { get; set; }
        public string? email { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? phone { get; set; }
        public int? shipping_address_id { get; set; }

        [SkipProperty]
        public Address? shipping_address { get; set; }

        [SkipProperty]
        public Address? address { get; set; }
    }
}
