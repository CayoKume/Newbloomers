using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRotinaOrigemTrustedMap : IEntityTypeConfiguration<LinxRotinaOrigem>
    {
        public void Configure(EntityTypeBuilder<LinxRotinaOrigem> builder)
        {
            builder.ToTable("LinxRotinaOrigem", "linx_microvix_erp");

            builder.HasKey(e => e.codigo_rotina);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_rotina)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_rotina)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxRotinaOrigemRawMap : IEntityTypeConfiguration<LinxRotinaOrigem>
    {
        public void Configure(EntityTypeBuilder<LinxRotinaOrigem> builder)
        {
            builder.ToTable("LinxRotinaOrigem", "untreated");

            builder.HasKey(e => e.codigo_rotina);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigo_rotina)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao_rotina)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
