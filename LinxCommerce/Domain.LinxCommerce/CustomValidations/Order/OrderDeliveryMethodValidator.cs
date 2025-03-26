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
                .WithMessage(x => $"Property: LogisticOptionId | Value: {x.LogisticOptionId}, Tamanho do texto: {x.LogisticOptionId.Length} excede ao permitido: 60");

            RuleFor(x => x.LogisticContractName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractName | Value: {x.LogisticContractName}, Tamanho do texto: {x.LogisticContractName.Length} excede ao permitido: 60");

            RuleFor(x => x.LogisticContractId)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractId | Value: {x.LogisticContractId}, Tamanho do texto: {x.LogisticContractId.Length} excede ao permitido: 60");

            RuleFor(x => x.LogisticContractName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: LogisticContractName | Value: {x.LogisticContractName}, Tamanho do texto: {x.LogisticContractName.Length} excede ao permitido: 60");

            RuleFor(x => x.ScheduleDisplayName)
                .MaximumLength(50)
                .WithMessage(x => $"Property: ScheduleDisplayName | Value: {x.ScheduleDisplayName}, Tamanho do texto: {x.ScheduleDisplayName.Length} excede ao permitido: 50");

            RuleFor(x => x.DeliveryMethodAlias)
                .MaximumLength(50)
                .WithMessage(x => $"Property: DeliveryMethodAlias | Value: {x.DeliveryMethodAlias}, Tamanho do texto: {x.DeliveryMethodAlias.Length} excede ao permitido: 50");

            RuleFor(x => x.PointOfSaleIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: PointOfSaleIntegrationID | Value: {x.PointOfSaleIntegrationID}, Tamanho do texto: {x.PointOfSaleIntegrationID.Length} excede ao permitido: 60");

            RuleFor(x => x.PointOfSaleName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: PointOfSaleName | Value: {x.PointOfSaleName}, Tamanho do texto: {x.PointOfSaleName.Length} excede ao permitido: 60");

            RuleFor(x => x.DeliveryMethodType)
                .MaximumLength(1)
                .WithMessage(x => $"Property: DeliveryMethodType | Value: {x.DeliveryMethodType}, Tamanho do texto: {x.DeliveryMethodType.Length} excede ao permitido: 1");

            RuleFor(x => x.DeliveryLogisticType)
                .MaximumLength(60)
                .WithMessage(x => $"Property: DeliveryLogisticType | Value: {x.DeliveryLogisticType}, Tamanho do texto: {x.DeliveryLogisticType.Length} excede ao permitido: 60");

            RuleFor(x => x.ExternalID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: ExternalID | Value: {x.ExternalID}, Tamanho do texto: {x.ExternalID.Length} excede ao permitido: 60");

            RuleFor(x => x.WarehouseIntegrationID)
                .MaximumLength(60)
                .WithMessage(x => $"Property: WarehouseIntegrationID | Value: {x.WarehouseIntegrationID}, Tamanho do texto: {x.WarehouseIntegrationID.Length} excede ao permitido: 60");

            RuleFor(x => x.CarrierName)
                .MaximumLength(60)
                .WithMessage(x => $"Property: CarrierName | Value: {x.CarrierName}, Tamanho do texto: {x.CarrierName.Length} excede ao permitido: 60");

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
