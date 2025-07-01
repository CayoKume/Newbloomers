using Domain.IntegrationsCore.Enums;
using Domain.Stone.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StoneDeliveryAddressMap : IEntityTypeConfiguration<DeliveryAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(DeliveryAddress));

            builder.ToTable("StoneDeliveryAddresses");

            builder.HasKey(x => x.id);

            builder
            .Property(x => x.id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            builder.Property(e => e.address)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.addressNumber)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.city)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.complement)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.country)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.countryState)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.latitude)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.longitude)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.neighborhood)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.zipCode)
                .HasColumnType("varchar(60)");
        }
    }
}
