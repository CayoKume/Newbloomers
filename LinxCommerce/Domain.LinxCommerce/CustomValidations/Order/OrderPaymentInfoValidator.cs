using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderPaymentInfoValidator : AbstractValidator<OrderPaymentInfo>
    {
        public OrderPaymentInfoValidator()
        {
            RuleFor(x => x.Identifier)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Identifier | Value: {x.Identifier}, Tamanho do texto: {x.Identifier.Length} excede ao permitido: 60");

            RuleFor(x => x.Alias)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Alias | Value: {x.Alias}, Tamanho do texto: {x.Alias.Length} excede ao permitido: 50");

            RuleFor(x => x.Holder)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Holder | Value: {x.Holder}, Tamanho do texto: {x.Holder.Length} excede ao permitido: 50");

            RuleFor(x => x.NumberHint)
                .MaximumLength(50)
                .WithMessage(x => $"Property: NumberHint | Value: {x.NumberHint}, Tamanho do texto: {x.NumberHint.Length} excede ao permitido: 50");

            RuleFor(x => x.SecurityCodeHint)
                .MaximumLength(50)
                .WithMessage(x => $"Property: SecurityCodeHint | Value: {x.SecurityCodeHint}, Tamanho do texto: {x.SecurityCodeHint.Length} excede ao permitido: 50");

            RuleFor(x => x.TransactionNumber)
                .MaximumLength(50)
                .WithMessage(x => $"Property: TransactionNumber | Value: {x.TransactionNumber}, Tamanho do texto: {x.TransactionNumber.Length} excede ao permitido: 50");

            RuleFor(x => x.AuthorizationCode)
                .MaximumLength(50)
                .WithMessage(x => $"Property: AuthorizationCode | Value: {x.AuthorizationCode}, Tamanho do texto: {x.AuthorizationCode.Length} excede ao permitido: 50");

            RuleFor(x => x.ReceiptCode)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ReceiptCode | Value: {x.ReceiptCode}, Tamanho do texto: {x.ReceiptCode.Length} excede ao permitido: 50");

            RuleFor(x => x.ReconciliationNumber)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ReconciliationNumber | Value: {x.ReconciliationNumber}, Tamanho do texto: {x.ReconciliationNumber.Length} excede ao permitido: 50");

            RuleFor(x => x.ConfirmationNumber)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ConfirmationNumber | Value: {x.ConfirmationNumber}, Tamanho do texto: {x.ConfirmationNumber.Length} excede ao permitido: 50");

            RuleFor(x => x.Provider)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Provider | Value: {x.Provider}, Tamanho do texto: {x.Provider.Length} excede ao permitido: 50");

            RuleFor(x => x.ProviderDocumentNumber)
                .MaximumLength(14)
                .WithMessage(x => $"Property: ProviderDocumentNumber | Value: {x.ProviderDocumentNumber}, Tamanho do texto: {x.ProviderDocumentNumber.Length} excede ao permitido: 14");

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

            RuleFor(x => x.ExpirationDate)
                .Must((x, expirationDate) =>
                {
                    if (expirationDate == null || expirationDate.Value < new DateTime(1753, 1, 1))
                        x.ExpirationDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.ExpirationDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: ExpirationDate | Value: {x.ExpirationDate}, Error when trying to convert value: {x.ExpirationDate.ToString()} to DateTime");
        }
    }
}
