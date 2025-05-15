using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxSubClassesTrustedMap : IEntityTypeConfiguration<LinxSubClasses>
    {
        public void Configure(EntityTypeBuilder<LinxSubClasses> builder)
        {
            builder.ToTable("LinxSubClasses", "linx_microvix_erp");

            builder.HasKey(e => e.id_subclasses);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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

    public class LinxSubClassesRawMap : IEntityTypeConfiguration<LinxSubClasses>
    {
        public void Configure(EntityTypeBuilder<LinxSubClasses> builder)
        {
            builder.ToTable("LinxSubClasses", "untreated");

            builder.HasKey(e => e.id_subclasses);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
