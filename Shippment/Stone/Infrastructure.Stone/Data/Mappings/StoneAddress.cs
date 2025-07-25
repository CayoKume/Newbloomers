using Domain.Stone.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StoneAddress : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Address));

            builder.ToTable("StoneAddresses");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.cidade)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.uf)
                .HasColumnType("varchar(60)");
        }
    }
}
