using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesiaTrustedMap : IEntityTypeConfiguration<LinxAcoesPromocionaisProdutosCortesia>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionaisProdutosCortesia> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionaisProdutosCortesia", "linx_microvix_erp")
                .HasKey(x => x.id_acoes_promocionais_produtos_cortesia);

            builder
                .Property(x => x.id_acoes_promocionais_produtos_cortesia)
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
                .Property(x => x.id_acoes_promocionais)
                .HasColumnType("int");

            builder
                .Property(x => x.id_combinacao_produto)
                .HasColumnType("int");
        }
    }

    public class LinxAcoesPromocionaisProdutosCortesiaRawMap : IEntityTypeConfiguration<LinxAcoesPromocionaisProdutosCortesia>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionaisProdutosCortesia> builder)
        {
            builder
                .ToTable("LinxAcoesPromocionaisProdutosCortesia", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.id_acoes_promocionais_produtos_cortesia)
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
                .Property(x => x.id_acoes_promocionais)
                .HasColumnType("int");

            builder
                .Property(x => x.id_combinacao_produto)
                .HasColumnType("int");
        }
    }
}
