using Application.Core.Validations.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movidesk.CustomValidations.Person
{
    public class EmailValidator : AbstractValidator<Domain.Movidesk.Dtos.Persons.Email>
    {
        public EmailValidator()
        {
            RuleFor(dto => dto.emailType)
               .MaximumLength(20);

            RuleFor(dto => dto.email)
               .MaximumLength(60);

            RuleFor(dto => dto.isDefault)
               .MustBeValidBoolean();
        }
    }
}
