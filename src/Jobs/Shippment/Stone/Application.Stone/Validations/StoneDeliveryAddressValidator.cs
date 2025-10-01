﻿using Application.Core.Validations.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Stone.Validations
{
    public class StoneDeliveryAddressValidator : AbstractValidator<Domain.Stone.Dtos.Deliveryaddress>
    {
        public StoneDeliveryAddressValidator()
        {
            RuleFor(x => x.key).MaximumLength(800).WithMessage("O campo 'key' deve ter no máximo 800 caractere.").When(x => !string.IsNullOrEmpty(x.key));
            RuleFor(x => x.city).MaximumLength(40).WithMessage("O campo 'city' deve ter no máximo 40 caractere.").When(x => !string.IsNullOrEmpty(x.city));
            RuleFor(x => x.address).MaximumLength(250).WithMessage("O campo 'address' deve ter no máximo 250 caractere.").When(x => !string.IsNullOrEmpty(x.address));
            RuleFor(x => x.country).MaximumLength(60).WithMessage("O campo 'country' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.country));
            RuleFor(x => x.zipCode).MaximumLength(9).WithMessage("O campo 'zipCode' deve ter no máximo 9 caractere.").When(x => !string.IsNullOrEmpty(x.zipCode));
            RuleFor(x => x.latitude).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.latitude));
            RuleFor(x => x.longitude).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.longitude));
            RuleFor(x => x.accountId).MustBeValidGuid().When(x => !string.IsNullOrEmpty(x.accountId));
            RuleFor(x => x.complement).MaximumLength(60).WithMessage("O campo 'complement' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.complement));
            RuleFor(x => x.countryState).MaximumLength(2).WithMessage("O campo 'countryState' deve ter no máximo 2 caractere.").When(x => !string.IsNullOrEmpty(x.countryState));
            RuleFor(x => x.locationType).MaximumLength(60).WithMessage("O campo 'locationType' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.locationType));
            RuleFor(x => x.neighborhood).MaximumLength(60).WithMessage("O campo 'neighborhood' deve ter no máximo 60 caractere.").When(x => !string.IsNullOrEmpty(x.neighborhood));
            RuleFor(x => x.addressNumber).MaximumLength(20).WithMessage("O campo 'addressNumber' deve ter no máximo 20 caractere.").When(x => !string.IsNullOrEmpty(x.addressNumber));
        }
    }
}
