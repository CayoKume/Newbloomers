using Domain.LinxCommerce.CustomValidations.Validations;
using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderDeliveryMethodValidator : AbstractValidator<OrderDeliveryMethod>
    {
        public OrderDeliveryMethodValidator()
        {
            RuleFor(x => x.LogisticOptionId)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticOptionId | Value: {x.LogisticOptionId}, Tamanho do texto: {x.LogisticOptionId.Length} excede ao permitido: 60")
                .Must((x, logisticOptionId) =>
                {
                    if (logisticOptionId != null && logisticOptionId.Length > 60)
                        x.LogisticOptionId = x.LogisticOptionId.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.LogisticContractName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractName | Value: {x.LogisticContractName}, Tamanho do texto: {x.LogisticContractName.Length} excede ao permitido: 60")
                .Must((x, logisticContractName) =>
                {
                    if (logisticContractName != null && logisticContractName.Length > 60)
                        x.LogisticContractName = x.LogisticContractName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.LogisticContractId)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractId | Value: {x.LogisticContractId}, Tamanho do texto: {x.LogisticContractId.Length} excede ao permitido: 60")
                .Must((x, logisticContractId) =>
                {
                    if (logisticContractId != null && logisticContractId.Length > 60)
                        x.LogisticContractId = x.LogisticContractId.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.LogisticContractName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractName | Value: {x.LogisticContractName}, Tamanho do texto: {x.LogisticContractName.Length} excede ao permitido: 60")
                .Must((x, logisticContractName) =>
                {
                    if (logisticContractName != null && logisticContractName.Length > 60)
                        x.LogisticContractName = x.LogisticContractName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ScheduleDisplayName)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ScheduleDisplayName | Value: {x.ScheduleDisplayName}, Tamanho do texto: {x.ScheduleDisplayName.Length} excede ao permitido: 50")
                .Must((x, scheduleDisplayName) =>
                {
                    if (scheduleDisplayName != null && scheduleDisplayName.Length > 50)
                        x.ScheduleDisplayName = x.ScheduleDisplayName.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.DeliveryMethodAlias)
                .MaximumLength(50)
                .WithMessage(x => $"Property: DeliveryMethodAlias | Value: {x.DeliveryMethodAlias}, Tamanho do texto: {x.DeliveryMethodAlias.Length} excede ao permitido: 50")
                .Must((x, deliveryMethodAlias) =>
                {
                    if (deliveryMethodAlias != null && deliveryMethodAlias.Length > 50)
                        x.DeliveryMethodAlias = x.DeliveryMethodAlias.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.PointOfSaleIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: PointOfSaleIntegrationID | Value: {x.PointOfSaleIntegrationID}, Tamanho do texto: {x.PointOfSaleIntegrationID.Length} excede ao permitido: 60")
                .Must((x, pointOfSaleIntegrationID) =>
                {
                    if (pointOfSaleIntegrationID != null && pointOfSaleIntegrationID.Length > 60)
                        x.PointOfSaleIntegrationID = x.PointOfSaleIntegrationID.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.PointOfSaleName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: PointOfSaleName | Value: {x.PointOfSaleName}, Tamanho do texto: {x.PointOfSaleName.Length} excede ao permitido: 60")
                .Must((x, pointOfSaleName) =>
                {
                    if (pointOfSaleName != null && pointOfSaleName.Length > 60)
                        x.PointOfSaleName = x.PointOfSaleName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.DeliveryMethodType)
                .MaximumLength(1)
                .WithMessage(x => $"Property: DeliveryMethodType | Value: {x.DeliveryMethodType}, Tamanho do texto: {x.DeliveryMethodType.Length} excede ao permitido: 1")
                .Must((x, deliveryMethodType) =>
                {
                    if (deliveryMethodType != null && deliveryMethodType.Length > 1)
                        x.DeliveryMethodType = x.DeliveryMethodType.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.DeliveryLogisticType)
                .MaximumLength(60)
                .WithMessage(x => $"Property: DeliveryLogisticType | Value: {x.DeliveryLogisticType}, Tamanho do texto: {x.DeliveryLogisticType.Length} excede ao permitido: 60")
                .Must((x, deliveryLogisticType) =>
                {
                    if (deliveryLogisticType != null && deliveryLogisticType.Length > 60)
                        x.DeliveryLogisticType = x.DeliveryLogisticType.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ExternalID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: ExternalID | Value: {x.ExternalID}, Tamanho do texto: {x.ExternalID.Length} excede ao permitido: 60")
                .Must((x, externalID) =>
                {
                    if (externalID != null && externalID.Length > 60)
                        x.ExternalID = x.ExternalID.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.WarehouseIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WarehouseIntegrationID | Value: {x.WarehouseIntegrationID}, Tamanho do texto: {x.WarehouseIntegrationID.Length} excede ao permitido: 60")
                .Must((x, warehouseIntegrationID) =>
                {
                    if (warehouseIntegrationID != null && warehouseIntegrationID.Length > 60)
                        x.WarehouseIntegrationID = x.WarehouseIntegrationID.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.CarrierName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CarrierName | Value: {x.CarrierName}, Tamanho do texto: {x.CarrierName.Length} excede ao permitido: 60")
                .Must((x, carrierName) =>
                {
                    if (carrierName != null && carrierName.Length > 60)
                        x.CarrierName = x.CarrierName.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.ScheduleDate)
                .Must((x, scheduleDate) =>
                {
                    if (scheduleDate == null || scheduleDate.Value < new DateTime(1753, 1, 1))
                        x.ScheduleDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.ScheduleDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: ScheduleDate | Value: {x.ScheduleDate}, Error when trying to convert value: {x.ScheduleDate.ToString()} to DateTime");


            RuleFor(x => x.DeliveryEstimatedDate)
                .Must((x, deliveryEstimatedDate) =>
                {
                    if (deliveryEstimatedDate == null || deliveryEstimatedDate.Value < new DateTime(1753, 1, 1))
                        x.DeliveryEstimatedDate = new DateTime(1753, 1, 1);
                    return true;
                })
                .WithMessage(x => $"Date: {x.DeliveryEstimatedDate} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: DeliveryEstimatedDate | Value: {x.DeliveryEstimatedDate}, Error when trying to convert value: {x.DeliveryEstimatedDate.ToString()} to DateTime");
        }
    }
}
