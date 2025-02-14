using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.LinxCommerce.Entities.SalesRepresentative;

namespace Domain.LinxCommerce.Entities.Customer
{
    public class PersonAddress : IEquatable<PersonAddress>
    {
        public Int32? ID { get; set; }
        public string? Name { get; set; }
        public string? ContactName { get; set; }
        public string? PostalCode { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Number { get; set; }
        public string? State { get; set; }
        public string? AddressNotes { get; set; }
        public string? Landmark { get; set; }
        public bool? MainAddress { get; set; }
        public Int32? CustomerID { get; set; }

        public static List<PersonAddress?> Compare(List<PersonAddress?> personAddressAPIList, List<PersonAddress> personAddressDboList)
        {
            try
            {
                foreach (var pAddressDbo in personAddressDboList)
                {
                    personAddressAPIList.Remove(
                        personAddressAPIList
                            .Where(pAddressAPI =>
                                pAddressAPI.ID == pAddressDbo.ID &&
                                pAddressAPI.Name == pAddressDbo.Name &&
                                pAddressAPI.ContactName == pAddressDbo.ContactName &&
                                pAddressAPI.PostalCode == pAddressDbo.PostalCode &&
                                pAddressAPI.AddressLine == pAddressDbo.AddressLine &&
                                pAddressAPI.City == pAddressDbo.City &&
                                pAddressAPI.Neighbourhood == pAddressDbo.Neighbourhood &&
                                pAddressAPI.Number == pAddressDbo.Number &&
                                pAddressAPI.State == pAddressDbo.State &&
                                pAddressAPI.AddressNotes == pAddressDbo.AddressNotes &&
                                pAddressAPI.Landmark == pAddressDbo.Landmark &&
                                pAddressAPI.MainAddress == pAddressDbo.MainAddress
                            ).FirstOrDefault()
                    );
                }

                return personAddressAPIList;
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

        public bool Equals(PersonAddress? other)
        {
            return
                this.ID.Equals(other.ID) &&
                this.Name.Equals(other.Name) &&
                this.ContactName.Equals(other.ContactName) &&
                this.PostalCode.Equals(other.PostalCode) &&
                this.AddressLine.Equals(other.AddressLine) &&
                this.City.Equals(other.City) &&
                this.Neighbourhood.Equals(other.Neighbourhood) &&
                this.Number.Equals(other.Number) &&
                this.State.Equals(other.State) &&
                this.AddressNotes.Equals(other.AddressNotes) &&
                this.Landmark.Equals(other.Landmark) &&
                this.MainAddress.Equals(other.MainAddress);
        }
    }
}
