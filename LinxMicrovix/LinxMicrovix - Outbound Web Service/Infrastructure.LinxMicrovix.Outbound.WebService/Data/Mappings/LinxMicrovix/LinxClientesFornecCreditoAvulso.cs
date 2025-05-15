using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxClientesFornecCreditoAvulsoTrustedMap : IEntityTypeConfiguration<LinxClientesFornecCreditoAvulso>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCreditoAvulso> builder)
        {
            builder.ToTable("LinxClientesFornecCreditoAvulso", "linx_microvix_erp");

            builder.HasKey(e => e.cod_cliente);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.cod_cliente)
                .HasColumnType("int");

            builder.Property(e => e.controle)
                .HasColumnType("int");

            builder.Property(e => e.data)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.cd)
                .HasColumnType("char(1)");

            builder.Property(e => e.valor)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.motivo)
                .HasColumnType("varchar(max)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.identificador)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.cnpj_emp)
                .HasColumnType("varchar(14)");
        }
    }

    public class LinxClientesFornecCreditoAvulsoRawMap : IEntityTypeConfiguration<LinxClientesFornecCreditoAvulso>
    {
        public void Configure(EntityTypeBuilder<LinxClientesFornecCreditoAvulso> builder)
        {
            builder.ToTable("LinxClientesFornecCreditoAvulso", "untreated");

        builder.HasKey(e => e.cod_cliente);

        builder.Property(e => e.lastupdateon)
            .HasProviderColumnType(LogicalColumnType.DateTime);

        builder.Property(e => e.portal)
            .HasColumnType("int");

        builder.Property(e => e.empresa)
            .HasColumnType("int");

        builder.Property(e => e.cod_cliente)
            .HasColumnType("int");

        builder.Property(e => e.controle)
            .HasColumnType("int");

        builder.Property(e => e.data)
            .HasColumnType("decimal(10,2)");

        builder.Property(e => e.cd)
            .HasColumnType("char(1)");

        builder.Property(e => e.valor)
            .HasColumnType("decimal(10,2)");

        builder.Property(e => e.motivo)
            .HasColumnType("varchar(max)");

        builder.Property(e => e.timestamp)
            .HasColumnType("bigint");

        builder.Property(e => e.identificador)
            .HasProviderColumnType(LogicalColumnType.UUID);

        builder.Property(e => e.cnpj_emp)
            .HasColumnType("varchar(14)");
        }
    }
}
