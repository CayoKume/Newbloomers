using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskCustomFieldItemsMap : IEntityTypeConfiguration<CustomFieldItem>
    {
        public void Configure(EntityTypeBuilder<CustomFieldItem> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(CustomFieldItem));

            builder.ToTable("MovideskCustomFieldItems");

            builder.HasKey(x => x.personId);

            builder
                .Property(x => x.personId)
                .HasColumnType("int");

            builder
                .Property(x => x.clientId)
                .HasColumnType("int");

            builder
                .Property(x => x.team)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.customFieldItem)
                .HasColumnType("varchar(300)");
        }
    }
}
