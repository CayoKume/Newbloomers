using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleBankValidator : AbstractValidator<Bank>
    {
        public AfterSaleBankValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.name).MaximumLength(60).WithMessage("O campo 'name' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.name));
            RuleFor(x => x.description).MaximumLength(60).WithMessage("O campo 'description' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.description));
        }
    }
}
