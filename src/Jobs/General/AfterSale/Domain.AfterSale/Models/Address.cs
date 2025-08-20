using Domain.Core.Extensions;
using System.Globalization;

namespace Domain.AfterSale.Models
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

        public Address() 
        {
            id = 0;
            zip_code = String.Empty;
            address = String.Empty;
            complement = String.Empty;
            number = String.Empty;
            neighborhood = String.Empty;
            city = String.Empty;
            state = String.Empty;
            lat = String.Empty;
            @long = String.Empty;
            updated_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
            deleted_at = new DateTime(1990, 01, 01, 00, 00, 00, new CultureInfo("en-US").Calendar);
        }

        public Address(Domain.AfterSale.Dtos.Address address)
        {
            id = CustomConvertersExtensions.ConvertToInt32Validation(address.id);
            zip_code = address.zip_code;
            address.address = address.address;
            complement = address.complement;
            number = address.number;
            neighborhood = address.neighborhood;
            city = address.city;
            state = address.state;
            lat = address.lat;
            @long = address.@long;
            updated_at = CustomConvertersExtensions.ConvertToDateTimeValidation(address.updated_at);
            deleted_at = CustomConvertersExtensions.ConvertToDateTimeValidation(address.deleted_at);
        }
    }
}
