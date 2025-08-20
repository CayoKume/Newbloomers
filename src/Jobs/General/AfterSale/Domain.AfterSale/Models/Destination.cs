using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
{
    public class Destination
    {
        public string? name { get; set; }
        public string? type { get; set; }
        public Int32? type_id { get; set; }
        public string? seller_id { get; set; }
        public DateTime? updated_at { get; set; }
        public string? seller_info { get; set; }
        public bool? return_to_seller { get; set; }
        public bool? was_manually_changed { get; set; }
        public string? label { get; set; }
        public Address? address { get; set; }

        public Destination() 
        {
            name = String.Empty;
            type = String.Empty;
            type_id = 0;
            seller_id = String.Empty;
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            seller_info = String.Empty;
            return_to_seller = false;
            was_manually_changed = false;
            label = String.Empty;
            address = new Address();
        }

        public Destination(Domain.AfterSale.Dtos.Destination destination)
        {
            name = destination.name;
            type = destination.type;
            seller_id = destination.seller_id;
            seller_info = destination.seller_info;
            label = destination.label;
            type_id = CustomConvertersExtensions.ConvertToInt32Validation(destination?.type_id);
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(destination?.updated_at);
            return_to_seller = CustomConvertersExtensions.ConvertToBooleanValidation(destination?.return_to_seller);
            was_manually_changed = CustomConvertersExtensions.ConvertToBooleanValidation(destination?.was_manually_changed);
            address = destination.address != null ? new Address(destination.address) : new Address();
        }
    }
}
