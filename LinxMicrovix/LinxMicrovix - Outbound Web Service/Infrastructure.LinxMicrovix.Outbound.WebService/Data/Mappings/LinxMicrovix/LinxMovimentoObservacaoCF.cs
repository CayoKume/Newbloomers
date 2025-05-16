using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoObservacaoCFTrustedMap : IEntityTypeConfiguration<LinxMovimentoObservacaoCF>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacaoCF> builder)
        {
            builder.ToTable("LinxMovimentoObservacaoCF", "linx_microvix_erp");

            builder.HasKey(e => e.identificador);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoObservacaoCFRawMap : IEntityTypeConfiguration<LinxMovimentoObservacaoCF>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoObservacaoCF> builder)
        {
            builder.ToTable("LinxMovimentoObservacaoCF", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
