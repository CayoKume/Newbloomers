using Application.Core.Validations.Extensions;
using Domain.AfterSale.Dtos;
using FluentValidation;

namespace Application.AfterSale.Validations
{
    public class AfterSaleDestinationValidator : AbstractValidator<Destination>
    {
        public AfterSaleDestinationValidator()
        {
            RuleFor(x => x.name).MaximumLength(60).WithMessage("O campo 'name' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.name));
            RuleFor(x => x.type).MaximumLength(60).WithMessage("O campo 'type' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.type));
            RuleFor(x => x.type_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.type_id));
            RuleFor(x => x.seller_id).MaximumLength(60).WithMessage("O campo 'seller_id' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.seller_id));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.seller_info).MaximumLength(60).WithMessage("O campo 'seller_info' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.seller_info));
            RuleFor(x => x.return_to_seller).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.return_to_seller));
            RuleFor(x => x.was_manually_changed).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.was_manually_changed));
            RuleFor(x => x.label).MaximumLength(60).WithMessage("O campo '@long' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.label));

            RuleFor(x => x.address)
                .SetValidator(new AfterSaleAddressValidator());
        }
    }
}
