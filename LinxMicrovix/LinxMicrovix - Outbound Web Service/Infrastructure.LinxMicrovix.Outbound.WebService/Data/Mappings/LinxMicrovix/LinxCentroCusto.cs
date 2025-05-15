using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxCentroCustoTrustedMap : IEntityTypeConfiguration<LinxCentroCusto>
    {
        public void Configure(EntityTypeBuilder<LinxCentroCusto> builder)
        {
            builder.ToTable("LinxCentroCusto", "linx_microvix_erp");

            builder.HasKey(e => e.id_centrocusto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.CNPJ)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_centrocusto)
                .HasColumnType("int");

            builder.Property(e => e.nome_centrocusto)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxCentroCustoRawMap : IEntityTypeConfiguration<LinxCentroCusto>
    {
        public void Configure(EntityTypeBuilder<LinxCentroCusto> builder)
        {
            builder.ToTable("LinxCentroCusto", "untreated");

        builder.HasKey(e => e.id_centrocusto);

        builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.portal)
            .HasColumnType("int");

        builder.Property(e => e.empresa)
            .HasColumnType("int");

        builder.Property(e => e.CNPJ)
            .HasColumnType("varchar(14)");

        builder.Property(e => e.id_centrocusto)
            .HasColumnType("int");

        builder.Property(e => e.nome_centrocusto)
            .HasColumnType("varchar(50)");

        builder.Property(e => e.ativo)
            .HasProviderColumnType(LogicalColumnType.Bool);

        builder.Property(e => e.timestamp)
            .HasColumnType("bigint");
        }
    }
}
