using Domain.IntegrationsCore.Entities.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    internal class MovideskRelationshipsMap : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Relationship));

            builder.ToTable("MovideskRelationships");

            builder.HasKey(x => x.id);

            if (schema != "untreated")
            {
                builder
                    .HasOne(x => x.services)
                    .WithMany()
                    .HasForeignKey(o => o.id)
                    .OnDelete(DeleteBehavior.NoAction);
            }
            else
            {
                builder.Ignore(x => x.services);
            }

            builder
                .Property(x => x.id)
                .HasColumnType("int");

            builder
                .Property(x => x.name)
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.slaAgreement)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.forceChildrenToHaveSomeAgreement)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.allowAllServices)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.includeInParents)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.loadChildOrganizations)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.isGetMethod)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
