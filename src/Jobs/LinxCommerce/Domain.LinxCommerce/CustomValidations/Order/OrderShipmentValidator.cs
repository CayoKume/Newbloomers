using Domain.LinxCommerce.Entities.Order;
using FluentValidation;

namespace Domain.LinxCommerce.CustomValidations.Order
{
    public class OrderShipmentValidator : AbstractValidator<OrderShipment>
    {
        public OrderShipmentValidator()
        {
            RuleFor(x => x.ShipmentNumber)
                .MaximumLength(10)
                .WithMessage(x => $"Property: ShipmentNumber | Value: {x.ShipmentNumber}, Tamanho do texto: {x.ShipmentNumber.Length} excede ao permitido: 10")
                .Must((x, shipmentNumber) =>
                {
                    if (shipmentNumber != null && shipmentNumber.Length > 10)
                        x.ShipmentNumber = x.ShipmentNumber.Substring(0, 10);
                    return true;
                });

            RuleFor(x => x.ShipmentStatus)
                .MaximumLength(1)
                .WithMessage(x => $"Property: ShipmentStatus | Value: {x.ShipmentStatus}, Tamanho do texto: {x.ShipmentStatus.Length} excede ao permitido: 1")
                .Must((x, shipmentStatus) =>
                {
                    if (shipmentStatus != null && shipmentStatus.Length > 1)
                        x.ShipmentStatus = x.ShipmentStatus.Substring(0, 1);
                    return true;
                });

            RuleFor(x => x.AssignUserName)
                .MaximumLength(50)
                .WithMessage(x => $"Property: AssignUserName | Value: {x.AssignUserName}, Tamanho do texto: {x.AssignUserName.Length} excede ao permitido: 50")
                .Must((x, assignUserName) =>
                {
                    if (assignUserName != null && assignUserName.Length > 50)
                        x.AssignUserName = x.AssignUserName.Substring(0, 50);
                    return true;
                });
        }
    }
}
