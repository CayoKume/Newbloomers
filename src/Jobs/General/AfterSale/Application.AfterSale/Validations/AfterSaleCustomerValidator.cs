using Application.Core.Validations.Extensions;
using Domain.AfterSale.Dtos;
using FluentValidation;

namespace Application.AfterSale.Validations
{
    public class AfterSaleCustomerValidator : AbstractValidator<Customer>
    {
        public AfterSaleCustomerValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.address_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.address_id));
            RuleFor(x => x.contact_email).MaximumLength(50).WithMessage("O campo 'contact_email' deve ter no máximo 50 caractere.").When(x => !string.IsNullOrEmpty(x.contact_email));
            RuleFor(x => x.document).MaximumLength(14).WithMessage("O campo 'document' deve ter no máximo 14 caractere.").When(x => !string.IsNullOrEmpty(x.document));
            RuleFor(x => x.email).MaximumLength(50).WithMessage("O campo 'email' deve ter no máximo 50 caractere.").When(x => !string.IsNullOrEmpty(x.email));
            RuleFor(x => x.first_name).MaximumLength(60).WithMessage("O campo 'first_name' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.first_name));
            RuleFor(x => x.last_name).MaximumLength(60).WithMessage("O campo 'last_name' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.last_name));
            RuleFor(x => x.phone).MaximumLength(30).WithMessage("O campo 'phone' deve ter no máximo 30 caractere.").When(x => !string.IsNullOrEmpty(x.phone));
            RuleFor(x => x.shipping_address_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.shipping_address_id));
            
            RuleFor(x => x.shipping_address)
                .SetValidator(new AfterSaleAddressValidator());
            
            RuleFor(x => x.address)
                .SetValidator(new AfterSaleAddressValidator());
        }
    }
}
