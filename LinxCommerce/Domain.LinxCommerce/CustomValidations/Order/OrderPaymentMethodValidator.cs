using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderPaymentMethodValidator : AbstractValidator<OrderPaymentMethod>
    {
        public OrderPaymentMethodValidator()
        {
            RuleFor(x => x.PaymentNumber)
                .MaximumLength(10)
                .WithMessage(x => $"Property: PaymentNumber | Value: {x.PaymentNumber}, Tamanho do texto: {x.PaymentNumber.Length} excede ao permitido: 10");

            RuleFor(x => x.ReconciliationNumber)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ReconciliationNumber | Value: {x.ReconciliationNumber}, Tamanho do texto: {x.ReconciliationNumber.Length} excede ao permitido: 50");

            RuleFor(x => x.Status)
                .MaximumLength(1)
                .WithMessage(x => $"Property: Status | Value: {x.Status}, Tamanho do texto: {x.Status.Length} excede ao permitido: 1");

            RuleFor(x => x.IntegrationID)
                .MaximumLength(50)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 50");

            RuleFor(x => x.PaymentDate)
                .Must((x, paymentDate) =>
                {
                    if (paymentDate == null || paymentDate.Value < new DateTime(1753, 1, 1))
                        x.PaymentDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.PaymentDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: PaymentDate | Value: {x.PaymentDate}, Error when trying to convert value: {x.PaymentDate.ToString()} to DateTime");

            RuleFor(x => x.CaptureDate)
                .Must((x, captureDate) =>
                {
                    if (captureDate == null || captureDate.Value < new DateTime(1753, 1, 1))
                        x.CaptureDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.CaptureDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: CaptureDate | Value: {x.CaptureDate}, Error when trying to convert value: {x.CaptureDate.ToString()} to DateTime");

            RuleFor(x => x.AcquiredDate)
                .Must((x, acquiredDate) =>
                {
                    if (acquiredDate == null || acquiredDate.Value < new DateTime(1753, 1, 1))
                        x.AcquiredDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.AcquiredDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: AcquiredDate | Value: {x.AcquiredDate}, Error when trying to convert value: {x.AcquiredDate.ToString()} to DateTime");

            RuleFor(x => x.PaymentCancelledDate)
                .Must((x, paymentCancelledDate) =>
                {
                    if (paymentCancelledDate == null || paymentCancelledDate.Value < new DateTime(1753, 1, 1))
                        x.PaymentCancelledDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.PaymentCancelledDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: PaymentCancelledDate | Value: {x.PaymentCancelledDate}, Error when trying to convert value: {x.PaymentCancelledDate.ToString()} to DateTime");

            RuleFor(x => x.PaymentInfo)
                .SetValidator(new OrderPaymentInfoValidator());
        }
    }
}
