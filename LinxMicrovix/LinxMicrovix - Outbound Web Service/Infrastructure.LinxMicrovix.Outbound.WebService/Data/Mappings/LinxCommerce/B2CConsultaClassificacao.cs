using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.IntegrationsCore.Entities.Enums;
using Infrastructure.IntegrationsCore.Data.Extensions;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Data.Mappings.LinxCommerce
{
    public class B2CConsultaClassificacaoMap : IEntityTypeConfiguration<B2CConsultaClassificacao>
    {
        public void Configure(EntityTypeBuilder<B2CConsultaClassificacao> builder)
        {
            var schema = SchemaContext.GetSchema(typeof(B2CConsultaClassificacao));

            builder.ToTable("B2CConsultaClassificacao");

            if (schema == "linx_microvix_commerce")
            {
                builder.HasKey(e => e.codigo_classificacao);
                builder.Ignore(e => e.id);
            }
            else
            {
                builder.HasKey(e => e.id);

                builder.Property(e => e.id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
            }
            
            builder.Property(e => e.id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.lastupdateon)
                .HasProviderColumnType(EnumTableColumnType.DateTime);

            builder.Property(e => e.codigo_classificacao)
                .HasColumnType("int");

            builder.Property(e => e.nome_classificacao)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.timestamp)
                .HasColumnType("bigint");

            builder.Property(e => e.portal)
                .HasColumnType("int");
        }
    }
}
