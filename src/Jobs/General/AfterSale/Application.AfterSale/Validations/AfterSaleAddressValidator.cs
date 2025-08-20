using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleAddressValidator : AbstractValidator<Address>
    {
        public AfterSaleAddressValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.zip_code).MaximumLength(9).WithMessage("O campo 'zip_code' deve ter no máximo 9 caractere.").When(x => !string.IsNullOrEmpty(x.zip_code));
            RuleFor(x => x.address).MaximumLength(250).WithMessage("O campo 'address' deve ter no máximo 250 caractere.").When(x => !string.IsNullOrEmpty(x.address));
            RuleFor(x => x.complement).MaximumLength(60).WithMessage("O campo 'complement' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.complement));
            RuleFor(x => x.number).MaximumLength(20).WithMessage("O campo 'number' deve ter no máximo 20 caractere.").When(x => !string.IsNullOrEmpty(x.number));
            RuleFor(x => x.neighborhood).MaximumLength(60).WithMessage("O campo 'neighborhood' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.neighborhood));
            RuleFor(x => x.city).MaximumLength(40).WithMessage("O campo 'city' deve ter no máximo 40 caractere.").When(x => !string.IsNullOrEmpty(x.city));
            RuleFor(x => x.state).MaximumLength(20).WithMessage("O campo 'state' deve ter no máximo 20 caractere.").When(x => !string.IsNullOrEmpty(x.state));
            RuleFor(x => x.lat).MaximumLength(60).WithMessage("O campo 'lat' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.lat));
            RuleFor(x => x.@long).MaximumLength(60).WithMessage("O campo '@long' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.@long));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.deleted_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.deleted_at));
        }
    }
}
