using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderValidator : AbstractValidator<Domain.LinxCommerce.Entities.Order.Order.Root>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderNumber)
                .MaximumLength(12)
                .WithMessage(x => $"Property: OrderNumber | Value: {x.OrderNumber}, Tamanho do texto: {x.OrderNumber.Length} excede ao permitido: 12");

            RuleFor(x => x.MarketPlaceBrand)
                .MaximumLength(50)
                .WithMessage(x => $"Property: MarketPlaceBrand | Value: {x.MarketPlaceBrand}, Tamanho do texto: {x.MarketPlaceBrand.Length} excede ao permitido: 50");

            RuleFor(x => x.WebSiteIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WebSiteIntegrationID | Value: {x.WebSiteIntegrationID}, Tamanho do texto: {x.WebSiteIntegrationID.Length} excede ao permitido: 60");

            RuleFor(x => x.DeliveryPostalCode)
                .MaximumLength(9)
                .WithMessage(x => $"Property: DeliveryPostalCode | Value: {x.DeliveryPostalCode}, Tamanho do texto: {x.DeliveryPostalCode.Length} excede ao permitido: 9");

            RuleFor(x => x.CreatedChannel)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CreatedChannel | Value: {x.CreatedChannel}, Tamanho do texto: {x.CreatedChannel.Length} excede ao permitido: 60");

            RuleFor(x => x.CreatedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CreatedBy | Value: {x.CreatedBy}, Tamanho do texto: {x.CreatedBy.Length} excede ao permitido: 60");

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: ModifiedBy | Value: {x.ModifiedBy}, Tamanho do texto: {x.ModifiedBy.Length} excede ao permitido: 60");

            RuleFor(x => x.OrderGroupNumber)
                .MaximumLength(12)
                .WithMessage(x => $"Property: OrderGroupNumber | Value: {x.OrderGroupNumber}, Tamanho do texto: {x.OrderGroupNumber.Length} excede ao permitido: 12");

            RuleFor(x => x.CustomerType)
                .MaximumLength(1)
                .WithMessage(x => $"Property: CustomerType | Value: {x.CustomerType}, Tamanho do texto: {x.CustomerType.Length} excede ao permitido: 1");

            RuleFor(x => x.WebSiteName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WebSiteName | Value: {x.WebSiteName}, Tamanho do texto: {x.WebSiteName.Length} excede ao permitido: 60");

            RuleFor(x => x.CustomerName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerName | Value: {x.CustomerName}, Tamanho do texto: {x.CustomerName.Length} excede ao permitido: 60");

            RuleFor(x => x.CustomerEmail)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerEmail | Value: {x.CustomerEmail}, Tamanho do texto: {x.CustomerEmail.Length} excede ao permitido: 60");

            RuleFor(x => x.CustomerGender)
                .MaximumLength(1)
                .WithMessage(x => $"Property: CustomerGender | Value: {x.CustomerGender}, Tamanho do texto: {x.CustomerGender.Length} excede ao permitido: 1");

            RuleFor(x => x.CustomerPhone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: CustomerPhone | Value: {x.CustomerPhone}, Tamanho do texto: {x.CustomerPhone.Length} excede ao permitido: 20");

            RuleFor(x => x.CustomerCPF)
                .MaximumLength(11)
                .WithMessage(x => $"Property: CustomerCPF | Value: {x.CustomerCPF}, Tamanho do texto: {x.CustomerCPF.Length} excede ao permitido: 11");

            RuleFor(x => x.CustomerCNPJ)
                .MaximumLength(14)
                .WithMessage(x => $"Property: CustomerCNPJ | Value: {x.CustomerCNPJ}, Tamanho do texto: {x.CustomerCNPJ.Length} excede ao permitido: 14");

            RuleFor(x => x.CustomerTradingName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerTradingName | Value: {x.CustomerTradingName}, Tamanho do texto: {x.CustomerTradingName.Length} excede ao permitido: 60");

            RuleFor(x => x.CustomerSiteTaxPayer)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerSiteTaxPayer | Value: {x.CustomerSiteTaxPayer}, Tamanho do texto: {x.CustomerSiteTaxPayer.Length} excede ao permitido: 60");

            RuleForEach(x => x.Items)
                .SetValidator(new OrderItemValidator());

            RuleForEach(x => x.Tags)
                .SetValidator(new OrderTagValidator());

            RuleForEach(x => x.Addresses)
                .SetValidator(new OrderAddressValidator());

            RuleForEach(x => x.PaymentMethods)
                .SetValidator(new OrderPaymentMethodValidator());

            RuleForEach(x => x.DeliveryMethods)
                .SetValidator(new OrderDeliveryMethodValidator());

            RuleForEach(x => x.Discounts)
                .SetValidator(new OrderDiscountValidator());

            RuleForEach(x => x.Shipments)
                .SetValidator(new OrderShipmentValidator());

            RuleFor(x => x.OrderInvoice)
                .SetValidator(new OrderInvoiceValidator());
        }
    }
}
