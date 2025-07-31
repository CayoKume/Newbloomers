using Domain.LinxCommerce.Entities.Customer;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Customer
{
    public class GroupsValidator : AbstractValidator<Groups>
    {
        public GroupsValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Title | Value: {x.Title}, Tamanho do texto: {x.Title.Length} excede ao permitido: 60")
                .Must((x, title) =>
                {
                    if (title != null && title.Length > 60)
                        x.Title = x.Title.Substring(0, 60);
                    return true;
                });
        }
    }
}
