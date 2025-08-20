using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxMicrovix;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Core.Data.Extensions;
using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxMicrovix
{
    public class LinxAcoesPromocionaisProdutosCortesiaMap : IEntityTypeConfiguration<LinxAcoesPromocionaisProdutosCortesia>
    {
        public void Configure(EntityTypeBuilder<LinxAcoesPromocionaisProdutosCortesia> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(LinxAcoesPromocionaisProdutosCortesia));

            builder.ToTable("LinxAcoesPromocionaisProdutosCortesia");

            if (schema == "linx_microvix_erp")
                builder.HasKey(x => x.id_acoes_promocionais_produtos_cortesia);
            
            
            builder
                .Property(x => x.id_acoes_promocionais_produtos_cortesia)
                .HasColumnType("int");

            builder
                .Property(x => x.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
