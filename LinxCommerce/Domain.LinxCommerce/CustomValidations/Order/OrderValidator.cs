using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderValidator : AbstractValidator<Domain.LinxCommerce.Entities.Order.Order.Root>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderNumber)
                .MaximumLength(12)
                .WithMessage(x => $"Property: OrderNumber | Value: {x.OrderNumber}, Tamanho do texto: {x.OrderNumber.Length} excede ao permitido: 12")
                .Must((x, orderNumber) =>
                {
                    if (orderNumber != null && orderNumber.Length > 12)
                        x.OrderNumber = x.OrderNumber.Substring(0, 12);
                    return true;
                });

            RuleFor(x => x.MarketPlaceBrand)
                .MaximumLength(50)
                .WithMessage(x => $"Property: MarketPlaceBrand | Value: {x.MarketPlaceBrand}, Tamanho do texto: {x.MarketPlaceBrand.Length} excede ao permitido: 50")
                .Must((x, marketPlaceBrand) =>
                {
                    if (marketPlaceBrand != null && marketPlaceBrand.Length > 50)
                        x.MarketPlaceBrand = x.MarketPlaceBrand.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.WebSiteIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WebSiteIntegrationID | Value: {x.WebSiteIntegrationID}, Tamanho do texto: {x.WebSiteIntegrationID.Length} excede ao permitido: 60")
                .Must((x, webSiteIntegrationID) =>
                {
                    if (webSiteIntegrationID != null && webSiteIntegrationID.Length > 60)
                        x.WebSiteIntegrationID = x.WebSiteIntegrationID.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.DeliveryPostalCode)
                .MaximumLength(9)
                .WithMessage(x => $"Property: DeliveryPostalCode | Value: {x.DeliveryPostalCode}, Tamanho do texto: {x.DeliveryPostalCode.Length} excede ao permitido: 9")
                .Must((x, deliveryPostalCode) =>
                {
                    if (deliveryPostalCode != null && deliveryPostalCode.Length > 9)
                        x.DeliveryPostalCode = x.DeliveryPostalCode.Substring(0, 9);
                    return true;
                });

            RuleFor(x => x.CreatedChannel)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CreatedChannel | Value: {x.CreatedChannel}, Tamanho do texto: {x.CreatedChannel.Length} excede ao permitido: 60")
                .Must((x, createdChannel) =>
                {
                    if (createdChannel != null && createdChannel.Length > 60)
                        x.CreatedChannel = x.CreatedChannel.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CreatedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CreatedBy | Value: {x.CreatedBy}, Tamanho do texto: {x.CreatedBy.Length} excede ao permitido: 60")
                .Must((x, createdBy) =>
                {
                    if (createdBy != null && createdBy.Length > 60)
                        x.CreatedBy = x.CreatedBy.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(60)
                .WithMessage(x => $"Property: ModifiedBy | Value: {x.ModifiedBy}, Tamanho do texto: {x.ModifiedBy.Length} excede ao permitido: 60")
                .Must((x, modifiedBy) =>
                {
                    if (modifiedBy != null && modifiedBy.Length > 60)
                        x.ModifiedBy = x.ModifiedBy.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.OrderGroupNumber)
                .MaximumLength(12)
                .WithMessage(x => $"Property: OrderGroupNumber | Value: {x.OrderGroupNumber}, Tamanho do texto: {x.OrderGroupNumber.Length} excede ao permitido: 12")
                .Must((x, orderGroupNumber) =>
                {
                    if (orderGroupNumber != null && orderGroupNumber.Length > 12)
                        x.OrderGroupNumber = x.OrderGroupNumber.Substring(0, 12);
                    return true;
                });

            RuleFor(x => x.CustomerType)
                .MaximumLength(1)
                .WithMessage(x => $"Property: CustomerType | Value: {x.CustomerType}, Tamanho do texto: {x.CustomerType.Length} excede ao permitido: 1")
                .Must((x, customerType) =>
                {
                    if (customerType != null && customerType.Length > 1)
                        x.CustomerType = x.CustomerType.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.WebSiteName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WebSiteName | Value: {x.WebSiteName}, Tamanho do texto: {x.WebSiteName.Length} excede ao permitido: 60")
                .Must((x, webSiteName) =>
                {
                    if (webSiteName != null && webSiteName.Length > 60)
                        x.WebSiteName = x.WebSiteName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CustomerName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerName | Value: {x.CustomerName}, Tamanho do texto: {x.CustomerName.Length} excede ao permitido: 60")
                .Must((x, customerName) =>
                {
                    if (customerName != null && customerName.Length > 60)
                        x.CustomerName = x.CustomerName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CustomerEmail)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerEmail | Value: {x.CustomerEmail}, Tamanho do texto: {x.CustomerEmail.Length} excede ao permitido: 60")
                .Must((x, customerEmail) =>
                {
                    if (customerEmail != null && customerEmail.Length > 60)
                        x.CustomerEmail = x.CustomerEmail.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CustomerGender)
                .MaximumLength(1)
                .WithMessage(x => $"Property: CustomerGender | Value: {x.CustomerGender}, Tamanho do texto: {x.CustomerGender.Length} excede ao permitido: 1")
                .Must((x, customerGender) =>
                {
                    if (customerGender != null && customerGender.Length > 1)
                        x.CustomerGender = x.CustomerGender.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.CustomerPhone)
                .MaximumLength(20)
                .WithMessage(x => $"Property: CustomerPhone | Value: {x.CustomerPhone}, Tamanho do texto: {x.CustomerPhone.Length} excede ao permitido: 20")
                .Must((x, customerPhone) =>
                {
                    if (customerPhone != null && customerPhone.Length > 20)
                        x.CustomerPhone = x.CustomerPhone.Substring(0, 20);
                    return true;
                });

            RuleFor(x => x.CustomerCPF)
                .MaximumLength(11)
                .WithMessage(x => $"Property: CustomerCPF | Value: {x.CustomerCPF}, Tamanho do texto: {x.CustomerCPF.Length} excede ao permitido: 11")
                .Must((x, customerCPF) =>
                {
                    if (customerCPF != null && customerCPF.Length > 11)
                        x.CustomerCPF = x.CustomerCPF.Substring(0, 11);
                    return true;
                });

            RuleFor(x => x.CustomerCNPJ)
                .MaximumLength(14)
                .WithMessage(x => $"Property: CustomerCNPJ | Value: {x.CustomerCNPJ}, Tamanho do texto: {x.CustomerCNPJ.Length} excede ao permitido: 14")
                .Must((x, customerCNPJ) =>
                {
                    if (customerCNPJ != null && customerCNPJ.Length > 14)
                        x.CustomerCNPJ = x.CustomerCNPJ.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.CustomerTradingName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerTradingName | Value: {x.CustomerTradingName}, Tamanho do texto: {x.CustomerTradingName.Length} excede ao permitido: 60")
                .Must((x, customerTradingName) =>
                {
                    if (customerTradingName != null && customerTradingName.Length > 60)
                        x.CustomerTradingName = x.CustomerTradingName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CustomerSiteTaxPayer)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CustomerSiteTaxPayer | Value: {x.CustomerSiteTaxPayer}, Tamanho do texto: {x.CustomerSiteTaxPayer.Length} excede ao permitido: 60")
                .Must((x, customerSiteTaxPayer) =>
                {
                    if (customerSiteTaxPayer != null && customerSiteTaxPayer.Length > 60)
                        x.CustomerSiteTaxPayer = x.CustomerSiteTaxPayer.Substring(0, 60);
                    return true;
                });

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
