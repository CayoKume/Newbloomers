using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSubClassesMap : IEntityTypeConfiguration<LinxSubClasses>
    {
        public void Configure(EntityTypeBuilder<LinxSubClasses> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxSubClasses));

            builder.ToTable("LinxSubClasses");

            if (schema == "linx_microvix_erp")
            {
                builder.HasKey(e => e.id_subclasses);
                builder.Ignore(x => x.id);
            }
            else
            {
                builder.HasKey(x => x.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.id_subclasses)
                .HasColumnType("int");

            builder.Property(e => e.classe)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
