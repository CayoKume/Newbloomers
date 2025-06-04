using Domain.LinxCommerce.CustomValidations.Sku;
using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Product;
using Domain.LinxCommerce.Entities.Sku;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Product
{
    public class ProductValidator : AbstractValidator<Domain.LinxCommerce.Entities.Product.Product>
    {
        public ProductValidator()
        {
            RuleFor(x => string.Join(", ", x.SkusID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: SkusIDs | Value: {string.Join(", ", x.SkusID)}, Tamanho do texto: {string.Join(", ", x.SkusID).Length} excede ao permitido: 3000")
                .Must((x, SkusID) =>
                {
                    if (SkusID != null && string.Join(", ", SkusID).Length > 3000)
                        x.SkusIDs = string.Join(", ", SkusID).Substring(0, 3000);
                    else
                        x.SkusIDs = string.Join(", ", SkusID);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.FlagsID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: FlagsIDs | Value: {string.Join(", ", x.FlagsID)}, Tamanho do texto: {string.Join(", ", x.FlagsID).Length} excede ao permitido: 3000")
                .Must((x, FlagsID) =>
                {
                    if (FlagsID != null && string.Join(", ", FlagsID).Length > 3000)
                        x.FlagsIDs = string.Join(", ", FlagsID).Substring(0, 3000);
                    else
                        x.FlagsIDs = string.Join(", ", FlagsID);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.MediasID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: MediasIDs | Value: {string.Join(", ", x.MediasID)}, Tamanho do texto: {string.Join(", ", x.MediasID).Length} excede ao permitido: 3000")
                .Must((x, MediasID) =>
                {
                    if (MediasID != null && string.Join(", ", MediasID).Length > 3000)
                        x.MediasIDs = string.Join(", ", MediasID).Substring(0, 3000);
                    else
                        x.MediasIDs = string.Join(", ", MediasID);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.CategoriesID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: CategoriesIDs | Value: {string.Join(", ", x.CategoriesID)}, Tamanho do texto: {string.Join(", ", x.CategoriesID).Length} excede ao permitido: 3000")
                .Must((x, CategoriesID) =>
                {
                    if (CategoriesID != null && string.Join(", ", CategoriesID).Length > 3000)
                        x.CategoriesIDs = string.Join(", ", CategoriesID).Substring(0, 3000);
                    else
                        x.CategoriesIDs = string.Join(", ", CategoriesID);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.ShippingRegionsID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: ShippingRegionsIDs | Value: {string.Join(", ", x.ShippingRegionsID)}, Tamanho do texto: {string.Join(", ", x.ShippingRegionsID).Length} excede ao permitido: 3000")
                .Must((x, ShippingRegionsID) =>
                {
                    if (ShippingRegionsID != null && string.Join(", ", ShippingRegionsID).Length > 3000)
                        x.ShippingRegionsIDs = string.Join(", ", ShippingRegionsID).Substring(0, 3000);
                    else
                        x.ShippingRegionsIDs = string.Join(", ", ShippingRegionsID);
                    return true;
                });

            RuleFor(x => x.SearchKeywords)
                .MaximumLength(300)
                .WithMessage(x => $"Property: SearchKeywords | Value: {x.SearchKeywords}, Tamanho do texto: {x.SearchKeywords.Length} excede ao permitido: 300")
                .Must((x, SearchKeywords) =>
                {
                    if (SearchKeywords != null && SearchKeywords.Length > 300)
                        x.SearchKeywords = x.SearchKeywords.Substring(0, 300);
                    return true;
                });

            RuleFor(x => x.PageTitle)
                .MaximumLength(60)
                .WithMessage(x => $"Property: PageTitle | Value: {x.PageTitle}, Tamanho do texto: {x.PageTitle.Length} excede ao permitido: 60")
                .Must((x, PageTitle) =>
                {
                    if (PageTitle != null && PageTitle.Length > 60)
                        x.PageTitle = x.PageTitle.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.UrlFriendly)
                .MaximumLength(160)
                .WithMessage(x => $"Property: UrlFriendly | Value: {x.UrlFriendly}, Tamanho do texto: {x.UrlFriendly.Length} excede ao permitido: 160")
                .Must((x, UrlFriendly) =>
                {
                    if (UrlFriendly != null && UrlFriendly.Length > 160)
                        x.UrlFriendly = x.UrlFriendly.Substring(0, 160);
                    return true;
                });

            RuleFor(x => x.MetaDescription)
                .MaximumLength(160)
                .WithMessage(x => $"Property: MetaDescription | Value: {x.MetaDescription}, Tamanho do texto: {x.MetaDescription.Length} excede ao permitido: 160")
                .Must((x, MetaDescription) =>
                {
                    if (MetaDescription != null && MetaDescription.Length > 160)
                        x.MetaDescription = x.MetaDescription.Substring(0, 160);
                    return true;
                });

            RuleFor(x => x.MetaKeywords)
                .MaximumLength(300)
                .WithMessage(x => $"Property: MetaKeywords | Value: {x.MetaKeywords}, Tamanho do texto: {x.MetaKeywords.Length} excede ao permitido: 300")
                .Must((x, MetaKeywords) =>
                {
                    if (MetaKeywords != null && MetaKeywords.Length > 300)
                        x.MetaKeywords = x.MetaKeywords.Substring(0, 300);
                    return true;
                });

            RuleFor(x => x.ShortDescription)
                .MaximumLength(160)
                .WithMessage(x => $"Property: ShortDescription | Value: {x.ShortDescription}, Tamanho do texto: {x.ShortDescription.Length} excede ao permitido: 160")
                .Must((x, ShortDescription) =>
                {
                    if (ShortDescription != null && ShortDescription.Length > 160)
                        x.ShortDescription = x.ShortDescription.Substring(0, 160);
                    return true;
                });

            RuleFor(x => x.WarrantyDescription)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WarrantyDescription | Value: {x.WarrantyDescription}, Tamanho do texto: {x.WarrantyDescription.Length} excede ao permitido: 60")
                .Must((x, WarrantyDescription) =>
                {
                    if (WarrantyDescription != null && WarrantyDescription.Length > 60)
                        x.WarrantyDescription = x.WarrantyDescription.Substring(0, 60);
                    return true;
                });

            RuleFor(x => string.Join(", ", x.TagsID))
                .MaximumLength(3000)
                .WithMessage(x => $"Property: TagsIDs | Value: {string.Join(", ", x.TagsID)}, Tamanho do texto: {string.Join(", ", x.TagsID).Length} excede ao permitido: 3000")
                .Must((x, TagsID) =>
                {
                    if (TagsID != null && string.Join(", ", TagsID).Length > 3000)
                        x.TagsIDs = string.Join(", ", TagsID).Substring(0, 3000);
                    else
                        x.TagsIDs = string.Join(", ", TagsID);
                    return true;
                });

            RuleFor(x => x.DisplayAvailability)
                .MaximumLength(1)
                .WithMessage(x => $"Property: DisplayAvailability | Value: {x.DisplayAvailability}, Tamanho do texto: {x.DisplayAvailability.Length} excede ao permitido: 1")
                .Must((x, DisplayAvailability) =>
                {
                    if (DisplayAvailability != null && DisplayAvailability.Length > 1)
                        x.DisplayAvailability = x.DisplayAvailability.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.DisplayPrice)
                .MaximumLength(1)
                .WithMessage(x => $"Property: DisplayPrice | Value: {x.DisplayPrice}, Tamanho do texto: {x.DisplayPrice.Length} excede ao permitido: 1")
                .Must((x, DisplayPrice) =>
                {
                    if (DisplayPrice != null && DisplayPrice.Length > 1)
                        x.DisplayPrice = x.DisplayPrice.Substring(0, 1);
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
                .MaximumLength(60)
                .WithMessage(x => $"Property: SKU | Value: {x.SKU}, Tamanho do texto: {x.SKU.Length} excede ao permitido: 60")
                .Must((x, SKU) =>
                {
                    if (SKU != null && SKU.Length > 60)
                        x.SKU = x.SKU.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CreatedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CreatedBy | Value: {x.CreatedBy}, Tamanho do texto: {x.CreatedBy.Length} excede ao permitido: 60")
                .Must((x, CreatedBy) =>
                {
                    if (CreatedBy != null && CreatedBy.Length > 60)
                        x.CreatedBy = x.CreatedBy.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: ModifiedBy | Value: {x.ModifiedBy}, Tamanho do texto: {x.ModifiedBy.Length} excede ao permitido: 60")
                .Must((x, ModifiedBy) =>
                {
                    if (ModifiedBy != null && ModifiedBy.Length > 60)
                        x.ModifiedBy = x.ModifiedBy.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.IntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 60")
                .Must((x, IntegrationID) =>
                {
                    if (IntegrationID != null && IntegrationID.Length > 60)
                        x.IntegrationID = x.IntegrationID.Substring(0, 60);
                    return true;
                });

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


            RuleFor(x => x.NewFrom)
               .Must((x, NewFrom) =>
               {
                   if (NewFrom == null || NewFrom.Value < new DateTime(1753, 1, 1))
                       x.NewFrom = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.NewFrom} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: NewFrom | Value: {x.NewFrom}, Error when trying to convert value: {x.NewFrom.ToString()} to DateTime");

            RuleFor(x => x.NewTo)
               .Must((x, NewTo) =>
               {
                   if (NewTo == null || NewTo.Value < new DateTime(1753, 1, 1))
                       x.NewTo = new DateTime(1753, 1, 1);
                   return true;
               })
               .WithMessage(x => $"Date: {x.NewTo} must be between 01/01/1753 and 31/12/9999.")
               .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
               .WithMessage(x => $"Property: NewTo | Value: {x.NewTo}, Error when trying to convert value: {x.NewTo.ToString()} to DateTime");

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

            RuleForEach(x => x.Medias)
                .SetValidator(new MidiaValidator());

            RuleForEach(x => x.MetadataValues)
                .SetValidator(new MetadataValueValidator());
        }
    }
}
