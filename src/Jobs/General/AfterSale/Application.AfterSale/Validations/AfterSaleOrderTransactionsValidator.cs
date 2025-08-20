using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleOrderTransactionsValidator : AbstractValidator<OrderTransactions>
    {
        public AfterSaleOrderTransactionsValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.refund_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.refund_id));
            RuleFor(x => x.ecommerce_order_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_order_id));
            RuleFor(x => x.transaction_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.transaction_id));
            RuleFor(x => x.acquirer).MaximumLength(14).WithMessage("O campo 'acquirer' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.acquirer));
            RuleFor(x => x.nsu).MaximumLength(14).WithMessage("O campo 'nsu' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.nsu));
            RuleFor(x => x.tid).MaximumLength(14).WithMessage("O campo 'tid' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.tid));
            RuleFor(x => x.merchant_name).MaximumLength(14).WithMessage("O campo 'merchant_name' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.merchant_name));
            RuleFor(x => x.date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.date));
            RuleFor(x => x.total_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.total_amount));
        }
    }
}
