using Application.IntegrationsCore.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations.LinxMicrovix
{
    public class LinxOticoPrismaDescricaoValidator : AbstractValidator<LinxOticoPrismaDescricao>
    {
        public LinxOticoPrismaDescricaoValidator()
        {
            RuleFor(x => x.id_otico_prisma_descricao).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_otico_prisma_descricao));
            RuleFor(x => x.descricao).MaximumLength(10).WithMessage("O campo 'descricao' deve ter no máximo 10 caracteres.").When(x => !string.IsNullOrEmpty(x.descricao));
            RuleFor(x => x.portal).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.portal));
            RuleFor(x => x.timestamp).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.timestamp));
        }
    }
}
