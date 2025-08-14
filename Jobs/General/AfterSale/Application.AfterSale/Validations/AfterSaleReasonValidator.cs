using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleReasonValidator : AbstractValidator<Reason>
    {
        public AfterSaleReasonValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.ecommerce_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_id));
            RuleFor(x => x.description).MaximumLength(60).WithMessage("O campo 'description' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.description));
            RuleFor(x => x.reason_category_id).MaximumLength(60).WithMessage("O campo 'reason_category_id' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.reason_category_id));
            RuleFor(x => x.action).MaximumLength(60).WithMessage("O campo 'action' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.action));
            RuleFor(x => x.upload_image).MaximumLength(60).WithMessage("O campo 'upload_image' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.upload_image));
            RuleFor(x => x.ord).MaximumLength(60).WithMessage("O campo 'ord' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.ord));
            RuleFor(x => x.created_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.created_at));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.deleted_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.deleted_at));
            RuleFor(x => x.should_approve).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.should_approve));
            RuleFor(x => x.show_product_grid).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.show_product_grid));

        }
    }
}
