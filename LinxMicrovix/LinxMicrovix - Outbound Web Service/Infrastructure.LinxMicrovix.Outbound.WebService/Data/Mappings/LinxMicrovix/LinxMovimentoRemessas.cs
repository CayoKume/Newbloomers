using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxMovimentoRemessasTrustedMap : IEntityTypeConfiguration<LinxMovimentoRemessas>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessas> builder)
        {
            builder.ToTable("LinxMovimentoRemessas", "linx_microvix_erp");

            builder.HasKey(e => e.id_remessas);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_tipo)
                .HasColumnType("int");

            builder.Property(e => e.identificador_remessa)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.status)
                .HasColumnType("int");

            builder.Property(e => e.status_descricao)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxMovimentoRemessasRawMap : IEntityTypeConfiguration<LinxMovimentoRemessas>
    {
        public void Configure(EntityTypeBuilder<LinxMovimentoRemessas> builder)
        {
            builder.ToTable("LinxMovimentoRemessas", "untreated");

            builder.HasKey(e => e.id_remessas);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_remessas)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.id_tipo)
                .HasColumnType("int");

            builder.Property(e => e.identificador_remessa)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.status)
                .HasColumnType("int");

            builder.Property(e => e.status_descricao)
                .HasColumnType("varchar(35)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
