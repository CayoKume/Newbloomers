using Application.Core.Validations.Extensions;
using FluentValidation;

namespace Application.Movidesk.CustomValidations.Person
{
    public class ContactValidator : AbstractValidator<Domain.Movidesk.Dtos.Persons.Contact>
    {
        public ContactValidator()
        {
            RuleFor(dto => dto.contactType)
               .MaximumLength(20);

            RuleFor(dto => dto.contact)
               .MaximumLength(20);

            RuleFor(dto => dto.isDefault)
               .MustBeValidBoolean();
        }
    }
}
