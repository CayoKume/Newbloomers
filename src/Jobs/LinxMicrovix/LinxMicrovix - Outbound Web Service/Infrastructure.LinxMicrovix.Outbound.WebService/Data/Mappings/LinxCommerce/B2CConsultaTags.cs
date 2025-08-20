using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTagsMap : IEntityTypeConfiguration<B2CConsultaTags>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTags> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaTags));

            builder.ToTable("B2CConsultaTags");

            if (schema == "linx_microvix_commerce")
                builder.HasKey(e => e.id_pedido_item);
            
            
            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

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
