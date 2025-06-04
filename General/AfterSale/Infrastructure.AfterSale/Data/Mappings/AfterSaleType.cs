using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleTypeMap : IEntityTypeConfiguration<Domain.AfterSale.Entities.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.AfterSale.Entities.Type> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Domain.AfterSale.Entities.Type));

            builder.ToTable("AfterSaleTypes");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");
        }
    }
}
