using Domain.AfterSale.Entities;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleStatusHistoriesMap : IEntityTypeConfiguration<StatusHistories>
    {
        public void Configure(EntityTypeBuilder<StatusHistories> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(StatusHistories));

            builder.ToTable("AfterSaleStatusHistories");

            builder.HasKey(x => x.id);

            if (schema == "untreated")
            {
                builder.Ignore(x => x.status);
            }

            builder
            .Property(x => x.id)
            .HasColumnType("int")
            .ValueGeneratedNever();

            builder
                .Property(x => x.reverse_id)
                .HasColumnType("int");

            builder
                .Property(x => x.status_id)
                .HasColumnType("int");

            builder
                .Property(x => x.user_id)
                .HasColumnType("int");

            builder
                .Property(x => x.customer_id)
                .HasColumnType("int");

            builder.Property(e => e.comments)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.date)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
