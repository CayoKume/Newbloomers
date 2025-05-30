using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = Domain.AfterSale.Entities.Action;

namespace Infrastructure.AfterSale.Data.Mappings
{
    public class AfterSaleActionMap : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Action));

            builder.ToTable("AfterSaleActions");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");
        }
    }
}
