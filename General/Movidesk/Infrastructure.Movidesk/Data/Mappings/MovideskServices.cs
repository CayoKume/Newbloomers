using Domain.IntegrationsCore.Enums;
using Domain.Movidesk.Entities;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Movidesk.Data.Mappings
{
    public class MovideskServicesMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(Service));

            builder.ToTable("MovideskServices");

            builder.HasKey(x => x.id);

            builder
                .Property(x => x.id)
                .HasColumnType("int")
                .ValueGeneratedNever();

            builder
                .Property(x => x.parentServiceId)
                .HasColumnType("int");

            builder
                .Property(x => x.serviceForTicketType)
                .HasColumnType("int");

            builder
                .Property(x => x.isVisible)
                .HasColumnType("int");

            builder
                .Property(x => x.allowSelection)
                .HasColumnType("int");

            builder.Property(e => e.name)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.description)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.automationMacro)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.defaultCategory)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.defaultUrgency)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.categories)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.allowFinishTicket)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.isActive)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.copyToChildren)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.allowAllCategories)
                .HasProviderColumnType(EnumTableColumnType.Bool);
        }
    }
}
