using Application.IntegrationsCore.Validations.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Dtos.LinxCommerce;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations.LinxCommerce
{
    public class B2CConsultaPedidosStatusValidator : AbstractValidator<B2CConsultaPedidosStatus>
    {
        public B2CConsultaPedidosStatusValidator()
        {
            RuleFor(x => x.id)
                .MustBeValidInt32()
                .When(x => !string.IsNullOrEmpty(x.id));

            RuleFor(x => x.id_status)
                .MustBeValidInt32()
                .When(x => !string.IsNullOrEmpty(x.id_status));

            RuleFor(x => x.id_pedido)
                .MustBeValidInt32()
                .When(x => !string.IsNullOrEmpty(x.id_pedido));

            RuleFor(x => x.data_hora)
                .MustBeValidDateTime()
                .When(x => !string.IsNullOrEmpty(x.data_hora));

            RuleFor(x => x.anotacao)
                .MaximumLength(80)
                .WithMessage("O campo 'anotacao' deve ter no máximo 80 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.anotacao));

            RuleFor(x => x.timestamp)
                .MustBeValidInt64()
                .When(x => !string.IsNullOrEmpty(x.timestamp));

            RuleFor(x => x.portal)
                .MustBeValidInt32()
                .When(x => !string.IsNullOrEmpty(x.portal));
        }
    }
}
