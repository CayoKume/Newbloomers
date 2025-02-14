using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.SalesRepresentative
{
    public class SalesRepresentativeCustomerRelation : IEquatable<SalesRepresentativeCustomerRelation>
    {
        public string? CustomerID { get; set; }
        public string? Status { get; set; }
        public string? IsMaxDiscountEnabled { get; set; }
        public int? SalesRepresentativeID { get; set; }

        public bool Equals(SalesRepresentativeCustomerRelation? other)
        {
            return
                this.CustomerID.Equals(other.CustomerID) &&
                this.Status.Equals(other.Status) &&
                this.IsMaxDiscountEnabled.Equals(other.IsMaxDiscountEnabled);
        }

        public static List<SalesRepresentativeCustomerRelation?> Compare(List<SalesRepresentativeCustomerRelation?> salesRepresentativeCustomerRelationAPIList, List<SalesRepresentativeCustomerRelation> salesRepresentativeCustomerRelationDboList)
        {
            try
            {
                foreach (var sCustomerRelationDbo in salesRepresentativeCustomerRelationDboList)
                {
                    salesRepresentativeCustomerRelationAPIList.Remove(
                        salesRepresentativeCustomerRelationAPIList
                            .Where(sCustomerRelationAPI =>
                                sCustomerRelationAPI.CustomerID == sCustomerRelationDbo.CustomerID &&
                                sCustomerRelationAPI.Status == sCustomerRelationDbo.Status &&
                                sCustomerRelationAPI.IsMaxDiscountEnabled == sCustomerRelationDbo.IsMaxDiscountEnabled
                            ).FirstOrDefault()
                    );
                }

                return salesRepresentativeCustomerRelationAPIList;
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
    }
}
