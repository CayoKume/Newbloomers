using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxConfiguracoesTributariasEmpresasTrustedMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasEmpresas>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasEmpresas> builder)
        {
            builder.ToTable("LinxConfiguracoesTributariasEmpresas", "linx_microvix_erp");

            builder.HasKey(e => e.id_config_tributaria);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxConfiguracoesTributariasEmpresasRawMap : IEntityTypeConfiguration<LinxConfiguracoesTributariasEmpresas>
    {
        public void Configure(EntityTypeBuilder<LinxConfiguracoesTributariasEmpresas> builder)
        {
            builder.ToTable("LinxConfiguracoesTributariasEmpresas", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_config_tributaria)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
