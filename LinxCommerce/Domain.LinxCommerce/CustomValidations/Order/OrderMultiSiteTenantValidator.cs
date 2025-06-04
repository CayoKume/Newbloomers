using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderMultiSiteTenantValidator : AbstractValidator<OrderMultiSiteTenant>
    {
        public OrderMultiSiteTenantValidator()
        {
            RuleFor(x => x.BrandId)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BrandId | Value: {x.BrandId}, Tamanho do texto: {x.BrandId.Length} excede ao permitido: 50")
                .Must((x, brandId) =>
                {
                    if (brandId != null && brandId.Length > 50)
                        x.BrandId = x.BrandId.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.BrandType)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BrandType | Value: {x.BrandType}, Tamanho do texto: {x.BrandType.Length} excede ao permitido: 50")
                .Must((x, brandType) =>
                {
                    if (brandType != null && brandType.Length > 50)
                        x.BrandType = x.BrandType.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.CompanyId)
                .MaximumLength(50)
                .WithMessage(x => $"Property: CompanyId | Value: {x.CompanyId}, Tamanho do texto: {x.CompanyId.Length} excede ao permitido: 50")
                .Must((x, companyId) =>
                {
                    if (companyId != null && companyId.Length > 50)
                        x.CompanyId = x.CompanyId.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.DeviceType)
                .MaximumLength(50)
                .WithMessage(x => $"Property: DeviceType | Value: {x.DeviceType}, Tamanho do texto: {x.DeviceType.Length} excede ao permitido: 50")
                .Must((x, deviceType) =>
                {
                    if (deviceType != null && deviceType.Length > 50)
                        x.DeviceType = x.DeviceType.Substring(0, 50);
                    return true;
                });
        }
    }
}
