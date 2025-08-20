using Domain.AfterSale.Dtos;
using FluentValidation;

namespace Application.AfterSale.Validations
{
    public class AfterSaleTransportationsValidator : AbstractValidator<Transportations>
    {
        public AfterSaleTransportationsValidator()
        {
            RuleForEach(x => x.data)
                .MaximumLength(60).WithMessage("O campo 'name' deve ter no máximo 60 caracteres.");
        }
    }
}
