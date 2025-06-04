using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderTagValidator : AbstractValidator<OrderTag>
    {
        public OrderTagValidator()
        {
            RuleFor(x => x.Alias)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Alias | Value: {x.Alias}, Tamanho do texto: {x.Alias.Length} excede ao permitido: 50")
                .Must((x, alias) =>
                {
                    if (alias != null && alias.Length > 50)
                        x.Alias = x.Alias.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Name)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 50")
                .Must((x, name) =>
                {
                    if (name != null && name.Length > 50)
                        x.Name = x.Name.Substring(0, 50);
                    return true;
                });
        }
    }
}
