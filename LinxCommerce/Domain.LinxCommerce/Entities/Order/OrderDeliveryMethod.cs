namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderDeliveryMethod
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
        public DateTime? ScheduleStartTime { get; set; }
        public DateTime? ScheduleEndTime { get; set; }
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
    }
}
