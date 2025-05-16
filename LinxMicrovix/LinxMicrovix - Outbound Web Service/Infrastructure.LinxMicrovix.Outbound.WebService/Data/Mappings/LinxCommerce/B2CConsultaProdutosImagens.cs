using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosImagensMap : IEntityTypeConfiguration<B2CConsultaProdutosImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosImagens> builder)
        {
            builder.ToTable("B2CConsultaProdutosImagens", "linx_microvix_commerce");

            builder.HasKey(e => e.id_imagem_produto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.id_imagem_produto)
                .HasColumnType("int");

            builder.Property(e => e.id_imagem)
                .HasColumnType("int");

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
