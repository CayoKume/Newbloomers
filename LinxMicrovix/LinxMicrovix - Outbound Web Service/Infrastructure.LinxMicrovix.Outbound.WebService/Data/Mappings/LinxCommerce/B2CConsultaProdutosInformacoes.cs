using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosInformacoesMap : IEntityTypeConfiguration<B2CConsultaProdutosInformacoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosInformacoes> builder)
        {
            builder.ToTable("B2CConsultaProdutosInformacoes", "linx_microvix_commerce");

            builder.HasKey(e => e.id_produtos_informacoes);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_produtos_informacoes)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.informacoes_produto)
                .HasProviderColumnType(LogicalColumnType.Varchar_Max);

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
