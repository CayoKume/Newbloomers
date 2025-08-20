using Application.Core.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.Validations.LinxMicrovix
{
    public class LinxDevolucaoRemanejoFabricaStatusValidator : AbstractValidator<LinxDevolucaoRemanejoFabricaStatus>
    {
        public LinxDevolucaoRemanejoFabricaStatusValidator()
        {
            RuleFor(x => x.id_devolucao_remanejo_fabrica_status).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_devolucao_remanejo_fabrica_status));
            RuleFor(x => x.id_devolucao_remanejo_fabrica_tipo).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_devolucao_remanejo_fabrica_tipo));
            RuleFor(x => x.descricao).MaximumLength(100).WithMessage("O campo 'descricao' deve ter no máximo 100 caracteres.").When(x => !string.IsNullOrEmpty(x.descricao));
            RuleFor(x => x.timestamp).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.timestamp));
        }
    }
}
