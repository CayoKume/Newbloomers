using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleEcommerceValidator : AbstractValidator<Ecommerce>
    {
        public AfterSaleEcommerceValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.ecommerce_group_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_group_id));
            RuleFor(x => x.address_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.address_id));
            RuleFor(x => x.company_name).MaximumLength(14).WithMessage("O campo 'company_name' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.company_name));
            RuleFor(x => x.trade_name).MaximumLength(14).WithMessage("O campo 'trade_name' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.trade_name));
            RuleFor(x => x.display_name).MaximumLength(14).WithMessage("O campo 'display_name' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.display_name));
            RuleFor(x => x.url).MaximumLength(14).WithMessage("O campo 'url' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.url));
            RuleFor(x => x.phone).MaximumLength(14).WithMessage("O campo 'phone' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.phone));
            RuleFor(x => x.segment).MaximumLength(14).WithMessage("O campo 'segment' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.segment));
            RuleFor(x => x.oauth_client_id).MaximumLength(14).WithMessage("O campo 'oauth_client_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.oauth_client_id));
            RuleFor(x => x.provider_id).MaximumLength(14).WithMessage("O campo 'provider_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.provider_id));
            RuleFor(x => x.registration_origin).MaximumLength(14).WithMessage("O campo 'registration_origin' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.registration_origin));
            RuleFor(x => x.brand_id).MaximumLength(14).WithMessage("O campo 'brand_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.brand_id));
            RuleFor(x => x.app_name).MaximumLength(14).WithMessage("O campo 'app_name' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.app_name));
            RuleFor(x => x.email).MaximumLength(14).WithMessage("O campo 'email' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.email));
            RuleFor(x => x.document).MaximumLength(14).WithMessage("O campo 'document' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.document));
            RuleFor(x => x.last_order_report_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.last_order_report_date));
            RuleFor(x => x.is_active).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_active));
            RuleFor(x => x.is_test).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_test));
            RuleFor(x => x.maintenance_mode_global).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.maintenance_mode_global));
            RuleFor(x => x.uuid).MustBeValidGuid().When(x => !string.IsNullOrEmpty(x.uuid));

            RuleFor(x => x.address)
                .SetValidator(new AfterSaleAddressValidator());

            RuleForEach(x => x.reasons)
                .SetValidator(new AfterSaleReasonValidator());
        }
    }
}
