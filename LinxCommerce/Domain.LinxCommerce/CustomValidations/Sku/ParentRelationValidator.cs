using Domain.LinxCommerce.Entities.Sku;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Sku
{
    public class ParentRelationValidator : AbstractValidator<ParentRelation>
    {
        public ParentRelationValidator()
        {
            RuleFor(x => x.ParentSKU)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ParentSKU | Value: {x.ParentSKU}, Tamanho do texto: {x.ParentSKU.Length} excede ao permitido: 50")
                .Must((x, ParentSKU) =>
                {
                    if (ParentSKU != null && ParentSKU.Length > 50)
                        x.ParentSKU = x.ParentSKU.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.ParentIntegrationID)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ParentIntegrationID | Value: {x.ParentIntegrationID}, Tamanho do texto: {x.ParentIntegrationID.Length} excede ao permitido: 50")
                .Must((x, ParentIntegrationID) =>
                {
                    if (ParentIntegrationID != null && ParentIntegrationID.Length > 50)
                        x.ParentIntegrationID = x.ParentIntegrationID.Substring(0, 50);
                    return true;
                });
        }
    }
}
