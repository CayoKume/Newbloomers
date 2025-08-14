using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleProductValidator : AbstractValidator<Product>
    {
        public AfterSaleProductValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.reverse_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.reverse_id));
            RuleFor(x => x.motive_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.motive_id));
            RuleFor(x => x.ecommerce_order_product_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_order_product_id));
            RuleFor(x => x.refund_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.refund_id));
            RuleFor(x => x.qty).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.qty));
            RuleFor(x => x.requested_qty).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.requested_qty));
            RuleFor(x => x.received_qty).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.received_qty));
            RuleFor(x => x.order_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.order_id));
            RuleFor(x => x.product_received_comment).MaximumLength(150).WithMessage("O campo 'product_received_comment' deve ter no máximo 150 caracteres.").When(x => !string.IsNullOrEmpty(x.product_received_comment));
            RuleFor(x => x.comments).MaximumLength(60).WithMessage("O campo 'comments' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.comments));
            RuleFor(x => x.reverse_action).MaximumLength(60).WithMessage("O campo 'reverse_action' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.reverse_action));
            RuleFor(x => x.customer_retention_method_id).MaximumLength(60).WithMessage("O campo 'customer_retention_method_id' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.customer_retention_method_id));
            RuleFor(x => x.protocol).MaximumLength(60).WithMessage("O campo 'protocol' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.protocol));
            RuleFor(x => x.product_id).MaximumLength(60).WithMessage("O campo 'product_id' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.product_id));
            RuleFor(x => x.hash).MaximumLength(60).WithMessage("O campo 'hash' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.hash));
            RuleFor(x => x.name).MaximumLength(60).WithMessage("O campo 'name' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.name));
            RuleFor(x => x.sku).MaximumLength(60).WithMessage("O campo 'sku' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.sku));
            RuleFor(x => x.price).MaximumLength(60).WithMessage("O campo 'price' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.price));
            RuleFor(x => x.selling_price).MaximumLength(60).WithMessage("O campo 'selling_price' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.selling_price));
            RuleFor(x => x.weight).MaximumLength(60).WithMessage("O campo 'weight' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.weight));
            RuleFor(x => x.returned_invoice).MaximumLength(60).WithMessage("O campo 'returned_invoice' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.returned_invoice));
            RuleFor(x => x.invoice).MaximumLength(60).WithMessage("O campo 'invoice' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.invoice));

            RuleFor(x => x.reason)
                .SetValidator(new AfterSaleReasonValidator());
        }
    }
}
