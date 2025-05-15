using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxColecoesTrustedMap : IEntityTypeConfiguration<LinxColecoes>
    {
        public void Configure(EntityTypeBuilder<LinxColecoes> builder)
        {
            builder.ToTable("LinxColecoes", "linx_microvix_erp");

            builder.HasKey(e => e.id_colecao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_colecao)
                .HasColumnType("int");

            builder.Property(e => e.desc_colecao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }

    public class LinxColecoesRawMap : IEntityTypeConfiguration<LinxColecoes>
    {
        public void Configure(EntityTypeBuilder<LinxColecoes> builder)
        {
            builder.ToTable("LinxColecoes", "untreated");

            builder.HasKey(e => e.id_colecao);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_colecao)
                .HasColumnType("int");

            builder.Property(e => e.desc_colecao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.codigo_integracao_ws)
                .HasColumnType("varchar(50)");
        }
    }
}
