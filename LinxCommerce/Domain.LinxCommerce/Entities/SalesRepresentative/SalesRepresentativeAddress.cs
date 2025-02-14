using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeAddress : IEquatable<SalesRepresentativeAddress>
    {
        public int? SalesRepresentativeID { get; set; }
        public bool? IsMainAddress { get; set; }
        public string? Name { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Number { get; set; }
        public string? State { get; set; }
        public string? AddressNotes { get; set; }
        public string? Landmark { get; set; }
        public string? ContactName { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? PostalCode { get; set; }

        public static List<SalesRepresentativeAddress?> Compare(List<SalesRepresentativeAddress?> salesRepresentativeAddressAPIList, List<SalesRepresentativeAddress> salesRepresentativeAddressDboList)
        {
            try
            {
                foreach (var sAddressDbo in salesRepresentativeAddressDboList)
                {
                    salesRepresentativeAddressAPIList.Remove(
                        salesRepresentativeAddressAPIList
                            .Where(sAddressAPI =>
                                sAddressAPI.IsMainAddress == sAddressDbo.IsMainAddress &&
                                sAddressAPI.Name == sAddressDbo.Name &&
                                sAddressAPI.AddressLine == sAddressDbo.AddressLine &&
                                sAddressAPI.City == sAddressDbo.City &&
                                sAddressAPI.Neighbourhood == sAddressDbo.Neighbourhood &&
                                sAddressAPI.Number == sAddressDbo.Number &&
                                sAddressAPI.State == sAddressDbo.State &&
                                sAddressAPI.AddressNotes == sAddressDbo.AddressNotes &&
                                sAddressAPI.Landmark == sAddressDbo.Landmark &&
                                sAddressAPI.ContactName == sAddressDbo.ContactName &&
                                sAddressAPI.Latitude == sAddressDbo.Latitude &&
                                sAddressAPI.Longitude == sAddressDbo.Longitude &&
                                sAddressAPI.PostalCode == sAddressDbo.PostalCode
                            ).FirstOrDefault()
                    );
                }

                return salesRepresentativeAddressAPIList;
            }
            catch (Exception ex)
            {
                throw new InternalException(
                    stage: EnumStages.Compare,
                    error: EnumError.Compare,
                    level: EnumMessageLevel.Error,
                    message: $"Error when comparing two lists of records",
                    exceptionMessage: ex.Message
                );
            }
        }

        public bool Equals(SalesRepresentativeAddress? other)
        {
            return
                this.IsMainAddress.Equals(other.IsMainAddress) &&
                this.Name.Equals(other.Name) &&
                this.AddressLine.Equals(other.AddressLine) &&
                this.City.Equals(other.City) &&
                this.Neighbourhood.Equals(other.Neighbourhood) &&
                this.Number.Equals(other.Number) &&
                this.State.Equals(other.State) &&
                this.AddressNotes.Equals(other.AddressNotes) &&
                this.Landmark.Equals(other.Landmark) &&
                this.ContactName.Equals(other.ContactName) &&
                this.Latitude.Equals(other.Latitude) &&
                this.Longitude.Equals(other.Longitude) &&
                this.PostalCode.Equals(other.PostalCode);
        }
    }
}
