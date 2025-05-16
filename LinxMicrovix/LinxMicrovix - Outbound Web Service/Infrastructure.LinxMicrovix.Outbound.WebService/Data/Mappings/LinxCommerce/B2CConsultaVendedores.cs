using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaVendedoresMap : IEntityTypeConfiguration<B2CConsultaVendedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaVendedores> builder)
        {
            builder.ToTable("B2CConsultaVendedores", "linx_microvix_commerce");

            builder.HasKey(e => e.cod_vendedor);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.nome_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.comissao_produtos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comissao_servicos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.comissionado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }

    public class B2CConsultaVendedoresRawMap : IEntityTypeConfiguration<B2CConsultaVendedores>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaVendedores> builder)
        {
            builder.ToTable("B2CConsultaVendedores", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.cod_vendedor)
                .HasColumnType("int");

            builder.Property(e => e.nome_vendedor)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.comissao_produtos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comissao_servicos)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.tipo)
                .HasColumnType("char(1)");

            builder.Property(e => e.ativo)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.comissionado)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
