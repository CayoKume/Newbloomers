using Domain.AfterSale.Entities;
using Domain.Core.Enums;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleAddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Address));

            builder.ToTable("AfterSaleAddresses");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.zip_code)
                .HasColumnType("char(9)");

            builder
                .Property(x => x.address)
                .HasColumnType("varchar(250)");

            builder
                .Property(x => x.complement)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.number)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.neighborhood)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.city)
                .HasColumnType("varchar(40)");

            builder
                .Property(x => x.state)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.lat)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.@long)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.updated_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder
                .Property(x => x.deleted_at)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
