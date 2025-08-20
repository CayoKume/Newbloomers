using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Models.LinxCommerce;
using Infrastructure.Core.Data.Extensions;

using Domain.Core.Enums;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaTiposCobrancaFreteMap : IEntityTypeConfiguration<B2CConsultaTiposCobrancaFrete>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaTiposCobrancaFrete> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaTiposCobrancaFrete));

            builder.ToTable("B2CConsultaTiposCobrancaFrete");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_tipo_cobranca_frete);
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

            builder.Property(e => e.codigo_tipo_cobranca_frete)
                .HasColumnType("int");

            builder.Property(e => e.nome_tipo_cobranca_frete)
                .HasColumnType("varchar(60)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
