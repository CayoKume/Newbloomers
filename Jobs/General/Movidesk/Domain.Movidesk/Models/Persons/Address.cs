namespace Domain.Movidesk.Models.Persons
{
    public class Address
    {
        public Int64? person_id { get; set; }
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

        public Address() { }

        public Address(Dtos.Persons.Address address, Int64? person_id)
        {
            this.person_id = person_id;
            addressType = address.addressType;
            country = address.country;
            postalCode = address.postalCode;
            state = address.state;
            district = address.district;
            city = address.city;
            street = address.street;
            number = address.number;
            complement = address.complement;
            reference = address.reference;
            isDefault = Convert.ToBoolean(address.isDefault);
        }
    }
}
