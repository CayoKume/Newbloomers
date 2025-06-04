using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reverse = Domain.AfterSale.Entities.Reverse;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleReversesMap : IEntityTypeConfiguration<Reverse>
    {
        public void Configure(EntityTypeBuilder<Reverse> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Reverse));

            builder.ToTable("AfterSaleReverses");

            //builder.HasOne(x => x.destination_data);

            if (schema != "untreated")
            {
                builder
                    .HasOne(x => x.ecommerce)
                    .WithMany()
                    .HasForeignKey(y => y.ecommerce_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasOne(x => x.status)
                    .WithMany()
                    .HasForeignKey(y => y.status_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasOne(x => x.tracking)
                    .WithOne(y => y.reverse)
                    .HasForeignKey<Tracking>(y => y.reverse_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasOne(x => x.customer)
                    .WithMany()
                    .HasForeignKey(y => y.customer_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.products)
                    .WithOne()
                    .HasForeignKey(y => y.reverse_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.refunds)
                    .WithOne()
                    .HasForeignKey(y => y.reverse_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.status_histories)
                    .WithOne()
                    .HasForeignKey(y => y.reverse_id)
                    .OnDelete(DeleteBehavior.NoAction);

                builder
                    .HasMany(x => x.tracking_history)
                    .WithOne()
                    .HasForeignKey(y => y.tracking_id)
                    .OnDelete(DeleteBehavior.NoAction); 
            }
            else
            {
                builder.Ignore(x => x.ecommerce);
                builder.Ignore(x => x.status);
                builder.Ignore(x => x.tracking);
                builder.Ignore(x => x.customer);
                builder.Ignore(x => x.products);
                builder.Ignore(x => x.refunds);
                builder.Ignore(x => x.status_histories);
                builder.Ignore(x => x.tracking_history);
            }

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.reverse_type)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.courier_collect)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.courier_service_type)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.service_type_changed)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.ecommerce_order_id)
                .HasColumnType("int");

            builder
                .Property(x => x.store_id)
                .HasColumnType("int");

            builder
                .Property(x => x.courier_contract_id)
                .HasColumnType("int");

            builder
                .Property(x => x.brand_id)
                .HasColumnType("int");

            builder
                .Property(x => x.total_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.invoice)
                .HasColumnType("int");

            builder
                .Property(x => x.posting_card)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.is_store_seller_contract)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.locker_reference)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.store_expire_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.skip_process_step)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.freight_by_customer)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.tracking_error)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.origin)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.external_source)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.order_sequence_number)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.billing_item_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.created_by)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.created_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.deleted_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.status_id)
                .HasColumnType("int");

            builder
                .Property(x => x.type)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.ecommerce_id)
                .HasColumnType("int");

            builder
                .Property(x => x.partner_store)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.destination_seller_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.origin_seller_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.is_erased)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.service_type_change)
                .HasColumnType("int");

            builder
                .Property(x => x.billing_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.must_treat_refund)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.reverse_type_name)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.is_generic_courier)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.can_generate_voucher)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.could_cancel)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.can_send_correction_letter)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.correction_letter_link)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.customer_url)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.timeline_url)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.collect_scheduling_link)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.returned_invoice)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.dot_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.order_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.refunds_count)
                .HasColumnType("decimal(10,2)");
        }
    }
}
