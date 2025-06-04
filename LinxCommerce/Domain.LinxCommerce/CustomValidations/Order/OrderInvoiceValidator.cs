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
                .WithMessage(x => $"Property: Code | Value: {x.Code}, Tamanho do texto: {x.Code.Length} excede ao permitido: 44")
                .Must((x, code) =>
                {
                    if (code != null && code.Length > 44)
                        x.Code = x.Code.Substring(0, 44);
                    return true;
                });

            RuleFor(x => x.Url)
                .MaximumLength(800)
                .WithMessage(x => $"Property: Url | Value: {x.Url}, Tamanho do texto: {x.Url.Length} excede ao permitido: 800")
                .Must((x, url) =>
                {
                    if (url != null && url.Length > 800)
                        x.Url = x.Url.Substring(0, 800);
                    return true;
                });

            RuleFor(x => x.Series)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Series | Value: {x.Series}, Tamanho do texto: {x.Series.Length} excede ao permitido: 10")
                .Must((x, series) =>
                {
                    if (series != null && series.Length > 10)
                        x.Series = x.Series.Substring(0, 10);
                    return true;
                });

            RuleFor(x => x.Number)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Number | Value: {x.Number}, Tamanho do texto: {x.Number.Length} excede ao permitido: 10")
                .Must((x, number) =>
                {
                    if (number != null && number.Length > 10)
                        x.Number = x.Number.Substring(0, 10);
                    return true;
                });

            RuleFor(x => x.CFOP)
                .MaximumLength(10)
                .WithMessage(x => $"Property: CFOP | Value: {x.CFOP}, Tamanho do texto: {x.CFOP.Length} excede ao permitido: 10")
                .Must((x, cfop) =>
                {
                    if (cfop != null && cfop.Length > 10)
                        x.CFOP = x.CFOP.Substring(0, 10);
                    return true;
                });

            RuleFor(x => x.InvoicePdf)
                .MaximumLength(50)
                .WithMessage(x => $"Property: InvoicePdf | Value: {x.InvoicePdf}, Tamanho do texto: {x.InvoicePdf.Length} excede ao permitido: 50")
                .Must((x, invoicePdf) =>
                {
                    if (invoicePdf != null && invoicePdf.Length > 50)
                        x.InvoicePdf = x.InvoicePdf.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Observation)
                .MaximumLength(120)
                .WithMessage(x => $"Property: Observation | Value: {x.Observation}, Tamanho do texto: {x.Observation.Length} excede ao permitido: 120")
                .Must((x, observation) =>
                {
                    if (observation != null && observation.Length > 120)
                        x.Observation = x.Observation.Substring(0, 120);
                    return true;
                });

            RuleFor(x => x.Operation)
                .MaximumLength(120)
                .WithMessage(x => $"Property: Operation | Value: {x.Operation}, Tamanho do texto: {x.Operation.Length} excede ao permitido: 120")
                .Must((x, operation) =>
                {
                    if (operation != null && operation.Length > 120)
                        x.Operation = x.Operation.Substring(0, 120);
                    return true;
                });

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
