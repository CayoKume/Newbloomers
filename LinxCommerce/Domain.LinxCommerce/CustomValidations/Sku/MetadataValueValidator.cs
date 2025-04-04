using Domain.LinxCommerce.Entities.Sku;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Sku
{
    public class MetadataValueValidator : AbstractValidator<MetadataValue>
    {
        public MetadataValueValidator()
        {
            RuleFor(x => x.PropertyName)
                .MaximumLength(160)
                .WithMessage(x => $"Property: PropertyName | Value: {x.PropertyName}, Tamanho do texto: {x.PropertyName.Length} excede ao permitido: 160")
                .Must((x, PropertyName) =>
                {
                    if (PropertyName != null && PropertyName.Length > 160)
                        x.PropertyName = x.PropertyName.Substring(0, 160);
                    return true;
                });

            RuleFor(x => x.PropertyGroup)
                .MaximumLength(50)
                .WithMessage(x => $"Property: PropertyGroup | Value: {x.PropertyGroup}, Tamanho do texto: {x.PropertyGroup.Length} excede ao permitido: 50")
                .Must((x, PropertyGroup) =>
                {
                    if (PropertyGroup != null && PropertyGroup.Length > 50)
                        x.PropertyGroup = x.PropertyGroup.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Value)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Value | Value: {x.Value}, Tamanho do texto: {x.Value.Length} excede ao permitido: 50")
                .Must((x, Value) =>
                {
                    if (Value != null && Value.Length > 50)
                        x.Value = x.Value.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.SerializedValue)
                .MaximumLength(50)
                .WithMessage(x => $"Property: SerializedValue | Value: {x.SerializedValue}, Tamanho do texto: {x.SerializedValue.Length} excede ao permitido: 50")
                .Must((x, SerializedValue) =>
                {
                    if (SerializedValue != null && SerializedValue.Length > 50)
                        x.SerializedValue = x.SerializedValue.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.SerializedBlobValue)
                .MaximumLength(60)
                .WithMessage(x => $"Property: SerializedBlobValue | Value: {x.SerializedBlobValue}, Tamanho do texto: {x.SerializedBlobValue.Length} excede ao permitido: 60")
                .Must((x, SerializedBlobValue) =>
                {
                    if (SerializedBlobValue != null && SerializedBlobValue.Length > 60)
                        x.SerializedBlobValue = x.SerializedBlobValue.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.IntegrationID)
                .MaximumLength(50)
                .WithMessage(x => $"Property: IntegrationID | Value: {x.IntegrationID}, Tamanho do texto: {x.IntegrationID.Length} excede ao permitido: 50")
                .Must((x, IntegrationID) =>
                {
                    if (IntegrationID != null && IntegrationID.Length > 50)
                        x.IntegrationID = x.IntegrationID.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.FormattedValue)
                .MaximumLength(50)
                .WithMessage(x => $"Property: FormattedValue | Value: {x.FormattedValue}, Tamanho do texto: {x.FormattedValue.Length} excede ao permitido: 50")
                .Must((x, FormattedValue) =>
                {
                    if (FormattedValue != null && FormattedValue.Length > 50)
                        x.FormattedValue = x.FormattedValue.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.DisplayName)
                .MaximumLength(160)
                .WithMessage(x => $"Property: DisplayName | Value: {x.DisplayName}, Tamanho do texto: {x.DisplayName.Length} excede ao permitido: 160")
                .Must((x, DisplayName) =>
                {
                    if (DisplayName != null && DisplayName.Length > 160)
                        x.DisplayName = x.DisplayName.Substring(0, 160);
                    return true;
                });
        }
    }
}
