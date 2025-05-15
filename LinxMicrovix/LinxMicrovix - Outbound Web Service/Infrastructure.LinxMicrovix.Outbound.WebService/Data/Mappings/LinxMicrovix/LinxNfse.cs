using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNfseTrustedMap : IEntityTypeConfiguration<LinxNfse>
    {
        public void Configure(EntityTypeBuilder<LinxNfse> builder)
        {
            builder.ToTable("LinxNfse", "linx_microvix_erp");

            builder.HasKey(e => e.id_nfse);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_nfse)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.codigo_verificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_nfse_situacao)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
                }
    }

    public class LinxNfseRawMap : IEntityTypeConfiguration<LinxNfse>
    {
        public void Configure(EntityTypeBuilder<LinxNfse> builder)
        {
            builder.ToTable("LinxNfse", "untreated");

            builder.HasKey(e => e.id_nfse);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_nfse)
                .HasColumnType("int");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.codigo_verificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.id_nfse_situacao)
                .HasColumnType("int");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.dt_insert)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
