using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxProdutosInformacoesTrustedMap : IEntityTypeConfiguration<LinxProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosInformacoes> builder)
        {
            builder.ToTable("LinxProdutosInformacoes", "linx_microvix_erp");

            builder.HasKey(e => e.codigoproduto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.informacoes_produto)
                .HasColumnType("varchar(max)");
        }
    }

    public class LinxProdutosInformacoesRawMap : IEntityTypeConfiguration<LinxProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<LinxProdutosInformacoes> builder)
        {
            builder.ToTable("LinxProdutosInformacoes", "untreated");

            builder.HasKey(e => e.codigoproduto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.informacoes_produto)
                .HasColumnType("varchar(max)");
        }
    }
}
