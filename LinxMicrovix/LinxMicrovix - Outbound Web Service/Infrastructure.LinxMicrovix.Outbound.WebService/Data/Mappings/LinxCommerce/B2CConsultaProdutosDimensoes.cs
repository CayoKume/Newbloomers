using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosDimensoesMap : IEntityTypeConfiguration<B2CConsultaProdutosDimensoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosDimensoes> builder)
        {
            builder.ToTable("B2CConsultaProdutosDimensoes", "linx_microvix_commerce");

            builder.HasKey(e => e.codigoproduto);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.altura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.comprimento)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.largura)
                .HasColumnType("decimal(10,2)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
