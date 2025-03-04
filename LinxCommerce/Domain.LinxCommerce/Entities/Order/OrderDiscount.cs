using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderDiscount : IEquatable<OrderDiscount>
    {
        public decimal? Amount { get; set; }
        public Int32? DiscountID { get; set; }
        public string? Message { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public Guid? OrderID { get; set; }

        public static List<OrderDiscount?> Compare(List<OrderDiscount?> orderDiscountAPIList, List<OrderDiscount> orderDiscountDboList)
        {
            try
            {
                foreach (var oDiscountDbo in orderDiscountDboList)
                {
                    orderDiscountAPIList.Remove(
                        orderDiscountAPIList
                            .Where(oDiscountAPI =>
                                oDiscountAPI.Amount == oDiscountAPI.Amount &&
                                oDiscountAPI.DiscountID == oDiscountDbo.DiscountID &&
                                oDiscountAPI.Message == oDiscountDbo.Message &&
                                oDiscountAPI.Reference == oDiscountDbo.Reference &&
                                oDiscountAPI.Type == oDiscountDbo.Type
                            ).FirstOrDefault()
                    );
                }

                return orderDiscountAPIList;
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

        public bool Equals(OrderDiscount? other)
        {
            return
                this.Amount == other.Amount &&
                this.DiscountID.Equals(other.DiscountID) &&
                this.Message == other.Message &&
                this.Reference == other.Reference &&
                this.Type == other.Type;
        }
    }
}
