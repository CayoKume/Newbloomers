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
                .WithMessage(x => $"Property: PackageNumber | Value: {x.PackageNumber}, Tamanho do texto: {x.PackageNumber.Length} excede ao permitido: 10");

            RuleFor(x => x.TrackingNumber)
                .MaximumLength(10)
                .WithMessage(x => $"Property: TrackingNumber | Value: {x.TrackingNumber}, Tamanho do texto: {x.TrackingNumber.Length} excede ao permitido: 10");

            RuleFor(x => x.TrackingNumberUrl)
                .MaximumLength(10)
                .WithMessage(x => $"Property: TrackingNumberUrl | Value: {x.TrackingNumberUrl}, Tamanho do texto: {x.TrackingNumberUrl.Length} excede ao permitido: 10");

            RuleFor(x => x.ShippedBy)
                .MaximumLength(10)
                .WithMessage(x => $"Property: ShippedBy | Value: {x.ShippedBy}, Tamanho do texto: {x.ShippedBy.Length} excede ao permitido: 10");

            RuleFor(x => x.PackageType)
                .MaximumLength(10)
                .WithMessage(x => $"Property: PackageType | Value: {x.PackageType}, Tamanho do texto: {x.PackageType.Length} excede ao permitido: 10");

            RuleFor(x => x.Source)
                .MaximumLength(10)
                .WithMessage(x => $"Property: Source | Value: {x.Source}, Tamanho do texto: {x.Source.Length} excede ao permitido: 10");

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
