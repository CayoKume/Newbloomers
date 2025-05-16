using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxNFeEventoTrustedMap : IEntityTypeConfiguration<LinxNFeEvento>
    {
        public void Configure(EntityTypeBuilder<LinxNFeEvento> builder)
        {
            builder.ToTable("LinxNFeEvento", "linx_microvix_erp");

            builder.HasKey(e => e.id_nfe_evento);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_nfe_evento)
                .HasColumnType("int");

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.codigo_tipo)
                .HasColumnType("varchar(6)");

            builder.Property(e => e.xml)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.hora_emissao)
                .HasColumnType("char(5)");
        }
    }

    public class LinxNFeEventoRawMap : IEntityTypeConfiguration<LinxNFeEvento>
    {
        public void Configure(EntityTypeBuilder<LinxNFeEvento> builder)
        {
            builder.ToTable("LinxNFeEvento", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.id_nfe_evento)
                .HasColumnType("int");

            builder.Property(e => e.id_nfe)
                .HasColumnType("int");

            builder.Property(e => e.codigo_tipo)
                .HasColumnType("varchar(6)");

            builder.Property(e => e.xml)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.data_emissao)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.hora_emissao)
                .HasColumnType("char(5)");
        }
    }
}
