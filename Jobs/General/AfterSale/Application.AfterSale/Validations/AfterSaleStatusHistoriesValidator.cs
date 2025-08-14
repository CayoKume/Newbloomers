using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleStatusHistoriesValidator : AbstractValidator<StatusHistories>
    {
        public AfterSaleStatusHistoriesValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.reverse_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.reverse_id));
            RuleFor(x => x.status_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.status_id));
            RuleFor(x => x.user_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.user_id));
            RuleFor(x => x.customer_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.customer_id));
            RuleFor(x => x.comments).MaximumLength(60).WithMessage("O campo 'comments' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.comments));
            RuleFor(x => x.date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.date));

            RuleFor(x => x.status)
                .SetValidator(new AfterSaleStatusValidator());
        }
    }
}
