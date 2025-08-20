using Domain.Core.Extensions;

namespace Domain.AfterSale.Dtos
{
    public class Customer
    {
        public string? id { get; set; }
        public string? address_id { get; set; }
        public string? contact_email { get; set; }
        public string? document { get; set; }
        public string? email { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? phone { get; set; }
        public string? shipping_address_id { get; set; }

        public Address? shipping_address { get; set; }

        public Address? address { get; set; }
    }
}
