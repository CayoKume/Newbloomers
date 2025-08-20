using Application.Core.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Validations.LinxMicrovix
{
    public class LinxCoresValidator : AbstractValidator<LinxCores>
    {
        public LinxCoresValidator()
        {
            RuleFor(x => x.id_cor).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_cor));
            RuleFor(x => x.desc_cor).MaximumLength(30).WithMessage("O campo 'desc_cor' deve ter no máximo 30 caracteres.").When(x => !string.IsNullOrEmpty(x.desc_cor));
            RuleFor(x => x.timestamp).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.timestamp));
            RuleFor(x => x.codigo_integracao_ws).MaximumLength(50).WithMessage("O campo 'codigo_integracao_ws' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.codigo_integracao_ws));
            RuleFor(x => x.ativo).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.ativo));
        }
    }
}
