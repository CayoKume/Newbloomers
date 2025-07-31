using Application.IntegrationsCore.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations.LinxMicrovix
{
    public class LinxMovimentoTrocafoneValidator : AbstractValidator<LinxMovimentoTrocafone>
    {
        public LinxMovimentoTrocafoneValidator()
        {
            RuleFor(x => x.portal).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.portal));
            RuleFor(x => x.cnpj_emp).MaximumLength(14).WithMessage("O campo 'cnpj_emp' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.cnpj_emp));
            RuleFor(x => x.identificador).Must(value => Guid.TryParse(value, out _)).WithMessage("O campo 'identificador' deve ser um GUID válido.").When(x => !string.IsNullOrEmpty(x.identificador));
            RuleFor(x => x.num_vale).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.num_vale));
            RuleFor(x => x.voucher).MaximumLength(100).WithMessage("O campo 'voucher' deve ter no máximo 100 caracteres.").When(x => !string.IsNullOrEmpty(x.voucher));
            RuleFor(x => x.valor_vale).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.valor_vale));
            RuleFor(x => x.nome_produto).MaximumLength(250).WithMessage("O campo 'nome_produto' deve ter no máximo 250 caracteres.").When(x => !string.IsNullOrEmpty(x.nome_produto));
            RuleFor(x => x.condicao).MaximumLength(250).WithMessage("O campo 'condicao' deve ter no máximo 250 caracteres.").When(x => !string.IsNullOrEmpty(x.condicao));
            RuleFor(x => x.id_tradein_parceiro).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id_tradein_parceiro));
        }
    }
}
