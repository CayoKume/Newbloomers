using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Customer;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Customer
{
    public class EmailConfirmationValidator : AbstractValidator<EmailConfirmation>
    {
        public EmailConfirmationValidator()
        {
            RuleFor(x => x.Status)
                .MaximumLength(1)
                .WithMessage(x => $"Property: Status | Value: {x.Status}, Tamanho do texto: {x.Status.Length} excede ao permitido: 1")
                .Must((x, status) =>
                {
                    if (status != null && status.Length > 1)
                        x.Status = x.Status.Substring(0, 1);
                    return true;
                });
        }
    }
}
