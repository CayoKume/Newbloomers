using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderItemValidator : AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.SKU)
                .MaximumLength(20)
                .WithMessage(x => $"Property: SKU | Value: {x.SKU}, Tamanho do texto: {x.SKU.Length} excede ao permitido: 20");

            RuleFor(x => x.SellerSKU)
                .MaximumLength(50)
                .WithMessage(x => $"Property: SellerSKU | Value: {x.SellerSKU}, Tamanho do texto: {x.SellerSKU.Length} excede ao permitido: 50");

            RuleFor(x => x.WarehouseIntegrationID)
                .MaximumLength(30)
                .WithMessage(x => $"Property: WarehouseIntegrationID | Value: {x.WarehouseIntegrationID}, Tamanho do texto: {x.WarehouseIntegrationID.Length} excede ao permitido: 30");

            RuleFor(x => x.ProductIntegrationID)
                .MaximumLength(30)
                .WithMessage(x => $"Property: ProductIntegrationID | Value: {x.ProductIntegrationID}, Tamanho do texto: {x.ProductIntegrationID.Length} excede ao permitido: 30");

            RuleFor(x => x.SKUIntegrationID)
                .MaximumLength(20)
                .WithMessage(x => $"Property: SKUIntegrationID | Value: {x.SKUIntegrationID}, Tamanho do texto: {x.SKUIntegrationID.Length} excede ao permitido: 20");

            RuleFor(x => x.BundlePriceType)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BundlePriceType | Value: {x.BundlePriceType}, Tamanho do texto: {x.BundlePriceType.Length} excede ao permitido: 506500");

            RuleFor(x => x.BundleKitDiscount)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BundleKitDiscount | Value: {x.BundleKitDiscount}, Tamanho do texto: {x.BundleKitDiscount.Length} excede ao permitido: 50");

            RuleFor(x => x.ProductName)
                .MaximumLength(250)
                .WithMessage(x => $"Property: ProductName | Value: {x.ProductName}, Tamanho do texto: {x.ProductName.Length} excede ao permitido: 250");

            RuleFor(x => x.SkuName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: SkuName | Value: {x.SkuName}, Tamanho do texto: {x.SkuName.Length} excede ao permitido: 60");

            RuleFor(x => x.UPC)
                .MaximumLength(50)
                .WithMessage(x => $"Property: UPC | Value: {x.UPC}, Tamanho do texto: {x.UPC.Length} excede ao permitido: 50");

            RuleFor(x => x.Status)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Status | Value: {x.Status}, Tamanho do texto: {x.Status.Length} excede ao permitido: 50");
        }
    }
}
