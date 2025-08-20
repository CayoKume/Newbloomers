using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AfterSale.Validations
{
    public class AfterSaleCourierDataEncryptedValidator : AbstractValidator<Domain.AfterSale.Dtos.CourierDataEncrypted>
    {
        public AfterSaleCourierDataEncryptedValidator()
        {
            RuleFor(x => x.posting_card).MaximumLength(14).WithMessage("O campo 'posting_card' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.posting_card));
            RuleFor(x => x.is_store_seller_contract).MaximumLength(14).WithMessage("O campo 'is_store_seller_contract' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.is_store_seller_contract));
        }
    }
}
