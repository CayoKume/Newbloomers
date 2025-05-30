using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleRefundsMap : IEntityTypeConfiguration<Refund>
    {
        public void Configure(EntityTypeBuilder<Refund> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Refund));

            builder.ToTable("AfterSaleRefunds");

            builder
                .HasOne(x => x.voucher)
                .WithMany()
                .HasForeignKey(y => y.voucher_giftcard_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.total_amount_histories)
                .WithOne(t => t.Refund)
                .HasForeignKey<TotalAmountHistories>(t => t.refund_id)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(x => x.status_histories)
                .WithMany()
                .HasForeignKey(y => y.reverse_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.customer)
                .WithMany()
                .HasForeignKey(y => y.customer_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.status)
                .WithMany()
                .HasForeignKey(y => y.status_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.products)
                .WithOne()
                .HasForeignKey(y => y.refund_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.order_transactions)
                .WithOne()
                .HasForeignKey(y => y.refund_id);

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.type)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.action)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.bonus_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.bonus_amount_percent)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.requested_shipping_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.shipping_method)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.requested_raw_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.requested_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.received_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.received_raw_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.total_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.free_shipping)
                .HasProviderColumnType(EnumTableColumnType.Bool); ;

            builder
                .Property(x => x.created_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.cashback_account)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.should_ask_voucher_code)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.requested_total_amount)
                .HasColumnType("decimal(10,2)");

            builder
                .Property(x => x.can_edit_wire_transfer)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.has_wire_transfer_account)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.customer_retention_method_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.external_order_url)
                .HasColumnType("varchar(4000)");

            builder
                .Property(x => x.reverse_id)
                .HasColumnType("int");

            builder
                .Property(x => x.order_id)
                .HasColumnType("varchar(50)");

            builder
                .Property(x => x.ecommerce_order_id)
                .HasColumnType("int");

            builder
                .Property(x => x.last_status_history_date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.refunded_shipping_type)
                .HasColumnType("varchar(50)");
        }
    }
}
