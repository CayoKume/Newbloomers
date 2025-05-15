using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxTrocaUnificadaResumoVendasTrustedMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendas> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoVendas", "linx_microvix_erp");

            builder.HasKey(e => e.id_troca_unificada_resumo_vendas);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.token)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.identificador)
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_venda)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.venda_cancelada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxTrocaUnificadaResumoVendasRawMap : IEntityTypeConfiguration<LinxTrocaUnificadaResumoVendas>
    {
        public void Configure(EntityTypeBuilder<LinxTrocaUnificadaResumoVendas> builder)
        {
            builder.ToTable("LinxTrocaUnificadaResumoVendas", "untreated");

            builder.HasKey(e => e.id_troca_unificada_resumo_vendas);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_troca_unificada_resumo_vendas)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.token)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.identificador)
                .HasColumnType("uniqueidentifier");

            builder.Property(e => e.documento)
                .HasColumnType("int");

            builder.Property(e => e.serie)
                .HasColumnType("varchar(10)");

            builder.Property(e => e.data_venda)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.documento_cliente)
                .HasColumnType("varchar(14)");

            builder.Property(e => e.venda_cancelada)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
