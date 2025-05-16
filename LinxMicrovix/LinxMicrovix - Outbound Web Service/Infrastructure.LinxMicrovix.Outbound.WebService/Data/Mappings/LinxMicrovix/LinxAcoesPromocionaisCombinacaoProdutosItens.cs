using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAcoesPromocionaisCombinacaoProdutosItensTrustedMap : IEntityTypeConfiguration<LinxAcoesPromocionaisCombinacaoProdutosItens>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionaisCombinacaoProdutosItens> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionaisCombinacaoProdutosItens", "linx_microvix_erp")
                .HasKey(x => x.id_acoes_promocionais_combinacao_produtos_itens);

            builder
                .Property(x => x.id_acoes_promocionais_combinacao_produtos_itens)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.timestamp)
                .HasColumnType("bigint");

            builder
                .Property(x => x.codigoproduto)
                .HasColumnType("bigint");

            builder
                .Property(x => x.id_combinacao_produto)
                .HasColumnType("int");
        }
    }

    public class LinxAcoesPromocionaisCombinacaoProdutosItensRawMap : IEntityTypeConfiguration<LinxAcoesPromocionaisCombinacaoProdutosItens>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionaisCombinacaoProdutosItens> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionaisCombinacaoProdutosItens", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.id_acoes_promocionais_combinacao_produtos_itens)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder
                .Property(x => x.portal)
                .HasColumnType("int");

            builder
                .Property(x => x.timestamp)
                .HasColumnType("bigint");

            builder
                .Property(x => x.codigoproduto)
                .HasColumnType("bigint");

            builder
                .Property(x => x.id_combinacao_produto)
                .HasColumnType("int");
        }
    }
}
