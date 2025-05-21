using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaColecoesMap : IEntityTypeConfiguration<B2CConsultaColecoes>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaColecoes> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaColecoes));

            builder.ToTable("B2CConsultaColecoes");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_colecao);
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

            builder.Property(e => e.codigo_colecao)
                .HasColumnType("int");

            builder.Property(e => e.nome_colecao)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.marcas)
                .HasColumnType("varchar(250)");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
