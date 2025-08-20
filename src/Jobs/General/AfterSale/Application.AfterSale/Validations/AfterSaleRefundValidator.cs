using FluentValidation;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleRefundValidator : AbstractValidator<Refund>
    {
        public AfterSaleRefundValidator()
        {
            RuleFor(x => x.id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.reverse_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.reverse_id));
            RuleFor(x => x.ecommerce_order_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_order_id));
            RuleFor(x => x.customer_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.customer_id));
            RuleFor(x => x.status_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.status_id));
            RuleFor(x => x.type).MaximumLength(14).WithMessage("O campo 'type' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.type));
            RuleFor(x => x.action).MaximumLength(14).WithMessage("O campo 'action' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.action));
            RuleFor(x => x.shipping_method).MaximumLength(14).WithMessage("O campo 'shipping_method' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.shipping_method));
            RuleFor(x => x.cashback_account).MaximumLength(14).WithMessage("O campo 'cashback_account' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.cashback_account));
            RuleFor(x => x.customer_retention_method_id).MaximumLength(14).WithMessage("O campo 'customer_retention_method_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.customer_retention_method_id));
            RuleFor(x => x.external_order_url).MaximumLength(14).WithMessage("O campo 'external_order_url' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.external_order_url));
            RuleFor(x => x.order_id).MaximumLength(14).WithMessage("O campo 'order_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.order_id));
            RuleFor(x => x.refunded_shipping_type).MaximumLength(14).WithMessage("O campo 'refunded_shipping_type' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.refunded_shipping_type));
            RuleFor(x => x.voucher_giftcard_id).MaximumLength(14).WithMessage("O campo 'voucher_giftcard_id' deve ter no máximo 14 caracteres.").When(x => !string.IsNullOrEmpty(x.voucher_giftcard_id));
            RuleFor(x => x.created_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.created_at));
            RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.last_status_history_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.last_status_history_date));
            RuleFor(x => x.bonus_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.bonus_amount));
            RuleFor(x => x.bonus_amount_percent).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.bonus_amount_percent));
            RuleFor(x => x.requested_shipping_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.requested_shipping_amount));
            RuleFor(x => x.requested_raw_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.requested_raw_amount));
            RuleFor(x => x.requested_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.requested_amount));
            RuleFor(x => x.received_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.received_amount));
            RuleFor(x => x.received_raw_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.received_raw_amount));
            RuleFor(x => x.total_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.total_amount));
            RuleFor(x => x.requested_total_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.requested_total_amount));
            RuleFor(x => x.free_shipping).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.free_shipping));
            RuleFor(x => x.should_ask_voucher_code).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.should_ask_voucher_code));
            RuleFor(x => x.can_edit_wire_transfer).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.can_edit_wire_transfer));
            RuleFor(x => x.has_wire_transfer_account).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.has_wire_transfer_account));

            RuleFor(x => x.customer)
                .SetValidator(new AfterSaleCustomerValidator());

            RuleFor(x => x.status)
                .SetValidator(new AfterSaleStatusValidator());

            RuleFor(x => x.status_histories)
                .SetValidator(new AfterSaleStatusHistoriesValidator());

            RuleFor(x => x.total_amount_histories)
                .SetValidator(new AfterSaleTotalAmountHistoriesValidator());

            RuleFor(x => x.voucher)
                .SetValidator(new AfterSaleVoucherValidator());

            RuleFor(x => x.reverse)
                .SetValidator(new AfterSaleReverseValidator());

            RuleForEach(x => x.products)
                .SetValidator(new AfterSaleProductValidator());

            RuleForEach(x => x.order_transactions)
                .SetValidator(new AfterSaleOrderTransactionsValidator());
        }
    }
}
