﻿using Application.Core.Validations.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Stone.Validations
{
    public class StoneOwnerValidator : AbstractValidator<Domain.Stone.Dtos.Owner>
    {
        public StoneOwnerValidator()
        {
            RuleFor(x => x.id).MustBeValidGuid().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.logisticAccountId).MustBeValidGuid().When(x => !string.IsNullOrEmpty(x.logisticAccountId));
            RuleFor(x => x.name).MaximumLength(60).WithMessage("O campo 'name' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.name));
            RuleFor(x => x.document).MaximumLength(18).WithMessage("O campo 'document' deve ter no máximo 18 caractere.").When(x => !string.IsNullOrEmpty(x.document));
            RuleFor(x => x.phoneNumber).MaximumLength(20).WithMessage("O campo 'phoneNumber' deve ter no máximo 20 caractere.").When(x => !string.IsNullOrEmpty(x.phoneNumber));
        }
    }
}
