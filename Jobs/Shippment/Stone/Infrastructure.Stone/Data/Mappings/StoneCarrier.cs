using Domain.Stone.Entities;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StoneCarrierMap : IEntityTypeConfiguration<Carrier>
    {
        public void Configure(EntityTypeBuilder<Carrier> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Carrier));

            builder.ToTable("StoneCarriers");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.service)
                .HasColumnType("varchar(60)");
        }
    }
}
