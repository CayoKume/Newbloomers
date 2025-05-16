using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMarcasMap : IEntityTypeConfiguration<LinxMarcas>
    {
        public void Configure(EntityTypeBuilder<LinxMarcas> builder)
        {
            builder.ToTable("LinxMarcas", "linx_microvix_erp");

            builder.HasKey(e => e.id_marca);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }

    public class LinxMarcasRawMap : IEntityTypeConfiguration<LinxMarcas>
    {
        public void Configure(EntityTypeBuilder<LinxMarcas> builder)
        {
            builder.ToTable("LinxMarcas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_marca)
                .HasColumnType("int");

            builder.Property(e => e.desc_marca)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
