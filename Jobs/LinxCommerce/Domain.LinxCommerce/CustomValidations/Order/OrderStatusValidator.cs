using Domain.LinxCommerce.Entities.Responses;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderStatusValidator : AbstractValidator<SearchOrderStatus.Result>
    {
        public OrderStatusValidator()
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

            RuleFor(x => x.Status)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Status | Value: {x.Status}, Tamanho do texto: {x.Status.Length} excede ao permitido: 50")
                .Must((x, status) =>
                {
                    if (status != null && status.Length > 50)
                        x.Status = x.Status.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Color)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Color | Value: {x.Color}, Tamanho do texto: {x.Color.Length} excede ao permitido: 10")
                .Must((x, color) =>
                {
                    if (color != null && color.Length > 10)
                        x.Color = x.Color.Substring(0, 10);
                    return true;
                });
        }
    }
}
