using Domain.Core.Enums;
using Domain.Stone.Entities;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Stone.Data.Mappings
{
    public class StoneCarrierMetadataMap : IEntityTypeConfiguration<CarrierMetadata>
    {
        public void Configure(EntityTypeBuilder<CarrierMetadata> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(CarrierMetadata));

            builder.ToTable("StoneCarrierMetadatas");
            
            builder.HasKey(x => x.id);

            if (schema != "untreated")
            {
                builder
                    .HasOne(x => x.place)
                    .WithOne()
                    .OnDelete(DeleteBehavior.NoAction);
            }
            
            builder
            .Property(x => x.id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

            builder.Property(e => e.type)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.status)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.createdAt)
                .HasProviderColumnType(EnumTableColumnType.DateTime);
        }
    }
}
