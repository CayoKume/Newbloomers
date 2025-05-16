using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoVendaConjugadaMap : IEntityTypeConfiguration<LinxMovimentoVendaConjugada>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoVendaConjugada> builder)
        {
            builder.ToTable("LinxMovimentoVendaConjugada", "linx_microvix_erp");

            builder.HasKey(e => e.identificador_produto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador_produto)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.identificador_servico)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoVendaConjugadaRawMap : IEntityTypeConfiguration<LinxMovimentoVendaConjugada>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoVendaConjugada> builder)
        {
            builder.ToTable("LinxMovimentoVendaConjugada", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador_produto)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.identificador_servico)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
