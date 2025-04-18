using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Sku;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Sku
{
    public class SkuValidator : AbstractValidator<Domain.LinxCommerce.Entities.Sku.Sku>
    {
        public SkuValidator()
        {
            RuleFor(x => x.UPC)
                .MaximumLength(20)
                .WithMessage(x => $"Property: UPC | Value: {x.UPC}, Tamanho do texto: {x.UPC.Length} excede ao permitido: 20")
                .Must((x, UPC) =>
                {
                    if (UPC != null && UPC.Length > 20)
                        x.UPC = x.UPC.Substring(0, 20);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.SuppliersID))
                .MaximumLength(50)
                .WithMessage(x => $"Property: SuppliersIDs | Value: {string.Join(", ", x.SuppliersID)}, Tamanho do texto: {string.Join(", ", x.SuppliersID).Length} excede ao permitido: 50")
                .Must((x, SuppliersID) =>
                {
                    if (SuppliersID != null && string.Join(", ", SuppliersID).Length > 50)
                        x.SuppliersIDs = string.Join(", ", SuppliersID).Substring(0, 50);
                    else
                        x.SuppliersIDs = string.Join(", ", SuppliersID);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.ParentsID))
                .MaximumLength(50)
                .WithMessage(x => $"Property: ParentsIDs | Value: {string.Join(", ", x.ParentsID)}, Tamanho do texto: {string.Join(", ", x.ParentsID).Length} excede ao permitido: 50")
                .Must((x, ParentsID) =>
                {
                    if (ParentsID != null && string.Join(", ", ParentsID).Length > 50)
                        x.ParentsIDs = string.Join(", ", ParentsID).Substring(0, 50);
                    else
                        x.ParentsIDs = string.Join(", ", ParentsID);
                    return true;
                });

            RuleFor(x => x.Name)
                .MaximumLength(160)
                .WithMessage(x => $"Property: Name | Value: {x.Name}, Tamanho do texto: {x.Name.Length} excede ao permitido: 160")
                .Must((x, Name) =>
                {
                    if (Name != null && Name.Length > 160)
                        x.Name = x.Name.Substring(0, 160);
                    return true;
                });

            RuleFor(x => x.SKU)
                .MaximumLength(20)
                .WithMessage(x => $"Property: SKU | Value: {x.SKU}, Tamanho do texto: {x.SKU.Length} excede ao permitido: 20")
                .Must((x, SKU) =>
                {
                    if (SKU != null && SKU.Length > 20)
                        x.SKU = x.SKU.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.CreatedBy)
                .MaximumLength(50)
                .WithMessage(x => $"Property: CreatedBy | Value: {x.CreatedBy}, Tamanho do texto: {x.CreatedBy.Length} excede ao permitido: 50")
                .Must((x, CreatedBy) =>
                {
                    if (CreatedBy != null && CreatedBy.Length > 50)
                        x.CreatedBy = x.CreatedBy.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ModifiedBy | Value: {x.ModifiedBy}, Tamanho do texto: {x.ModifiedBy.Length} excede ao permitido: 50")
                .Must((x, ModifiedBy) =>
                {
                    if (ModifiedBy != null && ModifiedBy.Length > 50)
                        x.ModifiedBy = x.ModifiedBy.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.IntegrationID)
                .MaximumLength(20)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 20")
                .Must((x, IntegrationID) =>
                {
                    if (IntegrationID != null && IntegrationID.Length > 20)
                        x.IntegrationID = x.IntegrationID.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.PreorderDate)
               .Must((x, PreorderDate) =>
               {
                   if (PreorderDate == null || PreorderDate.Value < new DateTime(1753, 1, 1))
                       x.PreorderDate = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.PreorderDate} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: PreorderDate | Value: {x.PreorderDate}, Error when trying to convert value: {x.PreorderDate.ToString()} to DateTime");

            RuleFor(x => x.VisibleFrom)
               .Must((x, VisibleFrom) =>
               {
                   if (VisibleFrom == null || VisibleFrom.Value < new DateTime(1753, 1, 1))
                       x.VisibleFrom = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.VisibleFrom} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: VisibleFrom | Value: {x.VisibleFrom}, Error when trying to convert value: {x.VisibleFrom.ToString()} to DateTime");

            RuleFor(x => x.VisibleTo)
               .Must((x, VisibleTo) =>
               {
                   if (VisibleTo == null || VisibleTo.Value < new DateTime(1753, 1, 1))
                       x.VisibleTo = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.VisibleTo} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: VisibleTo | Value: {x.VisibleTo}, Error when trying to convert value: {x.VisibleTo.ToString()} to DateTime");

            RuleFor(x => x.CreatedDate)
               .Must((x, CreatedDate) =>
               {
                   if (CreatedDate == null || CreatedDate.Value < new DateTime(1753, 1, 1))
                       x.CreatedDate = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.CreatedDate} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: CreatedDate | Value: {x.CreatedDate}, Error when trying to convert value: {x.CreatedDate.ToString()} to DateTime");

            RuleFor(x => x.ModifiedDate)
               .Must((x, ModifiedDate) =>
               {
                   if (ModifiedDate == null || ModifiedDate.Value < new DateTime(1753, 1, 1))
                       x.ModifiedDate = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.ModifiedDate} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: ModifiedDate | Value: {x.ModifiedDate}, Error when trying to convert value: {x.ModifiedDate.ToString()} to DateTime");

            RuleForEach(x => x.MetadataValues)
                .SetValidator(new MetadataValueValidator());

            RuleForEach(x => x.ParentRelations)
                .SetValidator(new ParentRelationValidator());
        }
    }
}
