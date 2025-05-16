using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTamanhosMap : IEntityTypeConfiguration<LinxTamanhos>
    {
        public void Configure(EntityTypeBuilder<LinxTamanhos> builder)
        {
            builder.ToTable("LinxTamanhos", "linx_microvix_erp");

            builder.HasKey(e => e.id);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_tamanho)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.desc_tamanho)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }

    public class LinxTamanhosRawMap : IEntityTypeConfiguration<LinxTamanhos>
    {
        public void Configure(EntityTypeBuilder<LinxTamanhos> builder)
        {
            builder.ToTable("LinxTamanhos", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id)
                .HasColumnType("int");

            builder.Property(e => e.id_tamanho)
                .HasColumnType("varchar(5)");

            builder.Property(e => e.desc_tamanho)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);
        }
    }
}
