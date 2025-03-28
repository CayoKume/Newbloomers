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
                .WithMessage(x => $"Property: SKU | Value: {x.SKU}, Tamanho do texto: {x.SKU.Length} excede ao permitido: 20")
                .Must((x, sku) =>
                {
                    if (sku != null && sku.Length > 20)
                        x.SKU = x.SKU.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.SellerSKU)
                .MaximumLength(50)
                .WithMessage(x => $"Property: SellerSKU | Value: {x.SellerSKU}, Tamanho do texto: {x.SellerSKU.Length} excede ao permitido: 50")
                .Must((x, sellerSKU) =>
                {
                    if (sellerSKU != null && sellerSKU.Length > 50)
                        x.SellerSKU = x.SellerSKU.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.WarehouseIntegrationID)
                .MaximumLength(30)
                .WithMessage(x => $"Property: WarehouseIntegrationID | Value: {x.WarehouseIntegrationID}, Tamanho do texto: {x.WarehouseIntegrationID.Length} excede ao permitido: 30")
                .Must((x, warehouseIntegrationID) =>
                {
                    if (warehouseIntegrationID != null && warehouseIntegrationID.Length > 30)
                        x.WarehouseIntegrationID = x.WarehouseIntegrationID.Substring(0, 30);
                    return true;
                });

            RuleFor(x => x.ProductIntegrationID)
                .MaximumLength(30)
                .WithMessage(x => $"Property: ProductIntegrationID | Value: {x.ProductIntegrationID}, Tamanho do texto: {x.ProductIntegrationID.Length} excede ao permitido: 30")
                .Must((x, productIntegrationID) =>
                {
                    if (productIntegrationID != null && productIntegrationID.Length > 30)
                        x.ProductIntegrationID = x.ProductIntegrationID.Substring(0, 30);
                    return true;
                });

            RuleFor(x => x.SKUIntegrationID)
                .MaximumLength(20)
                .WithMessage(x => $"Property: SKUIntegrationID | Value: {x.SKUIntegrationID}, Tamanho do texto: {x.SKUIntegrationID.Length} excede ao permitido: 20")
                .Must((x, skuIntegrationID) =>
                {
                    if (skuIntegrationID != null && skuIntegrationID.Length > 20)
                        x.SKUIntegrationID = x.SKUIntegrationID.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.BundlePriceType)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BundlePriceType | Value: {x.BundlePriceType}, Tamanho do texto: {x.BundlePriceType.Length} excede ao permitido: 50")
                .Must((x, bundlePriceType) =>
                {
                    if (bundlePriceType != null && bundlePriceType.Length > 50)
                        x.BundlePriceType = x.BundlePriceType.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.BundleKitDiscount)
                .MaximumLength(50)
                .WithMessage(x => $"Property: BundleKitDiscount | Value: {x.BundleKitDiscount}, Tamanho do texto: {x.BundleKitDiscount.Length} excede ao permitido: 50")
                .Must((x, bundleKitDiscount) =>
                {
                    if (bundleKitDiscount != null && bundleKitDiscount.Length > 50)
                        x.BundleKitDiscount = x.BundleKitDiscount.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.ProductName)
                .MaximumLength(250)
                .WithMessage(x => $"Property: ProductName | Value: {x.ProductName}, Tamanho do texto: {x.ProductName.Length} excede ao permitido: 250")
                .Must((x, productName) =>
                {
                    if (productName != null && productName.Length > 250)
                        x.ProductName = x.ProductName.Substring(0, 250);
                    return true;
                });

            RuleFor(x => x.SkuName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: SkuName | Value: {x.SkuName}, Tamanho do texto: {x.SkuName.Length} excede ao permitido: 60")
                .Must((x, skuName) =>
                {
                    if (skuName != null && skuName.Length > 60)
                        x.SkuName = x.SkuName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.UPC)
                .MaximumLength(50)
                .WithMessage(x => $"Property: UPC | Value: {x.UPC}, Tamanho do texto: {x.UPC.Length} excede ao permitido: 50")
                .Must((x, upc) =>
                {
                    if (upc != null && upc.Length > 50)
                        x.UPC = x.UPC.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.Status)
                .MaximumLength(50)
                .WithMessage(x => $"Property: Status | Value: {x.Status}, Tamanho do texto: {x.Status.Length} excede ao permitido: 50")
                .Must((x, status) =>
                {
                    if (status != null && status.Length > 50)
                        x.Status = x.Status.Substring(0, 50);
                    return true;
                });
        }
    }
}
