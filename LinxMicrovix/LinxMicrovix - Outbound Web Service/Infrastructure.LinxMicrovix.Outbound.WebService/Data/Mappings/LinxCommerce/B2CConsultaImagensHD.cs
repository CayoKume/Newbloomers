using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;


namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaImagensHDMap : IEntityTypeConfiguration<B2CConsultaImagensHD>
    {
        

        

        public void Configure(EntityTypeBuilder<B2CConsultaImagensHD> builder)
        {
            builder.ToTable("B2CConsultaImagensHD");

            builder.HasKey(e => new { e.identificador_imagem, e.codigoproduto });

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.identificador_imagem)
                .HasProviderColumnType(LogicalColumnType.UUID);

            builder.Property(e => e.codigoproduto)
                .HasColumnType("bigint");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.url_imagem_blob)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
