using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderAddress : IEquatable<OrderAddress>
    {
        public Int32? OrderAddressID { get; set; }
        public Guid? OrderID { get; set; }
        public string? Name { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Neighbourhood { get; set; }
        public string? Number { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? AddressNotes { get; set; }
        public string? Landmark { get; set; }
        public string? ContactName { get; set; }
        public string? ContactDocumentNumber { get; set; }
        public Int32? AddressType { get; set; }
        public Int32? PointOfSaleID { get; set; }
        public string? ContactPhone { get; set; }

        public static List<OrderAddress?> Compare(List<OrderAddress?> orderAddressAPIList, List<OrderAddress> orderAddressDboList)
        {
            try
            {
                foreach (var oAddressDbo in orderAddressDboList)
                {
                    orderAddressAPIList.Remove(
                        orderAddressAPIList
                            .Where(oAddressAPI =>
                                oAddressAPI.AddressLine == oAddressDbo.AddressLine &&
                                oAddressAPI.AddressNotes == oAddressDbo.AddressNotes &&
                                oAddressAPI.AddressType == oAddressDbo.AddressType &&
                                oAddressAPI.City == oAddressDbo.City &&
                                oAddressAPI.ContactName == oAddressDbo.ContactName &&
                                oAddressAPI.ContactPhone == oAddressDbo.ContactPhone &&
                                oAddressAPI.Landmark == oAddressDbo.Landmark &&
                                oAddressAPI.Name == oAddressDbo.Name &&
                                oAddressAPI.Neighbourhood == oAddressDbo.Neighbourhood &&
                                oAddressAPI.Number == oAddressDbo.Number &&
                                oAddressAPI.OrderAddressID == oAddressDbo.OrderAddressID &&
                                oAddressAPI.OrderID == oAddressDbo.OrderID &&
                                oAddressAPI.PostalCode == oAddressDbo.PostalCode.Trim() &&
                                oAddressAPI.State == oAddressDbo.State
                            ).FirstOrDefault()
                    );
                }

                return orderAddressAPIList;
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

        public bool Equals(OrderAddress? other)
        {
            return
                this.AddressLine == other.AddressLine &&
                this.AddressNotes == other.AddressNotes &&
                this.AddressType == other.AddressType &&
                this.City == other.City &&
                this.ContactName == other.ContactName &&
                this.ContactPhone == other.ContactPhone &&
                this.Landmark == other.Landmark &&
                this.Name == other.Name &&
                this.Neighbourhood == other.Neighbourhood &&
                this.Number == other.Number &&
                this.OrderAddressID == other.OrderAddressID &&
                this.OrderID == other.OrderID &&
                this.PostalCode.Trim() == other.PostalCode &&
                this.State == other.State;
        }
    }
}
