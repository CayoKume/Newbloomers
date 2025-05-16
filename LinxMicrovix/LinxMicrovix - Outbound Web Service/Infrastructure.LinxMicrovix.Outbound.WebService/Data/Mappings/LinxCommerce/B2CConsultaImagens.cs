using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaImagensTrustedMap : IEntityTypeConfiguration<B2CConsultaImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagens> builder)
        {
            builder.ToTable("B2CConsultaImagens", "linx_microvix_commerce");

            builder.HasKey(e => e.id_imagem);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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

    public class B2CConsultaImagensRawMap : IEntityTypeConfiguration<B2CConsultaImagens>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaImagens> builder)
        {
            builder.ToTable("B2CConsultaImagens", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

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
