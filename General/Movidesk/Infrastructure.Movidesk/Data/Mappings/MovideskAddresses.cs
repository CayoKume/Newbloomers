using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskAddressesMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Address));

            builder.ToTable("MovideskAddresses");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.addressType)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.country)
                .HasColumnType("varchar(80)");

            builder
                .Property(x => x.postalCode)
                .HasColumnType("char(9)");

            builder
                .Property(x => x.state)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.district)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.city)
                .HasColumnType("varchar(40)");

            builder
                .Property(x => x.street)
                .HasColumnType("varchar(250)");

            builder
                .Property(x => x.number)
                .HasColumnType("varchar(20)");

            builder
                .Property(x => x.complement)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.reference)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.isDefault)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder
                .Property(x => x.countryId)
                .HasColumnType("int");
        }
    }
}
