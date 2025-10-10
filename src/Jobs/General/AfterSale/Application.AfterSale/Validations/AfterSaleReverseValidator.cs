using Domain.Core.Extensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.AfterSale.Dtos;
using Application.Core.Validations.Extensions;

namespace Application.AfterSale.Validations
{
    public class AfterSaleReverseValidator : AbstractValidator<Reverse>
    {
        public AfterSaleReverseValidator()
        {
            //RuleFor(x => x.id).MustBeValidInt64().When(x => !string.IsNullOrEmpty(x.id));
            RuleFor(x => x.service_type_changed).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.service_type_changed));
            RuleFor(x => x.ecommerce_order_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_order_id));
            RuleFor(x => x.store_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.store_id));
            RuleFor(x => x.courier_contract_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.courier_contract_id));
            RuleFor(x => x.brand_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.brand_id));
            RuleFor(x => x.invoice).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.invoice));
            RuleFor(x => x.status_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.status_id));
            RuleFor(x => x.ecommerce_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.ecommerce_id));
            RuleFor(x => x.service_type_change).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.service_type_change));
            RuleFor(x => x.customer_id).MustBeValidInt32().When(x => !string.IsNullOrEmpty(x.customer_id));

            RuleFor(x => x.reverse_type).MaximumLength(50).WithMessage("O campo 'reverse_type' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.reverse_type));
            RuleFor(x => x.courier_service_type).MaximumLength(50).WithMessage("O campo 'courier_service_type' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.courier_service_type));
            RuleFor(x => x.posting_card).MaximumLength(50).WithMessage("O campo 'posting_card' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.posting_card));
            RuleFor(x => x.locker_reference).MaximumLength(50).WithMessage("O campo 'locker_reference' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.locker_reference));
            RuleFor(x => x.tracking_error).MaximumLength(50).WithMessage("O campo 'tracking_error' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.tracking_error));
            RuleFor(x => x.origin).MaximumLength(50).WithMessage("O campo 'origin' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.origin));
            RuleFor(x => x.external_source).MaximumLength(50).WithMessage("O campo 'external_source' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.external_source));
            RuleFor(x => x.order_sequence_number).MaximumLength(50).WithMessage("O campo 'order_sequence_number' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.order_sequence_number));
            RuleFor(x => x.billing_item_id).MaximumLength(50).WithMessage("O campo 'billing_item_id' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.billing_item_id));
            //RuleFor(x => x.created_by).MaximumLength(50).WithMessage("O campo 'created_by' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.created_by));
            RuleFor(x => x.type).MaximumLength(50).WithMessage("O campo 'type' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.type));
            RuleFor(x => x.partner_store).MaximumLength(50).WithMessage("O campo 'partner_store' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.partner_store));
            RuleFor(x => x.destination_seller_id).MaximumLength(50).WithMessage("O campo 'destination_seller_id' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.destination_seller_id));
            RuleFor(x => x.origin_seller_id).MaximumLength(50).WithMessage("O campo 'origin_seller_id' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.origin_seller_id));
            RuleFor(x => x.reverse_type_name).MaximumLength(50).WithMessage("O campo 'reverse_type_name' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.reverse_type_name));
            RuleFor(x => x.correction_letter_link).MaximumLength(4000).WithMessage("O campo 'correction_letter_link' deve ter no máximo 4000 caracteres.").When(x => !string.IsNullOrEmpty(x.correction_letter_link));
            RuleFor(x => x.customer_url).MaximumLength(4000).WithMessage("O campo 'customer_url' deve ter no máximo 4000 caracteres.").When(x => !string.IsNullOrEmpty(x.customer_url));
            RuleFor(x => x.timeline_url).MaximumLength(4000).WithMessage("O campo 'timeline_url' deve ter no máximo 4000 caracteres.").When(x => !string.IsNullOrEmpty(x.timeline_url));
            RuleFor(x => x.collect_scheduling_link).MaximumLength(4000).WithMessage("O campo 'collect_scheduling_link' deve ter no máximo 4000 caracteres.").When(x => !string.IsNullOrEmpty(x.collect_scheduling_link));
            RuleFor(x => x.returned_invoice).MaximumLength(50).WithMessage("O campo 'returned_invoice' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.returned_invoice));
            RuleFor(x => x.dot_id).MaximumLength(50).WithMessage("O campo 'dot_id' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.dot_id));
            RuleFor(x => x.order_id).MaximumLength(50).WithMessage("O campo 'order_id' deve ter no máximo 50 caracteres.").When(x => !string.IsNullOrEmpty(x.order_id));
            
            RuleFor(x => x.store_expire_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.store_expire_date));
            RuleFor(x => x.created_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.created_at));
            //RuleFor(x => x.updated_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.updated_at));
            RuleFor(x => x.deleted_at).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.deleted_at));
            RuleFor(x => x.billing_date).MustBeValidDateTime().When(x => !string.IsNullOrEmpty(x.billing_date));
            
            RuleFor(x => x.courier_collect).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.courier_collect));
            RuleFor(x => x.is_store_seller_contract).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_store_seller_contract));
            RuleFor(x => x.skip_process_step).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.skip_process_step));
            RuleFor(x => x.freight_by_customer).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.freight_by_customer));
            RuleFor(x => x.is_erased).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_erased));
            RuleFor(x => x.must_treat_refund).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.must_treat_refund));
            RuleFor(x => x.is_generic_courier).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.is_generic_courier));
            RuleFor(x => x.can_generate_voucher).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.can_generate_voucher));
            RuleFor(x => x.could_cancel).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.could_cancel));
            RuleFor(x => x.can_send_correction_letter).MustBeValidBoolean().When(x => !string.IsNullOrEmpty(x.can_send_correction_letter));

            RuleFor(x => x.total_amount).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.total_amount));
            RuleFor(x => x.refunds_count).MustBeValidDecimal().When(x => !string.IsNullOrEmpty(x.refunds_count));

            RuleFor(x => x.ecommerce)
                .SetValidator(new AfterSaleEcommerceValidator());

            RuleFor(x => x.customer)
                .SetValidator(new AfterSaleCustomerValidator());

            RuleFor(x => x.status)
                .SetValidator(new AfterSaleStatusValidator());

            RuleFor(x => x.tracking)
                .SetValidator(new AfterSaleTrackingValidator());

            RuleFor(x => x.destination_data)
                .SetValidator(new AfterSaleDestinationValidator());

            RuleFor(x => x.courier_data_encrypted)
                .SetValidator(new AfterSaleCourierDataEncryptedValidator());

            RuleForEach(x => x.products)
                .SetValidator(new AfterSaleProductValidator());

            RuleForEach(x => x.refunds)
                .SetValidator(new AfterSaleRefundValidator());

            RuleForEach(x => x.status_histories)
                .SetValidator(new AfterSaleStatusHistoriesValidator());

            RuleForEach(x => x.tracking_history)
                .SetValidator(new AfterSaleTrackingHistoryValidator());
        }
    }
}
