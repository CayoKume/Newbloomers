using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxEnquadramentoIpiTrustedMap : IEntityTypeConfiguration<LinxEnquadramentoIpi>
    {
        public void Configure(EntityTypeBuilder<LinxEnquadramentoIpi> builder)
        {
            builder.ToTable("LinxEnquadramentoIpi", "linx_microvix_erp");

            builder.HasKey(e => e.id_enquadramento_ipi);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_enquadramento_ipi)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(3)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(600)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxEnquadramentoIpiRawMap : IEntityTypeConfiguration<LinxEnquadramentoIpi>
    {
        public void Configure(EntityTypeBuilder<LinxEnquadramentoIpi> builder)
        {
            builder.ToTable("LinxEnquadramentoIpi", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_enquadramento_ipi)
                .HasColumnType("int");

            builder.Property(e => e.codigo)
                .HasColumnType("varchar(3)");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(600)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
