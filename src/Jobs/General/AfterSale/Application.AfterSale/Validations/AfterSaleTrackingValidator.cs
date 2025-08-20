using Domain.Core.Extensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleTrackingValidator : AbstractValidator<Tracking>
    {
        public AfterSaleTrackingValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.reverse_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.reverse_id));
            RuleFor(x => x.courier_contract_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.courier_contract_id));
            RuleFor(x => x.authorization_code).MaximumLength(60).WithMessage("O campo 'authorization_code' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.authorization_code));
            RuleFor(x => x.tracking_code).MaximumLength(60).WithMessage("O campo 'tracking_code' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.tracking_code));
            RuleFor(x => x.courier_name).MaximumLength(60).WithMessage("O campo 'courier_name' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.courier_name));
            RuleFor(x => x.tracking_url).MaximumLength(4000).WithMessage("O campo 'tracking_url' deve ter no máximo 4000 caracteres.").When(x => !string.IsNullOrEmpty(x.tracking_url));
            RuleFor(x => x.status).MaximumLength(50).WithMessage("O campo 'status' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.status));
            RuleFor(x => x.message).MaximumLength(60).WithMessage("O campo 'message' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.message));
            RuleFor(x => x.type).MaximumLength(60).WithMessage("O campo 'type' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.type));
            RuleFor(x => x.qr_code).MaximumLength(60).WithMessage("O campo 'qr_code' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.qr_code));
            RuleFor(x => x.service_type).MaximumLength(60).WithMessage("O campo 'service_type' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.service_type));
            RuleFor(x => x.cte).MaximumLength(60).WithMessage("O campo 'cte' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.cte));
            RuleFor(x => x.delivery_deadline).MaximumLength(60).WithMessage("O campo 'delivery_deadline' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.delivery_deadline));
            RuleFor(x => x.extra_fields).MaximumLength(60).WithMessage("O campo 'extra_fields' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.extra_fields));
            RuleFor(x => x.expire_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.expire_date));
            RuleFor(x => x.collect_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.collect_date));
            RuleFor(x => x.requested_collect_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.requested_collect_date));
            RuleFor(x => x.status_updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.status_updated_at));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.deleted_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.deleted_at));
            RuleFor(x => x.shipping_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.shipping_amount));
            RuleFor(x => x.package_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.package_amount));
            RuleFor(x => x.is_change_collect_to_post).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_change_collect_to_post));

            RuleFor(x => x.reverse)
                .SetValidator(new AfterSaleReverseValidator());
        }
    }
}
