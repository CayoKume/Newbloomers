using Domain.Core.Extensions;

namespace Domain.AfterSale.Models
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

        public Customer() 
        {
            id = 0;
            address_id = 0;
            contact_email = String.Empty;
            document = String.Empty;
            email = String.Empty;
            first_name = String.Empty;
            last_name = String.Empty;
            phone = String.Empty;
            shipping_address_id = 0;
            shipping_address = new Address();
            address = new Address();
        }

        public Customer(Domain.AfterSale.Dtos.Customer customer)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(customer?.id);
            address_id = CustomConvertersExtensions.ConvertToInt32Validation(customer?.address_id);
            shipping_address_id = CustomConvertersExtensions.ConvertToInt32Validation(customer?.shipping_address_id);

            contact_email = customer?.contact_email;
            document = customer?.document;
            email = customer?.email;
            first_name = customer?.first_name;
            last_name = customer?.last_name;
            phone = customer?.phone;
            shipping_address = customer.shipping_address != null ? new Address(customer.shipping_address) : new Address();
            address = customer.address != null ? new Address(customer.address) : new Address();
        }
    }
}
