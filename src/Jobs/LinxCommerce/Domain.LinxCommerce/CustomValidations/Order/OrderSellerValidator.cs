using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderSellerValidator : AbstractValidator<OrderSeller>
    {
        public OrderSellerValidator()
        {
            RuleFor(x => x.EMail)
                .MaximumLength(60)
                .WithMessage(x => $"Property: EMail | Value: {x.EMail}, Tamanho do texto: {x.EMail.Length} excede ao permitido: 60")
                .Must((x, email) =>
                {
                    if (email != null && email.Length > 60)
                        x.EMail = x.EMail.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.IntegrationID)
                .MaximumLength(20)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 20")
                .Must((x, integrationID) =>
                {
                    if (integrationID != null && integrationID.Length > 20)
                        x.IntegrationID = x.IntegrationID.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.Name)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 60")
                .Must((x, name) =>
                {
                    if (name != null && name.Length > 60)
                        x.Name = x.Name.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Phone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: Phone | Value: {x.Phone}, Tamanho do texto: {x.Phone.Length} excede ao permitido: 20")
                .Must((x, phone) =>
                {
                    if (phone != null && phone.Length > 20)
                        x.Phone = x.Phone.Substring(0, 20);
                    return true;
                });
        }
    }
}
