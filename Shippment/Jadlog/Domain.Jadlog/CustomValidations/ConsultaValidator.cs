using Domain.Jadlog.DTOs;
using FluentValidation;

namespace Domain.Jadlog.CustomValidations
{
    public class ConsultaValidator : AbstractValidator<Consulta>
    {
        public ConsultaValidator()
        {
            RuleFor(x => x.shipmentId)
                .MaximumLength(14)
                .WithMessage(x => $"Property: shipmentId | Value: {x.shipmentId}, Tamanho do texto: {x.shipmentId.Length} excede ao permitido: 14")
                .Must((x, shipmentId) =>
                {
                    if (shipmentId != null && shipmentId.Length > 14)
                        x.shipmentId = x.shipmentId.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.tracking)
                .SetValidator(new TrackingValidator());

            RuleFor(x => x.previsaoEntrega)
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: previsaoEntrega | Value: {x.previsaoEntrega}, Error when trying to convert value: {x.previsaoEntrega.ToString()} to DateTime");
        }
    }
}
