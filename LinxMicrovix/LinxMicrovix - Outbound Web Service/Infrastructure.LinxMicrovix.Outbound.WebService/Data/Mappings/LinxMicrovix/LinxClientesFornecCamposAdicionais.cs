using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecCamposAdicionaisMap : IEntityTypeConfiguration<LinxClientesFornecCamposAdicionais>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCamposAdicionais> builder)
        {
            builder.ToTable("LinxClientesFornecCamposAdicionais", "linx_microvix_erp");

            builder.HasKey(e => e.cod_cliente);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.campo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor)
                .HasColumnType("varchar(100)");
        }
    }

    public class LinxClientesFornecCamposAdicionaisRawMap : IEntityTypeConfiguration<LinxClientesFornecCamposAdicionais>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCamposAdicionais> builder)
        {
            builder.ToTable("LinxClientesFornecCamposAdicionais", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.campo)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.valor)
                .HasColumnType("varchar(100)");
        }
    }
}
