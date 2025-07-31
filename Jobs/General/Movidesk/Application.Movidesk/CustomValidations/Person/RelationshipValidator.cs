using Application.Core.Validations.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movidesk.CustomValidations.Person
{
    public class RelationshipValidator : AbstractValidator<Domain.Movidesk.Dtos.Persons.Relationship>
    {
        public RelationshipValidator()
        {
            RuleFor(dto => dto.id)
                .NotEmpty().WithMessage("O 'id' não pode ser vazio.")
                .MustBeValidInt32();

            RuleFor(dto => dto.forceChildrenToHaveSomeAgreement)
                .MustBeValidBoolean();

            RuleFor(dto => dto.allowAllServices)
                .MustBeValidBoolean();

            RuleFor(dto => dto.isGetMethod)
                .MustBeValidBoolean();

            RuleFor(dto => dto.name)
               .MaximumLength(60);

            RuleFor(dto => dto.slaAgreement)
               .MaximumLength(60);
        }
    }
}
