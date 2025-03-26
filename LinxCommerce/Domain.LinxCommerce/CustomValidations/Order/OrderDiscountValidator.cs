using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderDiscountValidator : AbstractValidator<OrderDiscount>
    {
        public OrderDiscountValidator()
        {
            RuleFor(x => x.Message)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Message | Value: {x.Message}, Tamanho do texto: {x.Message.Length} excede ao permitido: 60");

            RuleFor(x => x.Reference)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Reference | Value: {x.Reference}, Tamanho do texto: {x.Reference.Length} excede ao permitido: 60");

            RuleFor(x => x.Type)
                .MaximumLength(60)
                .WithMessage(x => $"Property: Type | Value: {x.Type}, Tamanho do texto: {x.Type.Length} excede ao permitido: 60");
        }
    }
}
