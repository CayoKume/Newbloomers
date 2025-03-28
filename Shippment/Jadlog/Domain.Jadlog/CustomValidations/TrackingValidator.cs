using Domain.Jadlog.DTOs;
using FluentValidation;

namespace Domain.Jadlog.CustomValidations
{
    public class TrackingValidator : AbstractValidator<Tracking>
    {
        public TrackingValidator()
        {
            RuleFor(x => x.codigo)
                .MaximumLength(14)
                .WithMessage(x => $"Property: codigo | Value: {x.codigo}, Tamanho do texto: {x.codigo.Length} excede ao permitido: 14")
                .Must((x, codigo) =>
                {
                    if (codigo != null && codigo.Length > 14)
                        x.codigo = x.codigo.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.shipmentId)
                .MaximumLength(14)
                .WithMessage(x => $"Property: shipmentId | Value: {x.shipmentId}, Tamanho do texto: {x.shipmentId.Length} excede ao permitido: 14")
                .Must((x, shipmentId) =>
                {
                    if (shipmentId != null && shipmentId.Length > 14)
                        x.shipmentId = x.shipmentId.Substring(0, 14);
                    return true;
                });

            RuleFor(x => x.dacte)
                .MaximumLength(44)
                .WithMessage(x => $"Property: dacte | Value: {x.dacte}, Tamanho do texto: {x.dacte.Length} excede ao permitido: 44")
                .Must((x, dacte) =>
                {
                    if (dacte != null && dacte.Length > 44)
                        x.dacte = x.dacte.Substring(0, 44);
                    return true;
                });

            RuleFor(x => x.status)
                .MaximumLength(30)
                .WithMessage(x => $"Property: status | Value: {x.status}, Tamanho do texto: {x.status.Length} excede ao permitido: 30")
                .Must((x, status) =>
                {
                    if (status != null && status.Length > 30)
                        x.status = x.status.Substring(0, 30);
                    return true;
                });

            RuleFor(x => x.dtEmissao)
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: dtEmissao | Value: {x.dtEmissao}, Error when trying to convert value: {x.dtEmissao.ToString()} to DateTime");

            RuleFor(x => x.recebedor)
                .SetValidator(new RecebedorValidator());

            RuleForEach(x => x.eventos)
                .SetValidator(new EventoValidator());
        }
    }
}
