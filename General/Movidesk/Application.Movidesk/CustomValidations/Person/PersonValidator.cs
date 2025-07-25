using Application.IntegrationsCore.Validations.Extensions;
using FluentValidation;

namespace Application.Movidesk.CustomValidations.Person
{
    public class PersonValidator : AbstractValidator<Domain.Movidesk.Dtos.Persons.Person>
    {
        public PersonValidator()
        {
            RuleFor(dto => dto.id)
                .NotEmpty().WithMessage("O 'id' não pode ser vazio.")
                .MustBeValidInt64();

            RuleFor(dto => dto.personType)
                .NotEmpty().WithMessage("O 'id' não pode ser vazio.")
                .MustBeValidInt32();

            RuleFor(dto => dto.profileType)
                .NotEmpty().WithMessage("O 'id' não pode ser vazio.")
                .MustBeValidInt32();

            RuleFor(dto => dto.isActive)
                .MustBeValidBoolean();

            RuleFor(dto => dto.createdDate)
                .MustBeValidDateTime();

            RuleFor(dto => dto.codeReferenceAdditional)
               .MaximumLength(60);

            RuleFor(dto => dto.accessProfile)
               .MaximumLength(60);

            RuleFor(dto => dto.businessName)
               .MaximumLength(60);

            RuleFor(dto => dto.corporateName)
               .MaximumLength(60);

            RuleFor(dto => dto.cpfCnpj)
               .MaximumLength(14);

            RuleFor(dto => dto.userName)
               .MaximumLength(60);

            RuleFor(dto => dto.role)
               .MaximumLength(60);

            RuleFor(dto => dto.bossId)
               .MaximumLength(60);

            RuleFor(dto => dto.classification)
               .MaximumLength(60);

            RuleFor(dto => dto.cultureId)
               .MaximumLength(10);

            RuleFor(dto => dto.timeZoneId)
               .MaximumLength(60);

            RuleFor(dto => dto.observations)
               .MaximumLength(300);

            RuleForEach(x => x.addresses)
                .SetValidator(new AddressValidator());

            RuleForEach(x => x.contacts)
                .SetValidator(new ContactValidator());

            RuleForEach(x => x.emails)
                .SetValidator(new EmailValidator());

            RuleForEach(x => x.relationships)
                .SetValidator(new RelationshipValidator());
        }
    }
}
