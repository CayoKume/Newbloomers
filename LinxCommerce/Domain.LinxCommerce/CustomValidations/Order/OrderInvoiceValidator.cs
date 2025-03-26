using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderInvoiceValidator : AbstractValidator<OrderInvoice>
    {
        public OrderInvoiceValidator()
        {
            RuleFor(x => x.Code)
                .MaximumLength(44)
                .WithMessage(x => $"Property: Code | Value: {x.Code}, Tamanho do texto: {x.Code.Length} excede ao permitido: 44");

            RuleFor(x => x.Url)
                .MaximumLength(800)
                .WithMessage(x => $"Property: Url | Value: {x.Url}, Tamanho do texto: {x.Url.Length} excede ao permitido: 800");

            RuleFor(x => x.Series)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Series | Value: {x.Series}, Tamanho do texto: {x.Series.Length} excede ao permitido: 10");

            RuleFor(x => x.Number)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Number | Value: {x.Number}, Tamanho do texto: {x.Number.Length} excede ao permitido: 10");

            RuleFor(x => x.CFOP)
                .MaximumLength(10)
                .WithMessage(x => $"Property: CFOP | Value: {x.CFOP}, Tamanho do texto: {x.CFOP.Length} excede ao permitido: 10");

            RuleFor(x => x.InvoicePdf)
                .MaximumLength(50)
                .WithMessage(x => $"Property: InvoicePdf | Value: {x.InvoicePdf}, Tamanho do texto: {x.InvoicePdf.Length} excede ao permitido: 50");

            RuleFor(x => x.Observation)
                .MaximumLength(120)
                .WithMessage(x => $"Property: Observation | Value: {x.Observation}, Tamanho do texto: {x.Observation.Length} excede ao permitido: 120");

            RuleFor(x => x.Operation)
                .MaximumLength(120)
                .WithMessage(x => $"Property: Operation | Value: {x.Operation}, Tamanho do texto: {x.Operation.Length} excede ao permitido: 120");

            RuleFor(x => x.ProcessedAt)
                .Must((x, processedAt) =>
                {
                    if (processedAt == null || processedAt.Value < new DateTime(1753, 1, 1))
                        x.ProcessedAt = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.ProcessedAt} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: ProcessedAt | Value: {x.ProcessedAt}, Error when trying to convert value: {x.ProcessedAt.ToString()} to DateTime");

            RuleFor(x => x.UpdatedAt)
                .Must((x, updatedAt) =>
                {
                    if (updatedAt == null || updatedAt.Value < new DateTime(1753, 1, 1))
                        x.UpdatedAt = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.UpdatedAt} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: UpdatedAt | Value: {x.UpdatedAt}, Error when trying to convert value: {x.UpdatedAt.ToString()} to DateTime");

            RuleFor(x => x.IssuedAt)
                .Must((x, issuedAt) =>
                {
                    if (issuedAt == null || issuedAt.Value < new DateTime(1753, 1, 1))
                        x.IssuedAt = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.IssuedAt} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: IssuedAt | Value: {x.IssuedAt}, Error when trying to convert value: {x.IssuedAt.ToString()} to DateTime");

            RuleFor(x => x.CreatedAt)
                .Must((x, createdAt) =>
                {
                    if (createdAt == null || createdAt.Value < new DateTime(1753, 1, 1))
                        x.CreatedAt = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.CreatedAt} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: CreatedAt | Value: {x.CreatedAt}, Error when trying to convert value: {x.CreatedAt.ToString()} to DateTime");
        }
    }
}
