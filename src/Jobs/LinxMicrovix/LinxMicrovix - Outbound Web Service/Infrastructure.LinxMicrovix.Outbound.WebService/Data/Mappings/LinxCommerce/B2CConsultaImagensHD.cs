using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaImagensHDMap : IEntityTypeConfiguration<B2CConsultaImagensHD>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagensHD> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaImagensHD));

            builder.ToTable("B2CConsultaImagensHD");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => new { e.identificador_imagem, e.codigoproduto });
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.identificador_imagem)
                .HasProviderColumnType(EnumTableColumnType.UUID);

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
