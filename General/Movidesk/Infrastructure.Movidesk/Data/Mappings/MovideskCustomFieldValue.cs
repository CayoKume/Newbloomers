using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskCustomFieldValueMap : IEntityTypeConfiguration<CustomFieldValue>
    {
        public void Configure(EntityTypeBuilder<CustomFieldValue> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(CustomFieldValue));

            builder.ToTable("MovideskCustomFieldValues");

            builder.HasKey(x => x.customFieldId);

            if (schema != "untreated")
            {
                builder
                    .HasMany(x => x.items)
                    .WithOne()
                    .OnDelete(DeleteBehavior.NoAction);
            }
            else
            {
                builder.Ignore(x => x.items);
            }

            builder
                .Property(x => x.customFieldId)
                .HasColumnType("int");

            builder
                .Property(x => x.customFieldRuleId)
                .HasColumnType("int");

            builder
                .Property(x => x.line)
                .HasColumnType("int");

            builder
                .Property(x => x.value)
                .HasColumnType("varchar(60)");
        }
    }
}
