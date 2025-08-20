using Domain.AfterSale.Entities;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleReasonsMap : IEntityTypeConfiguration<Domain.AfterSale.Entities.Reason>
    {
        public void Configure(EntityTypeBuilder<Reason> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Reason));

            builder.ToTable("AfterSaleReasons");

            builder.HasKey(c => c.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.ecommerce_id)
                .HasColumnType("int");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.reason_category_id)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.action)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.upload_image)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.ord)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.should_approve)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.show_product_grid)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.created_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.deleted_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
