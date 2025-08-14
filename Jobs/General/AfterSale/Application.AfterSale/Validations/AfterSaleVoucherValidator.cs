using Application.Core.Validations.Extensions;
using Domain.AfterSale.Dtos;
using FluentValidation;

namespace Application.AfterSale.Validations
{
    public class AfterSaleVoucherValidator : AbstractValidator<Voucher>
    {
        public AfterSaleVoucherValidator()
        {
            RuleFor(x => x.redemption_code).MaximumLength(60).WithMessage("O campo 'redemption_code' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.redemption_code));
            RuleFor(x => x.giftcard_id).MaximumLength(60).WithMessage("O campo 'giftcard_id' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.giftcard_id));
            RuleFor(x => x.expiring_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.expiring_date));
        }
    }
}
