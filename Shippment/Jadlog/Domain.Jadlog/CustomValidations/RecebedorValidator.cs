using Domain.Jadlog.DTOs;
using FluentValidation;

namespace Domain.Jadlog.CustomValidations
{
    public class RecebedorValidator : AbstractValidator<Recebedor>
    {
        public RecebedorValidator()
        {
            RuleFor(x => x.nome)
                .MaximumLength(60)
                .WithMessage(x => $"Property: nome | Value: {x.nome}, Tamanho do texto: {x.nome.Length} excede ao permitido: 60")
                .Must((x, nome) =>
                {
                    if (nome != null && nome.Length > 60)
                        x.nome = x.nome.Substring(0, 60);
                    return true;
                });

            RuleFor(x => x.doc)
                .MaximumLength(14)
                .WithMessage(x => $"Property: doc | Value: {x.doc}, Tamanho do texto: {x.doc.Length} excede ao permitido: 14")
                .Must((x, doc) =>
                {
                    if (doc != null && doc.Length > 14)
                        x.doc = x.doc.Substring(0, 14);
                    return true;
                });
        }
    }
}
