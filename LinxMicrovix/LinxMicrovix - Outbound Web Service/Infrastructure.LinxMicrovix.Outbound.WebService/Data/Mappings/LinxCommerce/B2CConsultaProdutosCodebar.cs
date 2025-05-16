using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaProdutosCodebarMap : IEntityTypeConfiguration<B2CConsultaProdutosCodebar>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaProdutosCodebar> builder)
        {
            builder.ToTable("B2CConsultaProdutosCodebar", "linx_microvix_commerce");

            builder.HasKey(e => new { e.codigoproduto, e.id_produtos_codebar });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.id_produtos_codebar)
                .HasColumnType("int");

            builder.Property(e => e.principal)
                .HasProviderColumnType(LogicalColumnType.Bool);

            builder.Property(e => e.empresa)
                .HasColumnType("int");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.tipo_codebar)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
