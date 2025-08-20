using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleTrackingHistoryValidator : AbstractValidator<TrackingHistory>
    {
        public AfterSaleTrackingHistoryValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.tracking_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.tracking_id));
            RuleFor(x => x.status).MaximumLength(60).WithMessage("O campo 'status' deve ter no máximo 60 caracteres.").When(x => !string.IsNullOrEmpty(x.status));
            RuleFor(x => x.message).MaximumLength(3000).WithMessage("O campo 'message' deve ter no máximo 3000 caracteres.").When(x => !string.IsNullOrEmpty(x.message));
            RuleFor(x => x.status_updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.status_updated_at));
            RuleFor(x => x.created_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.created_at));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.deleted_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.deleted_at));
        }
    }
}
