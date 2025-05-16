using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Enums;
using Infrastructure.LinxMicrovix.Outbound.WebService.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTagsMap : IEntityTypeConfiguration<B2CConsultaTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTags> builder)
        {
            builder.ToTable("B2CConsultaTags", "linx_microvix_commerce");

            builder.HasKey(e => e.id_pedido_item);

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido_item)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }

    public class B2CConsultaTagsRawMap : IEntityTypeConfiguration<B2CConsultaTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTags> builder)
        {
            builder.ToTable("B2CConsultaTags", "untreated");

            builder.HasKey(e => e.id);

            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(LogicalColumnType.DateTime);

            builder.Property(e => e.portal)
                .HasColumnType("int");

            builder.Property(e => e.id_pedido_item)
                .HasColumnType("int");

            builder.Property(e => e.descricao)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");
        }
    }
}
