using Domain.AfterSale.Entities;
using Domain.IntegrationsCore.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    internal class AfterSaleOrderTransactionsMap : IEntityTypeConfiguration<OrderTransactions>
    {
        public void Configure(EntityTypeBuilder<OrderTransactions> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(OrderTransactions));

            builder.ToTable("AfterSaleOrderTransactions");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.ecommerce_order_id)
                .HasColumnType("int");

            builder
                .Property(x => x.transaction_id)
                .HasColumnType("int");

            builder.Property(e => e.acquirer)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.nsu)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.tid)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.merchant_name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.total_amount)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
