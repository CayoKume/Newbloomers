using Domain.Jadlog.DTOs;
using FluentValidation;

namespace Domain.Jadlog.CustomValidations
{
    public class EventoValidator : AbstractValidator<Evento>
    {
        public EventoValidator()
        {
            RuleFor(x => x.status)
                .MaximumLength(30)
                .WithMessage(x => $"Property: status | Value: {x.status}, Tamanho do texto: {x.status.Length} excede ao permitido: 30")
                .Must((x, status) =>
                {
                    if (status != null && status.Length > 30)
                        x.status = x.status.Substring(0, 30);
                    return true;
                });

            RuleFor(x => x.unidade)
                .MaximumLength(50)
                .WithMessage(x => $"Property: unidade | Value: {x.unidade}, Tamanho do texto: {x.unidade.Length} excede ao permitido: 50")
                .Must((x, unidade) =>
                {
                    if (unidade != null && unidade.Length > 50)
                        x.unidade = x.unidade.Substring(0, 50);
                    return true;
                });

            RuleFor(x => x.data)
                .Must(x => ConvertToDateTimeValidation.IsValid(x.ToString()))
                .WithMessage(x => $"Property: data | Value: {x.data}, Error when trying to convert value: {x.data.ToString()} to DateTime");
        }
    }
}
