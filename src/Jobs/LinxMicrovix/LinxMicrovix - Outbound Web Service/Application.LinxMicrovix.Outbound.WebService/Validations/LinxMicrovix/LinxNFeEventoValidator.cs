using Application.Core.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Validations.LinxMicrovix
{
    public class LinxNFeEventoValidator : AbstractValidator<LinxNFeEvento>
    {
        public LinxNFeEventoValidator()
        {
            RuleFor(x => x.portal).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.portal));
            RuleFor(x => x.id_nfe_evento).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_nfe_evento));
            RuleFor(x => x.id_nfe).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_nfe));
            RuleFor(x => x.cnpj_emp).MaximumLength(14).WithMessage("O campo 'cnpj_emp' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.cnpj_emp));
            RuleFor(x => x.timestamp).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.timestamp));
            RuleFor(x => x.codigo_tipo).MaximumLength(6).WithMessage("O campo 'codigo_tipo' deve ter no máximo 6 caracteres.").When(x => !string.IsNullOrEmpty(x.codigo_tipo));
            RuleFor(x => x.hora_emissao).MaximumLength(5).WithMessage("O campo 'hora_emissao' deve ter no máximo 5 caracteres.").When(x => !string.IsNullOrEmpty(x.hora_emissao));
            RuleFor(x => x.data_emissao).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.data_emissao));
        }
    }
}
