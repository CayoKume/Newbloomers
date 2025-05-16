using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNcmTrustedMap : IEntityTypeConfiguration<LinxNcm>
    {
        public void Configure(EntityTypeBuilder<LinxNcm> builder)
        {
            builder.ToTable("LinxNcm", "linx_microvix_erp");

            builder.HasKey(e => e.id_ncm);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_genero)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.id_ncm)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }

    public class LinxNcmRawMap : IEntityTypeConfiguration<LinxNcm>
    {
        public void Configure(EntityTypeBuilder<LinxNcm> builder)
        {
            builder.ToTable("LinxNcm", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.codigo_genero)
                .HasColumnType("int");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.id_ncm)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("int");
        }
    }
}
