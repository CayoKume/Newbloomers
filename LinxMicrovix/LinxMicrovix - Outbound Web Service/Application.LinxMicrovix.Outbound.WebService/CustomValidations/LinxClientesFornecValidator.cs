using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations
{
    public class LinxClientesFornecValidator : AbstractValidator<LinxClientesFornec>
    {
        public LinxClientesFornecValidator()
        {
            RuleFor(x => x.doc_cliente)
                .NotEmpty().WithMessage("O documento do cliente é obrigatório.")
                .MaximumLength(14).WithMessage("O documento do cliente não pode exceder 14 caracteres.");

            RuleFor(x => x.razao_cliente)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .MaximumLength(60).WithMessage("A razão social não pode exceder 60 caracteres.");

            RuleFor(x => x.email_cliente)
                .EmailAddress().WithMessage("O e-mail fornecido não é válido.")
                .MaximumLength(50).WithMessage("O e-mail não pode exceder 50 caracteres.");

            RuleFor(x => x.tipo_cliente)
                .NotEmpty().WithMessage("O tipo do cliente é obrigatório.")
                .Length(1).WithMessage("O tipo do cliente deve ter apenas 1 caractere.");
        }
    }
}
