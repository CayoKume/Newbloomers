using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.IntegrationsCore.Data.Extensions;

using Domain.IntegrationsCore.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaImagensMap : IEntityTypeConfiguration<B2CConsultaImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagens> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaImagens));

            builder.ToTable("B2CConsultaImagens");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_imagem);
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

            builder.Property(e => e.id_imagem)
                .HasColumnType("int");

            builder.Property(e => e.md5)
                .HasColumnType("char(32)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.url_imagem_blob)
                .HasColumnType("varchar(4000)");
        }
    }
}
