using Domain.IntegrationsCore.Entities.Enums;
using Domain.IntegrationsCore.Exceptions;
using Domain.IntegrationsCore.Extensions;

namespace Domain.LinxCommerce.Entities.Order
{
    public class OrderPaymentMethod : IEquatable<OrderPaymentMethod>
    {
        public Int32? OrderPaymentMethodID { get; set; }
        public Guid? OrderID { get; set; }
        public string? PaymentNumber { get; set; }
        public Int32? PaymentMethodID { get; set; }
        public Guid? TransactionID { get; set; }
        public string? ReconciliationNumber { get; set; }
        public string? Status { get; set; }
        public string? IntegrationID { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountNoInterest { get; set; }
        public decimal? InterestValue { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? RefundAmount { get; set; }
        public Int32? Installments { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? CaptureDate { get; set; }
        public DateTime? AcquiredDate { get; set; }
        public DateTime? PaymentCancelledDate { get; set; }

        [SkipProperty]
        public OrderPaymentInfo PaymentInfo { get; set; } = new OrderPaymentInfo();

        public static List<OrderPaymentMethod?> Compare(List<OrderPaymentMethod?> orderPaymentMethodAPIList, List<OrderPaymentMethod> orderPaymentMethodDboList)
        {
            try
            {
                foreach (var oPaymentMethodDbo in orderPaymentMethodDboList)
                {
                    orderPaymentMethodAPIList.Remove(
                        orderPaymentMethodAPIList
                            .Where(oPaymentMethodAPI =>
                                oPaymentMethodAPI.AcquiredDate == oPaymentMethodDbo.AcquiredDate &&
                                oPaymentMethodAPI.Amount == oPaymentMethodDbo.Amount &&
                                oPaymentMethodAPI.AmountNoInterest == oPaymentMethodDbo.AmountNoInterest &&
                                oPaymentMethodAPI.CaptureDate == oPaymentMethodDbo.CaptureDate &&
                                oPaymentMethodAPI.InstallmentAmount == oPaymentMethodDbo.InstallmentAmount &&
                                oPaymentMethodAPI.Installments == oPaymentMethodDbo.Installments &&
                                oPaymentMethodAPI.IntegrationID == oPaymentMethodDbo.IntegrationID &&
                                oPaymentMethodAPI.InterestValue == oPaymentMethodDbo.InterestValue &&
                                oPaymentMethodAPI.OrderID == oPaymentMethodDbo.OrderID &&
                                oPaymentMethodAPI.OrderPaymentMethodID == oPaymentMethodDbo.OrderPaymentMethodID &&
                                oPaymentMethodAPI.PaidAmount == oPaymentMethodDbo.PaidAmount &&
                                oPaymentMethodAPI.PaymentDate == oPaymentMethodDbo.PaymentDate &&
                                oPaymentMethodAPI.PaymentMethodID == oPaymentMethodDbo.PaymentMethodID &&
                                oPaymentMethodAPI.PaymentNumber == oPaymentMethodDbo.PaymentNumber &&
                                oPaymentMethodAPI.RefundAmount == oPaymentMethodDbo.RefundAmount &&
                                oPaymentMethodAPI.Status.Substring(0, 1).ToUpper() == oPaymentMethodDbo.Status &&
                                oPaymentMethodAPI.TaxAmount == oPaymentMethodDbo.TaxAmount &&
                                oPaymentMethodAPI.TransactionID == oPaymentMethodDbo.TransactionID &&
                                oPaymentMethodAPI.PaymentInfo == oPaymentMethodDbo.PaymentInfo
                            ).FirstOrDefault()
                    );
                }

                return orderPaymentMethodAPIList;
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

        public bool Equals(OrderPaymentMethod? other)
        {
            return
                this.AcquiredDate == other.AcquiredDate &&
                this.Amount == other.Amount &&
                this.AmountNoInterest == other.AmountNoInterest &&
                this.CaptureDate == other.CaptureDate &&
                this.InstallmentAmount == other.InstallmentAmount &&
                this.Installments == other.Installments &&
                this.IntegrationID == other.IntegrationID &&
                this.InterestValue == other.InterestValue &&
                this.OrderID == other.OrderID &&
                this.OrderPaymentMethodID == other.OrderPaymentMethodID &&
                this.PaidAmount == other.PaidAmount &&
                this.PaymentDate == other.PaymentDate &&
                this.PaymentMethodID == other.PaymentMethodID &&
                this.PaymentNumber == other.PaymentNumber &&
                this.RefundAmount == other.RefundAmount &&
                this.Status.Substring(0, 1).ToUpper() == other.Status.Substring(0, 1).ToUpper() &&
                this.TaxAmount == other.TaxAmount &&
                this.TransactionID == other.TransactionID &&
                this.PaymentInfo == other.PaymentInfo;
        }
    }
}
