using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleTotalAmountHistoriesValidator : AbstractValidator<TotalAmountHistories>
    {
        public AfterSaleTotalAmountHistoriesValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.refund_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.refund_id));
            RuleFor(x => x.date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.date));
            RuleFor(x => x.total_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.total_amount));

            RuleFor(x => x.type)
                .SetValidator(new AfterSaleTypeValidator());

            RuleFor(x => x.Refund)
                .SetValidator(new AfterSaleRefundValidator());
        }
    }
}
