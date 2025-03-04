using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderTag : IEquatable<OrderTag>
    {
        public Int32? TagID { get; set; }
        public string? Alias { get; set; }
        public string? Name { get; set; }
        public bool? IsSystem { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? OrderID { get; set; }

        public static List<OrderTag?> Compare(List<OrderTag?> orderTagsAPIList, List<OrderTag> orderTagsDboList)
        {
            try
            {
                foreach (var oTagsDbo in orderTagsDboList)
                {
                    orderTagsAPIList.Remove(
                        orderTagsAPIList
                            .Where(oTagAPI =>
                                oTagAPI.TagID == oTagsDbo.TagID &&
                                oTagAPI.Alias == oTagsDbo.Alias &&
                                oTagAPI.Name == oTagsDbo.Name &&
                                oTagAPI.IsSystem == oTagsDbo.IsSystem &&
                                oTagAPI.IsDeleted == oTagsDbo.IsDeleted
                            ).FirstOrDefault()
                    );
                }

                return orderTagsAPIList;
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

        public bool Equals(OrderTag? other)
        {
            return
                this.TagID.Equals(other.TagID) &&
                this.Alias == other.Alias &&
                this.Name == other.Name &&
                this.IsSystem.Equals(other.IsSystem) &&
                this.IsDeleted.Equals(other.IsDeleted);
        }
    }
}
