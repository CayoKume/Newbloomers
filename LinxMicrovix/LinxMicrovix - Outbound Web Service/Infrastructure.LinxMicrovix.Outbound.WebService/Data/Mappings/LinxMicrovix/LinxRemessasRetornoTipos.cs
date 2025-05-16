using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxRemessasRetornoTiposTrustedMap : IEntityTypeConfiguration<LinxRemessasRetornoTipos>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasRetornoTipos> builder)
        {
            builder.ToTable("LinxRemessasRetornoTipos", "linx_microvix_erp");

            builder.HasKey(e => e.id_remessa_retorno_tipos);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessa_retorno_tipos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxRemessasRetornoTiposRawMap : IEntityTypeConfiguration<LinxRemessasRetornoTipos>
    {
        public void Configure(EntityTypeBuilder<LinxRemessasRetornoTipos> builder)
        {
            builder.ToTable("LinxRemessasRetornoTipos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessa_retorno_tipos)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
