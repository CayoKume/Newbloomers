using Application.IntegrationsCore.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations.LinxMicrovix
{
    public class LinxMotivosDesoneracaoIcmsValidator : AbstractValidator<LinxMotivosDesoneracaoIcms>
    {
        public LinxMotivosDesoneracaoIcmsValidator()
        {
            RuleFor(x => x.id_motivos_desoneracao_icms).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_motivos_desoneracao_icms));
            RuleFor(x => x.portal).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.portal));
            RuleFor(x => x.descricao).MaximumLength(200).WithMessage("O campo 'descricao' deve ter no máximo 200 caracteres.").When(x => !string.IsNullOrEmpty(x.descricao));
            RuleFor(x => x.timestamp).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.timestamp));
        }
    }
}