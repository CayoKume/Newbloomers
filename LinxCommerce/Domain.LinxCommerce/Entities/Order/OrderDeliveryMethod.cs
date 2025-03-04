using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderDeliveryMethod : IEquatable<OrderDeliveryMethod>
    {
        public string? LogisticOptionId { get; set; }
        public string? LogisticOptionName { get; set; }
        public string? LogisticContractId { get; set; }
        public string? LogisticContractName { get; set; }
        public Int32? OrderDeliveryMethodID { get; set; }
        public Guid OrderID { get; set; }
        public Int32? DeliveryMethodID { get; set; }
        public Int32? DeliveryGroupID { get; set; }
        public decimal? Amount { get; set; }
        public string? ETA { get; set; }
        public Int32? ETADays { get; set; }
        public Int64? IntegrationID { get; set; }
        public Int64? ScheduleShiftID { get; set; }
        public string? ScheduleDisplayName { get; set; }
        public decimal? ScheduleTax { get; set; }
        //public DateTime? ScheduleStartTime { get; set; }
        //public DateTime? ScheduleEndTime { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string? DeliveryMethodAlias { get; set; }
        public Int32? PointOfSaleID { get; set; }
        public string? PointOfSaleIntegrationID { get; set; }
        public string? PointOfSaleName { get; set; }
        public string? DeliveryMethodType { get; set; }
        public string? DeliveryLogisticType { get; set; }
        public string? ExternalID { get; set; }
        public Int32? WarehouseID { get; set; }
        public string? WarehouseIntegrationID { get; set; }
        public Int32? DockID { get; set; }
        public string? CarrierName { get; set; }
        public DateTime? DeliveryEstimatedDate { get; set; }

        public static List<OrderDeliveryMethod?> Compare(List<OrderDeliveryMethod?> orderDeliveryAPIList, List<OrderDeliveryMethod> orderDeliveryDboList)
        {
            try
            {
                foreach (var oDeliveryDbo in orderDeliveryDboList)
                {
                    orderDeliveryAPIList.Remove(
                        orderDeliveryAPIList
                            .Where(oDeliveryAPI =>
                                oDeliveryAPI.Amount == oDeliveryDbo.Amount &&
                                oDeliveryAPI.CarrierName == oDeliveryDbo.CarrierName &&
                                oDeliveryAPI.DeliveryMethodID == oDeliveryDbo.DeliveryMethodID &&
                                oDeliveryAPI.LogisticContractId == oDeliveryDbo.LogisticContractId &&
                                oDeliveryAPI.LogisticContractName == oDeliveryDbo.LogisticContractName &&
                                oDeliveryAPI.LogisticOptionId == oDeliveryDbo.LogisticOptionId &&
                                oDeliveryAPI.LogisticOptionName == oDeliveryDbo.LogisticOptionName
                            ).FirstOrDefault()
                    );
                }

                return orderDeliveryAPIList;
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

        public bool Equals(OrderDeliveryMethod? other)
        {
            return
                this.Amount == other.Amount &&
                this.CarrierName == other.CarrierName &&
                this.DeliveryMethodID == other.DeliveryMethodID &&
                this.LogisticContractId == other.LogisticContractId &&
                this.LogisticContractName == other.LogisticContractName &&
                this.LogisticOptionId == other.LogisticOptionId &&
                this.LogisticOptionName == other.LogisticOptionName;
        }
    }
}
