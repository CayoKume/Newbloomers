using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderDiscountValidator : AbstractValidator<OrderDiscount>
    {
        public OrderDiscountValidator()
        {
            //adicionar no repository as colunas em null
            RuleFor(x => x.Message)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Message | Value: {x.Message}, Tamanho do texto: {x.Message.Length} excede ao permitido: 60")
                .Must((x, message) =>
                {
                    if (message != null && message.Length > 60)
                        x.Message = x.Message.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Reference)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Reference | Value: {x.Reference}, Tamanho do texto: {x.Reference.Length} excede ao permitido: 60")
                .Must((x, reference) =>
                {
                    if (reference != null && reference.Length > 60)
                        x.Reference = x.Reference.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.Type)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Type | Value: {x.Type}, Tamanho do texto: {x.Type.Length} excede ao permitido: 60")
                .Must((x, type) =>
                {
                    if (type != null && type.Length > 60)
                        x.Type = x.Type.Substring(0, 60);
                    return true;
                });
        }
    }
}
