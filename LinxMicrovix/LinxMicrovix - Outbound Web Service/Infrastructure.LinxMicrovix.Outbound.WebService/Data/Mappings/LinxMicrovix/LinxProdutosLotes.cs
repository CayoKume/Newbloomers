using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosLotesTrustedMap : IEntityTypeConfiguration<LinxProdutosLotes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosLotes> builder)
        {
            builder.ToTable("LinxProdutosLotes", "linx_microvix_erp");

            builder.HasKey(e => e.codigoproduto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.lote)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo_disponivel)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class LinxProdutosLotesRawMap : IEntityTypeConfiguration<LinxProdutosLotes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosLotes> builder)
        {
            builder.ToTable("LinxProdutosLotes", "untreated");

            builder.HasKey(e => e.codigoproduto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.lote)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.deposito)
                .HasColumnType("int");

            builder.Property(e => e.saldo_disponivel)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
