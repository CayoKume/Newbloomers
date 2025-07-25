using Application.IntegrationsCore.Validations.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movidesk.CustomValidations.Person
{
    public class AddressValidator : AbstractValidator<Domain.Movidesk.Dtos.Persons.Address>
    {
        public AddressValidator()
        {
            RuleFor(dto => dto.addressType)
               .MaximumLength(60);

            RuleFor(dto => dto.country)
               .MaximumLength(40);

            RuleFor(dto => dto.postalCode)
               .MaximumLength(9);

            RuleFor(dto => dto.state)
               .MaximumLength(20);

            RuleFor(dto => dto.district)
               .MaximumLength(60);

            RuleFor(dto => dto.city)
               .MaximumLength(40);

            RuleFor(dto => dto.street)
               .MaximumLength(250);

            RuleFor(dto => dto.number)
               .MaximumLength(20);

            RuleFor(dto => dto.complement)
               .MaximumLength(60);

            RuleFor(dto => dto.reference)
               .MaximumLength(60);

            RuleFor(dto => dto.isDefault)
               .MustBeValidBoolean();
        }
    }
}
