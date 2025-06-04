using Domain.Jadlog.DTOs;
using FluentValidation;
using System.Globalization;

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
            .Must((x, previsaoEntrega) =>
            {
                    if (previsaoEntrega == null || DateTime.Parse(previsaoEntrega, new CultureInfo("pt-BR")) < new DateTime(1753, 1, 1))
                        x.previsaoEntrega = new DateTime(1753, 1, 1).ToString();
                    return true;
                })
                .WithMessage(x => $"Date: {x.previsaoEntrega} must be between 01/01/1753 and 31/12/9999.")
                .Must(x => ConvertToDateTimeValidation.IsValid(x))
                .WithMessage(x => $"Property: previsaoEntrega | Value: {x.previsaoEntrega}, Error when trying to convert value: {x.previsaoEntrega} to DateTime");
        }
    }
}
