using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using FluentValidation;

namespace Application.LinxMicrovix.Outbound.WebService.CustomValidations
{
    public class LinxB2CPedidosValidator : AbstractValidator<LinxB2CPedidos>
    {
        public LinxB2CPedidosValidator()
        {
            RuleFor(x => x.id_pedido)
                .NotNull().WithMessage("O ID do pedido é obrigatório.");

            RuleFor(x => x.cod_cliente_erp)
                .NotNull().WithMessage("O código do cliente ERP é obrigatório.");

            RuleFor(x => x.cod_cliente_b2c)
                .NotNull().WithMessage("O código do cliente B2C é obrigatório.");

            RuleFor(x => x.dt_pedido)
                .NotEmpty().WithMessage("A data do pedido é obrigatória.");

            RuleFor(x => x.order_id)
                .MaximumLength(40).WithMessage("O Order ID não pode exceder 40 caracteres.");
        }
    }
}
