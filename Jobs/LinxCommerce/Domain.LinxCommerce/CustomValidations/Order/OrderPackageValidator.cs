using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderPackageValidator : AbstractValidator<OrderPackage>
    {
        public OrderPackageValidator()
        {
            RuleFor(x => x.PackageNumber)
                .MaximumLength(10)
                .WithMessage(x => $"Property: PackageNumber | Value: {x.PackageNumber}, Tamanho do texto: {x.PackageNumber.Length} excede ao permitido: 10")
                .Must((x, packageNumber) =>
                {
                    if (packageNumber != null && packageNumber.Length > 50)
                        x.PackageNumber = x.PackageNumber.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.TrackingNumber)
                .MaximumLength(50)
                .WithMessage(x => $"Property: TrackingNumber | Value: {x.TrackingNumber}, Tamanho do texto: {x.TrackingNumber.Length} excede ao permitido: 50")
                .Must((x, trackingNumber) =>
                {
                    if (trackingNumber != null && trackingNumber.Length > 50)
                        x.TrackingNumber = x.TrackingNumber.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.TrackingNumberUrl)
                .MaximumLength(800)
                .WithMessage(x => $"Property: TrackingNumberUrl | Value: {x.TrackingNumberUrl}, Tamanho do texto: {x.TrackingNumberUrl.Length} excede ao permitido: 800")
                .Must((x, trackingNumberUrl) =>
                {
                    if (trackingNumberUrl != null && trackingNumberUrl.Length > 800)
                        x.TrackingNumberUrl = x.TrackingNumberUrl.Substring(0, 800);
                    return true;
                });

            RuleFor(x => x.ShippedBy)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ShippedBy | Value: {x.ShippedBy}, Tamanho do texto: {x.ShippedBy.Length} excede ao permitido: 50")
                .Must((x, shippedBy) =>
                {
                    if (shippedBy != null && shippedBy.Length > 50)
                        x.ShippedBy = x.ShippedBy.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.PackageType)
                .MaximumLength(50)
                .WithMessage(x => $"Property: PackageType | Value: {x.PackageType}, Tamanho do texto: {x.PackageType.Length} excede ao permitido: 50")
                .Must((x, packageType) =>
                {
                    if (packageType != null && packageType.Length > 50)
                        x.PackageType = x.PackageType.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Source)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Source | Value: {x.Source}, Tamanho do texto: {x.Source.Length} excede ao permitido: 50")
                .Must((x, source) =>
                {
                    if (source != null && source.Length > 50)
                        x.Source = x.Source.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.ShippedDate)
                .Must((x, shippedDate) =>
                {
                    if (shippedDate == null || shippedDate.Value < new DateTime(1753, 1, 1))
                        x.ShippedDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.ShippedDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: ShippedDate | Value: {x.ShippedDate}, Error when trying to convert value: {x.ShippedDate.ToString()} to DateTime");
        }
    }
}
