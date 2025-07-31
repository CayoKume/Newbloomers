using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTipoEncomendaMap : IEntityTypeConfiguration<B2CConsultaTipoEncomenda>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTipoEncomenda> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaTipoEncomenda));

            builder.ToTable("B2CConsultaTipoEncomenda");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.id_tipo_encomenda);
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

            builder.Property(e => e.id_tipo_encomenda)
                .HasColumnType("int");

            builder.Property(e => e.nm_tipo_encomenda)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
