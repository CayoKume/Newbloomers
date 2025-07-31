using Domain.AfterSale.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleProductsMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Product));

            builder.ToTable("AfterSaleProducts");

            builder.HasKey(c => c.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(c => c.reverse_id)
                .HasColumnType("int");

            builder
                .Property(c => c.motive_id)
                .HasColumnType("int");

            builder
                .Property(c => c.ecommerce_order_product_id)
                .HasColumnType("int");

            builder
                .Property(c => c.refund_id)
                .HasColumnType("int");

            builder
                .Property(c => c.qty)
                .HasColumnType("int");

            builder
                .Property(c => c.requested_qty)
                .HasColumnType("int");

            builder
                .Property(c => c.received_qty)
                .HasColumnType("int");

            builder.Property(e => e.order_id)
                .HasColumnType("int");

            builder.Property(e => e.product_received_comment)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.comments)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.reverse_action)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.customer_retention_method_id)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.protocol)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.product_id)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.hash)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.sku)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.price)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.selling_price)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.weight)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.returned_invoice)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.invoice)
                .HasColumnType("varchar(60)");
        }
    }
}
