using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderTypeValidator : AbstractValidator<OrderType>
    {
        public OrderTypeValidator()
        {
            RuleFor(x => x.IntegrationID)
                .MaximumLength(50)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 50")
                .Must((x, integrationID) =>
                {
                    if (integrationID != null && integrationID.Length > 50)
                        x.IntegrationID = x.IntegrationID.Substring(0, 50);
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
